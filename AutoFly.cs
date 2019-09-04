using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleExample
{
    public partial class AutoFly : Form
    {
        MAVLink.MavlinkParse mavlink = new MAVLink.MavlinkParse();
        bool armed = false;
        // 读取串口开关
        object readlock = new object();
        // sysid参数
        byte sysid;
        // compid参数
        byte compid;

        public AutoFly()//窗口控件
        {
            InitializeComponent();
        }

        private void but_connect_Click(object sender, EventArgs e)
        {
            
            if (serialPort1.IsOpen)
            {
               
                serialPort1.Close();
                return;
            }

            // 设置串口属性
            serialPort1.PortName = CMB_comport.Text;
            //初始化波特率
            serialPort1.BaudRate = int.Parse(cmb_baudrate.Text);

            
            serialPort1.Open();

            // 设定超时时间2000毫秒（如果超时了，内部程序会提示没连上）
            serialPort1.ReadTimeout = 2000;

             

            BackgroundWorker bgw = new BackgroundWorker();//开启读取线程

            bgw.DoWork += bgw_DoWork;//与上下一行构成整体读取线程

            bgw.RunWorkerAsync();//读取线程同步运行
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (serialPort1.IsOpen)
            {
                try//首先需要申请全部数据包，否则只能收到心跳包！*****
                {

                    //只有此处申请66号信息包才能获得全部参数！
                    //放在监听中无法实时触发！
                    MAVLink.mavlink_request_data_stream_t r = new MAVLink.mavlink_request_data_stream_t();
                    r.req_message_rate = 2;
                    r.req_stream_id = (byte)MAVLink.MAV_DATA_STREAM.ALL;
                    r.start_stop = 1;
                    r.target_component = compid;
                    r.target_system = sysid;
                    byte[] packetRequest = mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.REQUEST_DATA_STREAM, r);
                    serialPort1.Write(packetRequest, 0, packetRequest.Length);


                    MAVLink.MAVLinkMessage packet;//定义一个mavlink消息解析类
                    lock (readlock)//锁定读取端口的当前数据当前数据
                    {
                        //读取端口的数据流
                        packet = mavlink.ReadPacket(serialPort1.BaseStream);

                        
                        if (packet == null || packet.data == null)
                            continue;
                    }

                    //判断是否为心跳包，如果是向向飞控申请数据流
                    //
                    if (packet.data.GetType() == typeof(MAVLink.mavlink_heartbeat_t))
                    {
                        var hb = (MAVLink.mavlink_heartbeat_t)packet.data;

                      
                        
                        // 保存包sysid和compid参数
                        sysid = packet.sysid;
                        compid = packet.compid;

                        Console.WriteLine("飞控数据接收成功：");

                        //向飞控申请数据流
                 /*       mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.REQUEST_DATA_STREAM,
                            //飞控数据流的格式要求
                            new MAVLink.mavlink_request_data_stream_t()
                            {//Mavlink的一个结构体数组
                                req_message_rate = 2,//信息频率2hz
                                //数据流ID，ALL枚举=0，代表获得全部信息
                                req_stream_id = (byte)MAVLink.MAV_DATA_STREAM.ALL,
                                
                                start_stop = 1,//1开始发送，0停止发送
                                target_component = compid,
                                target_system = sysid
                            });*/




                    }

                    
                
                    // 核对发送的信息
                    if (sysid != packet.sysid || compid != packet.compid)
                        continue;
                       // Console.WriteLine("packet.msgid = " + packet.msgid);
                    
                    if(packet.msgid == 0)
                    {
                        var mode1 = (MAVLink.mavlink_heartbeat_t)packet.data;
                        Console.WriteLine("当前模式" + mode1.base_mode);
                        string s = mode1.base_mode.ToString();
                        int n = Convert.ToInt32(s);
                        /* MAV_MODE   ****
                          0	MAV_MODE_PREFLIGHT
                        80  MAV_MODE_STABILIZE_DISARMED
                        208	MAV_MODE_STABILIZE_ARMED
                        88	MAV_MODE_GUIDED_DISARMED
                        216	MAV_MODE_GUIDED_ARMED
                        */
                        string str = null;
                        switch (n)
                        {
                            case 1:str = "设备故障";break;
                            case 81: str = "自稳锁定"; break;
                            case 209: str = "自稳解锁"; break;
                            case 89: str = "引导锁定"; break;
                            case 217:str = "引导解锁"; break;
                            default: str = "其他模式"; break;

                        }
                        if (fly.Text.Equals("已起飞") && str.Equals("自稳锁定"))
                            fly.Text = "等待起飞..";
                        textBox1.Text = str;
                    }
                    if (packet.msgid == (byte)MAVLink.MAVLINK_MSG_ID.ALTITUDE)
                    //#141号信息包
                    {
                        var alti = (MAVLink.mavlink_altitude_t)packet.data;

                        Console.WriteLine("当前高度"+alti.altitude_relative) ;
                      
                        
                       
                    }
                    if (packet.msgid == (byte)MAVLink.MAVLINK_MSG_ID.GPS_RAW_INT)
                    //#24号信息包
                    {
                   
                        var sta = (MAVLink.mavlink_gps_raw_int_t)packet.data;
                        Console.WriteLine("地速度" + sta.vel/100.0);
                        Console.WriteLine("卫星数量" + sta.satellites_visible);
                        int n = (int)(sta.satellites_visible & 0xFF);
                        gps.Text = Convert.ToString(n);
                    }
                    if (packet.msgid == (byte)MAVLink.MAVLINK_MSG_ID.GLOBAL_POSITION_INT)
                    //#33号信息包
                    {
                        var glo = (MAVLink.mavlink_global_position_int_t)packet.data;
                        Console.WriteLine("垂直速度" + glo.vz / 100.0);
                        Console.WriteLine("相对高度" + glo.relative_alt/1000.0);
                    }
                    if (packet.msgid == 62)
                    //#62号信息包 NAV_CONTROLLER_OUTPUT
                    {
                        var nav = (MAVLink.mavlink_nav_controller_output_t)packet.data;
                        
                        Console.WriteLine("高度误差" + nav.alt_error);
                        error.Text = nav.alt_error.ToString("f2");
                    }
                    if (packet.msgid == 74)
                    //#74号信息包 VFR_HUD
                    {
                        var vfr = (MAVLink.mavlink_vfr_hud_t)packet.data;

                        Console.WriteLine("空速" + vfr.airspeed);
                        airv.Text = Convert.ToString(vfr.airspeed);
                        Console.WriteLine("地速" + vfr.groundspeed);
                        grov.Text = Convert.ToString(vfr.groundspeed);
                        Console.WriteLine("高度" + vfr.alt);
                        alt.Text = Convert.ToString(vfr.alt);
                        Console.WriteLine("升降速度" + vfr.climb);
                        clime.Text = Convert.ToString(vfr.climb);


                    }

                }


                catch
                {
                }

                System.Threading.Thread.Sleep(1);//while循环通常加这句，防止堵死
            }
        }

        T readsomedata<T>(byte sysid, byte compid, int timeout = 2000)//读取反馈信息
        {//最多读取2000毫秒
            DateTime deadline = DateTime.Now.AddMilliseconds(timeout);

            lock (readlock)//地面站读取飞控的反馈信息
            {
                // 读取当前信息
                while (DateTime.Now < deadline)
                {
                    var packet = mavlink.ReadPacket(serialPort1.BaseStream);

                    // 核对信息
                    if (packet == null || sysid != packet.sysid || compid != packet.compid)
                        continue;

                    Console.WriteLine("反馈信息正确"+packet);

                    if (packet.data.GetType() == typeof(T))
                    {
                        return (T)packet.data;
                    }
                }
            }

            throw new Exception("No packet match found");
        }

        private void but_armdisarm_Click(object sender, EventArgs e)//单击arm/disarm执行的回调函数
        {
            
      

            MAVLink.mavlink_command_long_t req = new MAVLink.mavlink_command_long_t();//定义req为 MAVLink.mavlink_command_long_t类，填充常命令的数据包

            req.target_system = 1;
            req.target_component = 1;

            req.command = (ushort)MAVLink.MAV_CMD.COMPONENT_ARM_DISARM;//‘COMPONENT_ARM_DISARM’代表你要发送什么类的信息（此处为解锁信息），可自己选择（看类里有多少种）


            // 此处发送解锁信息，只需用param1。其余param2—7注释掉
            req.param1 = armed ? 0 : 1;
            armed = !armed;


            byte[] packet = mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, req);//把req数据包，按照mavlink协议打包成（定义了临时变量packet）
                                                                                                      // byte[] packet = mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, req);//把req数据包，按照mavlink协议打包成（定义了临时变量packet）
         //  mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.SET_POSITION_TARGET_LOCAL_NED, req);

            serialPort1.Write(packet, 0, packet.Length);//发送数据包
            //offset  参数中从零开始的字节偏移量，从此处开始将字节复制到端口
            try
            {
                
                var ack = readsomedata<MAVLink.mavlink_command_ack_t>(sysid, compid);//读取反馈信号
                if (ack.result == (byte)MAVLink.MAV_RESULT.ACCEPTED)
                {
                    Console.WriteLine("---解锁/上锁完成---");

                }
                if (ack.result == (byte)MAVLink.MAV_RESULT.TEMPORARILY_REJECTED)
                {
                    Console.WriteLine("---解锁/上锁命令失败---");
                }
            }
            catch
            {
            }
        }

        private void CMB_comport_Click(object sender, EventArgs e)
        {
            CMB_comport.DataSource = SerialPort.GetPortNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void simpleexample_Load(object sender, EventArgs e)
        {

        }

        private void CMB_comport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void autoFly_Click(object sender, EventArgs e)
        {



            MAVLink.mavlink_set_mode_t mode1 = new MAVLink.mavlink_set_mode_t();
            byte base_mode1 = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED;
            byte custom_mode1 = 1;
            byte target_system1 = sysid;
            mode1.custom_mode = custom_mode1;
            mode1.base_mode = base_mode1;
            mode1.target_system = target_system1;
            System.Threading.Thread.Sleep(100);

            


            MAVLink.mavlink_command_long_t req = new MAVLink.mavlink_command_long_t();//定义req为 MAVLink.mavlink_command_long_t类，填充常命令的数据包

            req.target_system = 1;
            req.target_component = 1;

            req.command = (ushort)MAVLink.MAV_CMD.COMPONENT_ARM_DISARM;//‘COMPONENT_ARM_DISARM’代表你要发送什么类的信息（此处为解锁信息），可自己选择（看类里有多少种）
                                                                       //req.command = (ushort)MAVLink.MAV_CMD

            req.param1 = 1;//此处发送解锁信息，只需用param1。其余param2—7注释掉


            MAVLink.mavlink_set_mode_t mode4 = new MAVLink.mavlink_set_mode_t();
            byte base_mode4 = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED;
            byte custom_mode4 = 4;
            byte target_system4 = sysid;
            mode4.custom_mode = custom_mode4;
            mode4.base_mode = base_mode4;
            mode4.target_system = target_system4;
            
         
            MAVLink.mavlink_command_long_t req2 = new MAVLink.mavlink_command_long_t();//定义req为 MAVLink.mavlink_command_long_t类，填充常命令的数据包

            req2.target_system = 1;
            req2.target_component = 1;



            
            req2.command = (ushort)MAVLink.MAV_CMD.TAKEOFF;

            req2.param1 = 0;
            req2.param2 = 0;
            req2.param3 = 0;
            req2.param4 = 0;
            req2.param5 = 0;
            req2.param6 = 0;
            req2.param7 = 2;

            


            byte[] packetMode1 = mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.SET_MODE, mode1);


            byte[] packet = mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, req);

            
            byte[] packetMode4 = mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.SET_MODE, mode4);

            //把req数据包，按照mavlink协议打包成（定义了临时变量packet）
            byte[] packet2 = mavlink.GenerateMAVLinkPacket10(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, req2);


            


            serialPort1.Write(packetMode1, 0, packetMode1.Length);//发送数据包
            System.Threading.Thread.Sleep(50);
            try
            {

                var ack1 = readsomedata<MAVLink.mavlink_command_ack_t>(sysid, compid);//读取反馈信号
                if (ack1.result == (byte)MAVLink.MAV_RESULT.ACCEPTED)
                {
                    Console.WriteLine("切换到自稳模式");
                    
                }
                if (ack1.result == (byte)MAVLink.MAV_RESULT.TEMPORARILY_REJECTED)
                {
                    Console.WriteLine("---切换到自稳模式失败---");
                }
            }
            catch
            {
            }
            System.Threading.Thread.Sleep(20);

            


            serialPort1.Write(packet, 0, packet.Length);
            System.Threading.Thread.Sleep(50);
            try
            {

                var ack2 = readsomedata<MAVLink.mavlink_command_ack_t>(sysid, compid);//读取反馈信号
                if (ack2.result == (byte)MAVLink.MAV_RESULT.ACCEPTED)
                {
                    Console.WriteLine("解锁完成");
                   
                }
                if (ack2.result == (byte)MAVLink.MAV_RESULT.TEMPORARILY_REJECTED)
                {
                    Console.WriteLine("---解锁失败---");
                }
            }
            catch
            {
            }
            System.Threading.Thread.Sleep(1500);



           serialPort1.Write(packetMode4, 0, packetMode4.Length);
            System.Threading.Thread.Sleep(50);
            try
            {

                var ack3 = readsomedata<MAVLink.mavlink_command_ack_t>(sysid, compid);//读取反馈信号
                if (ack3.result == (byte)MAVLink.MAV_RESULT.ACCEPTED)
                {
                    Console.WriteLine("切换到引导模式");

                }
                if (ack3.result == (byte)MAVLink.MAV_RESULT.TEMPORARILY_REJECTED)
                {
                    Console.WriteLine("---切换到引导模式失败---");
                }
            }
            catch
            {
            }
            System.Threading.Thread.Sleep(100);



           serialPort1.Write(packet2, 0, packet2.Length);
            System.Threading.Thread.Sleep(100);
            try
            {
                
                var ack4 = readsomedata<MAVLink.mavlink_command_ack_t>(sysid, compid);//读取反馈信号
                if (ack4.result == (byte)MAVLink.MAV_RESULT.ACCEPTED)
                {
                    Console.WriteLine("-----起飞！！！-----");
                    fly.Text = "已起飞";

                }
                if (ack4.result == (byte)MAVLink.MAV_RESULT.TEMPORARILY_REJECTED)
                {
                    Console.WriteLine("--起飞失败，请检查飞机状态--");
                }
            }
            catch
            {
            }
            

        }
        
        private void CMB_comport_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmb_baudrate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void alt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void error_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
