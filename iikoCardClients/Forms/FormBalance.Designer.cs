namespace iikoCardClients
{
    partial class FormBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBalance));
            this.timer_settings = new System.Windows.Forms.Timer(this.components);
            this.timer_readerConnection = new System.Windows.Forms.Timer(this.components);
            this.tl_BackGround = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.l_Customer_Fname = new System.Windows.Forms.Label();
            this.l_Customer_Sname = new System.Windows.Forms.Label();
            this.l_Customer_Balance = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.l_Customer_Card = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pb_info_logo = new System.Windows.Forms.PictureBox();
            this.pb_info_field = new System.Windows.Forms.PictureBox();
            this.tl_BackGround.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_field)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_settings
            // 
            this.timer_settings.Interval = 60000;
            this.timer_settings.Tick += new System.EventHandler(this.timer_settings_Tick);
            // 
            // timer_readerConnection
            // 
            this.timer_readerConnection.Interval = 5000;
            this.timer_readerConnection.Tick += new System.EventHandler(this.timer_readerConnection_Tick);
            // 
            // tl_BackGround
            // 
            this.tl_BackGround.BackgroundImage = global::iikoCardClients.Properties.Resources.background_all;
            this.tl_BackGround.ColumnCount = 3;
            this.tl_BackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tl_BackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tl_BackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tl_BackGround.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tl_BackGround.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tl_BackGround.Controls.Add(this.pb_info_field, 1, 4);
            this.tl_BackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_BackGround.Location = new System.Drawing.Point(0, 0);
            this.tl_BackGround.Name = "tl_BackGround";
            this.tl_BackGround.RowCount = 6;
            this.tl_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tl_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tl_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tl_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tl_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tl_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tl_BackGround.Size = new System.Drawing.Size(1020, 707);
            this.tl_BackGround.TabIndex = 18;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.BackgroundImage = global::iikoCardClients.Properties.Resources.background_info;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.5177F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.57154F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.91075F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.l_Customer_Balance, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.l_Customer_Card, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(102, 338);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(816, 247);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.l_Customer_Fname);
            this.flowLayoutPanel2.Controls.Add(this.l_Customer_Sname);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(50, 7);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(353, 116);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // l_Customer_Fname
            // 
            this.l_Customer_Fname.AutoSize = true;
            this.l_Customer_Fname.Font = new System.Drawing.Font("Arial", 41.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Customer_Fname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(200)))), ((int)(((byte)(9)))));
            this.l_Customer_Fname.Location = new System.Drawing.Point(3, 0);
            this.l_Customer_Fname.Name = "l_Customer_Fname";
            this.l_Customer_Fname.Size = new System.Drawing.Size(277, 63);
            this.l_Customer_Fname.TabIndex = 0;
            this.l_Customer_Fname.Text = "Федченко";
            // 
            // l_Customer_Sname
            // 
            this.l_Customer_Sname.AutoSize = true;
            this.l_Customer_Sname.Font = new System.Drawing.Font("Arial", 41.25F);
            this.l_Customer_Sname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(200)))), ((int)(((byte)(9)))));
            this.l_Customer_Sname.Location = new System.Drawing.Point(3, 63);
            this.l_Customer_Sname.Name = "l_Customer_Sname";
            this.l_Customer_Sname.Size = new System.Drawing.Size(263, 126);
            this.l_Customer_Sname.TabIndex = 1;
            this.l_Customer_Sname.Text = "Альберт Юрьевич";
            // 
            // l_Customer_Balance
            // 
            this.l_Customer_Balance.AutoSize = true;
            this.l_Customer_Balance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Customer_Balance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Customer_Balance.Font = new System.Drawing.Font("Arial", 95F, System.Drawing.FontStyle.Bold);
            this.l_Customer_Balance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(180)))), ((int)(((byte)(9)))));
            this.l_Customer_Balance.Location = new System.Drawing.Point(456, 7);
            this.l_Customer_Balance.Margin = new System.Windows.Forms.Padding(3, 0, 80, 0);
            this.l_Customer_Balance.Name = "l_Customer_Balance";
            this.l_Customer_Balance.Size = new System.Drawing.Size(190, 116);
            this.l_Customer_Balance.TabIndex = 1;
            this.l_Customer_Balance.Text = "8650";
            this.l_Customer_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Verdana", 18.75F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label13.Location = new System.Drawing.Point(50, 147);
            this.label13.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(403, 24);
            this.label13.TabIndex = 2;
            this.label13.Text = "ID карты";
            // 
            // l_Customer_Card
            // 
            this.l_Customer_Card.AutoSize = true;
            this.l_Customer_Card.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Customer_Card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Customer_Card.Font = new System.Drawing.Font("Arial", 41.25F, System.Drawing.FontStyle.Bold);
            this.l_Customer_Card.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.l_Customer_Card.Location = new System.Drawing.Point(50, 171);
            this.l_Customer_Card.Margin = new System.Windows.Forms.Padding(50, 0, 180, 0);
            this.l_Customer_Card.Name = "l_Customer_Card";
            this.l_Customer_Card.Size = new System.Drawing.Size(223, 37);
            this.l_Customer_Card.TabIndex = 3;
            this.l_Customer_Card.Text = "00040127";
            this.l_Customer_Card.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.l_Customer_Card.TextChanged += new System.EventHandler(this.l_Customer_Card_TextChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackgroundImage = global::iikoCardClients.Properties.Resources.background_up;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tl_BackGround.SetColumnSpan(this.tableLayoutPanel4, 3);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tl_BackGround.SetRowSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.41613F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.44301F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.732874F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.502021F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.90597F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1020, 338);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::iikoCardClients.Properties.Resources.background_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(105, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel4.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(249, 179);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(367, 61);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel4.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(650, 179);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(535, 97);
            this.label6.TabIndex = 0;
            this.label6.Text = "ПРОВЕРКА";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 60F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(482, 97);
            this.label7.TabIndex = 1;
            this.label7.Text = "БАЛАНСА";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(3, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 41.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label8.Location = new System.Drawing.Point(3, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(594, 132);
            this.label8.TabIndex = 2;
            this.label8.Text = "Приложите карту к терминалу";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.BackgroundImage = global::iikoCardClients.Properties.Resources.background_info;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel4.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.98843F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.2144F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.79717F));
            this.tableLayoutPanel5.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.pb_info_logo, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(102, 264);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(816, 74);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Font = new System.Drawing.Font("Verdana", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label10.Location = new System.Drawing.Point(50, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(398, 31);
            this.label10.TabIndex = 0;
            this.label10.Text = "Владелец";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Font = new System.Drawing.Font("Verdana", 18.75F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label11.Location = new System.Drawing.Point(448, 43);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(279, 31);
            this.label11.TabIndex = 1;
            this.label11.Text = "Баланс / Рублей";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pb_info_logo
            // 
            this.pb_info_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_info_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_info_logo.BackgroundImage = global::iikoCardClients.Properties.Resources.info_logo_error;
            this.pb_info_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_info_logo.Location = new System.Drawing.Point(730, 29);
            this.pb_info_logo.Name = "pb_info_logo";
            this.pb_info_logo.Size = new System.Drawing.Size(42, 42);
            this.pb_info_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_info_logo.TabIndex = 2;
            this.pb_info_logo.TabStop = false;
            this.pb_info_logo.Click += new System.EventHandler(this.pb_info_logo_Click);
            // 
            // pb_info_field
            // 
            this.pb_info_field.BackColor = System.Drawing.Color.Transparent;
            this.pb_info_field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_info_field.InitialImage = null;
            this.pb_info_field.Location = new System.Drawing.Point(102, 592);
            this.pb_info_field.Margin = new System.Windows.Forms.Padding(0);
            this.pb_info_field.Name = "pb_info_field";
            this.pb_info_field.Size = new System.Drawing.Size(816, 70);
            this.pb_info_field.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_info_field.TabIndex = 2;
            this.pb_info_field.TabStop = false;
            // 
            // FormBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1020, 707);
            this.Controls.Add(this.tl_BackGround);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "FormBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBalance_FormClosed);
            this.tl_BackGround.ResumeLayout(false);
            this.tl_BackGround.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_settings;
        private System.Windows.Forms.Timer timer_readerConnection;
        private System.Windows.Forms.TableLayoutPanel tl_BackGround;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pb_info_logo;
        private System.Windows.Forms.PictureBox pb_info_field;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label l_Customer_Fname;
        private System.Windows.Forms.Label l_Customer_Sname;
        private System.Windows.Forms.Label l_Customer_Balance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label l_Customer_Card;
    }
}