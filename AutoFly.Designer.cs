namespace SimpleExample
{
    partial class AutoFly
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

                #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoFly));
            this.fly = new System.Windows.Forms.TextBox();
            this.CMB_comport = new System.Windows.Forms.ComboBox();
            this.cmb_baudrate = new System.Windows.Forms.ComboBox();
            this.but_connect = new System.Windows.Forms.Button();
            this.but_armdisarm = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.takeoff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.alt = new System.Windows.Forms.TextBox();
            this.grov = new System.Windows.Forms.TextBox();
            this.airv = new System.Windows.Forms.TextBox();
            this.gps = new System.Windows.Forms.TextBox();
            this.clime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fly
            // 
            this.fly.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fly.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fly.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fly.Location = new System.Drawing.Point(261, 366);
            this.fly.Name = "fly";
            this.fly.ReadOnly = true;
            this.fly.Size = new System.Drawing.Size(160, 42);
            this.fly.TabIndex = 21;
            this.fly.Text = "等待起飞..";
            this.fly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CMB_comport
            // 
            this.CMB_comport.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CMB_comport.FormattingEnabled = true;
            this.CMB_comport.Location = new System.Drawing.Point(35, 35);
            this.CMB_comport.Margin = new System.Windows.Forms.Padding(4);
            this.CMB_comport.Name = "CMB_comport";
            this.CMB_comport.Size = new System.Drawing.Size(160, 23);
            this.CMB_comport.TabIndex = 0;
            this.CMB_comport.SelectedIndexChanged += new System.EventHandler(this.CMB_comport_SelectedIndexChanged_1);
            this.CMB_comport.Click += new System.EventHandler(this.CMB_comport_Click);
            // 
            // cmb_baudrate
            // 
            this.cmb_baudrate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmb_baudrate.FormattingEnabled = true;
            this.cmb_baudrate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.cmb_baudrate.Location = new System.Drawing.Point(260, 35);
            this.cmb_baudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_baudrate.Name = "cmb_baudrate";
            this.cmb_baudrate.Size = new System.Drawing.Size(160, 23);
            this.cmb_baudrate.TabIndex = 1;
            this.cmb_baudrate.SelectedIndexChanged += new System.EventHandler(this.cmb_baudrate_SelectedIndexChanged);
            // 
            // but_connect
            // 
            this.but_connect.BackColor = System.Drawing.Color.LightSkyBlue;
            this.but_connect.Location = new System.Drawing.Point(477, 12);
            this.but_connect.Margin = new System.Windows.Forms.Padding(4);
            this.but_connect.Name = "but_connect";
            this.but_connect.Size = new System.Drawing.Size(98, 66);
            this.but_connect.TabIndex = 2;
            this.but_connect.Text = "连接串口";
            this.but_connect.UseVisualStyleBackColor = false;
            this.but_connect.Click += new System.EventHandler(this.but_connect_Click);
            // 
            // but_armdisarm
            // 
            this.but_armdisarm.BackColor = System.Drawing.Color.LightSkyBlue;
            this.but_armdisarm.Location = new System.Drawing.Point(624, 13);
            this.but_armdisarm.Margin = new System.Windows.Forms.Padding(4);
            this.but_armdisarm.Name = "but_armdisarm";
            this.but_armdisarm.Size = new System.Drawing.Size(102, 65);
            this.but_armdisarm.TabIndex = 3;
            this.but_armdisarm.Text = "解锁/上锁";
            this.but_armdisarm.UseVisualStyleBackColor = false;
            this.but_armdisarm.Click += new System.EventHandler(this.but_armdisarm_Click);
            // 
            // takeoff
            // 
            this.takeoff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("takeoff.BackgroundImage")));
            this.takeoff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.takeoff.Location = new System.Drawing.Point(477, 103);
            this.takeoff.Name = "takeoff";
            this.takeoff.Size = new System.Drawing.Size(249, 243);
            this.takeoff.TabIndex = 4;
            this.takeoff.UseVisualStyleBackColor = true;
            this.takeoff.Click += new System.EventHandler(this.autoFly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(38, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "高度(m)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(38, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "GPS数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(489, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "地  速";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(620, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "空  速";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(38, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "升降速(m/s)";
            // 
            // alt
            // 
            this.alt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.alt.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alt.ForeColor = System.Drawing.Color.Red;
            this.alt.Location = new System.Drawing.Point(43, 131);
            this.alt.Name = "alt";
            this.alt.ReadOnly = true;
            this.alt.Size = new System.Drawing.Size(100, 42);
            this.alt.TabIndex = 11;
            this.alt.Text = "0.00";
            this.alt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alt.TextChanged += new System.EventHandler(this.alt_TextChanged);
            // 
            // grov
            // 
            this.grov.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grov.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grov.Location = new System.Drawing.Point(493, 400);
            this.grov.Name = "grov";
            this.grov.ReadOnly = true;
            this.grov.Size = new System.Drawing.Size(100, 34);
            this.grov.TabIndex = 14;
            this.grov.Text = "0.00";
            this.grov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // airv
            // 
            this.airv.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.airv.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.airv.Location = new System.Drawing.Point(624, 396);
            this.airv.Name = "airv";
            this.airv.ReadOnly = true;
            this.airv.Size = new System.Drawing.Size(100, 38);
            this.airv.TabIndex = 15;
            this.airv.Text = "0.00";
            this.airv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gps
            // 
            this.gps.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gps.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gps.ForeColor = System.Drawing.Color.Blue;
            this.gps.Location = new System.Drawing.Point(43, 366);
            this.gps.Name = "gps";
            this.gps.ReadOnly = true;
            this.gps.Size = new System.Drawing.Size(100, 42);
            this.gps.TabIndex = 16;
            this.gps.Text = "0";
            this.gps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clime
            // 
            this.clime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.clime.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.clime.Location = new System.Drawing.Point(43, 242);
            this.clime.Name = "clime";
            this.clime.ReadOnly = true;
            this.clime.Size = new System.Drawing.Size(100, 42);
            this.clime.TabIndex = 17;
            this.clime.Text = "0.00";
            this.clime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(256, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 28);
            this.label6.TabIndex = 20;
            this.label6.Text = "当前模式";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(261, 242);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(161, 42);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "获取中";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // error
            // 
            this.error.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.error.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.error.Location = new System.Drawing.Point(261, 131);
            this.error.Name = "error";
            this.error.ReadOnly = true;
            this.error.Size = new System.Drawing.Size(161, 42);
            this.error.TabIndex = 25;
            this.error.Text = "0.00";
            this.error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.error.TextChanged += new System.EventHandler(this.error_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(256, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 28);
            this.label7.TabIndex = 26;
            this.label7.Text = "高度误差(m)";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // AutoFly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(790, 446);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.error);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.fly);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clime);
            this.Controls.Add(this.gps);
            this.Controls.Add(this.airv);
            this.Controls.Add(this.grov);
            this.Controls.Add(this.alt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.takeoff);
            this.Controls.Add(this.but_armdisarm);
            this.Controls.Add(this.but_connect);
            this.Controls.Add(this.cmb_baudrate);
            this.Controls.Add(this.CMB_comport);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoFly";
            this.Text = "一键起飞地面站";
            this.Load += new System.EventHandler(this.simpleexample_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ComboBox CMB_comport;
        private System.Windows.Forms.ComboBox cmb_baudrate;
        private System.Windows.Forms.Button but_connect;
        private System.Windows.Forms.Button but_armdisarm;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button takeoff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox alt;
        private System.Windows.Forms.TextBox grov;
        private System.Windows.Forms.TextBox airv;
        private System.Windows.Forms.TextBox gps;
        private System.Windows.Forms.TextBox clime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox error;
        private System.Windows.Forms.TextBox fly;
        private System.Windows.Forms.Label label7;
    }
}

