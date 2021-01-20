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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pb_info_field = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.pb_info_logo = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.l_Customer_Balance = new System.Windows.Forms.Label();
            this.l_Customer_Fname = new System.Windows.Forms.Label();
            this.l_Customer_Card = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_field)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_logo)).BeginInit();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.BackgroundImage = global::iikoCardClients.Properties.Resources.background_down;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.04688F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.83594F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.pb_info_field, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.74312F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.256881F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 768);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::iikoCardClients.Properties.Resources.background_logo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(105, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox2, 4);
            this.pictureBox2.Size = new System.Drawing.Size(230, 202);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Verdana", 50F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(368, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "ПРОВЕРКА";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Verdana", 50F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(368, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(549, 80);
            this.label2.TabIndex = 2;
            this.label2.Text = "БАЛАНСА";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Verdana", 24F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(348, 230);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(569, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Приложите карту к считывателю";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pb_info_field
            // 
            this.pb_info_field.BackColor = System.Drawing.Color.Transparent;
            this.pb_info_field.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.SetColumnSpan(this.pb_info_field, 2);
            this.pb_info_field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_info_field.InitialImage = null;
            this.pb_info_field.Location = new System.Drawing.Point(102, 672);
            this.pb_info_field.Margin = new System.Windows.Forms.Padding(0);
            this.pb_info_field.Name = "pb_info_field";
            this.pb_info_field.Size = new System.Drawing.Size(818, 60);
            this.pb_info_field.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_info_field.TabIndex = 2;
            this.pb_info_field.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.57243F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.42757F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pb_info_logo, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.l_Customer_Balance, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.l_Customer_Fname, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.l_Customer_Card, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(105, 281);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(812, 383);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Verdana", 18.75F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label13.Location = new System.Drawing.Point(30, 243);
            this.label13.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(421, 40);
            this.label13.TabIndex = 2;
            this.label13.Text = "ID карты";
            // 
            // pb_info_logo
            // 
            this.pb_info_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_info_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_info_logo.BackgroundImage = global::iikoCardClients.Properties.Resources.info_logo_error;
            this.pb_info_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_info_logo.Location = new System.Drawing.Point(712, 35);
            this.pb_info_logo.Name = "pb_info_logo";
            this.pb_info_logo.Size = new System.Drawing.Size(42, 42);
            this.pb_info_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_info_logo.TabIndex = 2;
            this.pb_info_logo.TabStop = false;
            this.pb_info_logo.Click += new System.EventHandler(this.pb_info_logo_Click);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Verdana", 18.75F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label11.Location = new System.Drawing.Point(451, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 80);
            this.label11.TabIndex = 1;
            this.label11.Text = "Баланс / Рублей";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Verdana", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label10.Location = new System.Drawing.Point(30, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(421, 80);
            this.label10.TabIndex = 0;
            this.label10.Text = "Владелец";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // l_Customer_Balance
            // 
            this.l_Customer_Balance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Customer_Balance.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Bold);
            this.l_Customer_Balance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(180)))), ((int)(((byte)(9)))));
            this.l_Customer_Balance.Location = new System.Drawing.Point(451, 85);
            this.l_Customer_Balance.Margin = new System.Windows.Forms.Padding(0);
            this.l_Customer_Balance.Name = "l_Customer_Balance";
            this.l_Customer_Balance.Size = new System.Drawing.Size(258, 158);
            this.l_Customer_Balance.TabIndex = 1;
            this.l_Customer_Balance.Text = "8650";
            this.l_Customer_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_Customer_Fname
            // 
            this.l_Customer_Fname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Customer_Fname.Font = new System.Drawing.Font("Arial", 34F);
            this.l_Customer_Fname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(200)))), ((int)(((byte)(9)))));
            this.l_Customer_Fname.Location = new System.Drawing.Point(30, 85);
            this.l_Customer_Fname.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.l_Customer_Fname.Name = "l_Customer_Fname";
            this.l_Customer_Fname.Size = new System.Drawing.Size(421, 158);
            this.l_Customer_Fname.TabIndex = 0;
            this.l_Customer_Fname.Text = "Федченко Альберт Юрьевич";
            this.l_Customer_Fname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Customer_Card
            // 
            this.l_Customer_Card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Customer_Card.Font = new System.Drawing.Font("Arial", 41.25F, System.Drawing.FontStyle.Bold);
            this.l_Customer_Card.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.l_Customer_Card.Location = new System.Drawing.Point(30, 283);
            this.l_Customer_Card.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.l_Customer_Card.Name = "l_Customer_Card";
            this.l_Customer_Card.Size = new System.Drawing.Size(421, 100);
            this.l_Customer_Card.TabIndex = 3;
            this.l_Customer_Card.Text = "00040127";
            this.l_Customer_Card.TextChanged += new System.EventHandler(this.l_Customer_Card_TextChanged);
            // 
            // FormBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "FormBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBalance_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_field)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_info_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_settings;
        private System.Windows.Forms.Timer timer_readerConnection;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pb_info_logo;
        private System.Windows.Forms.PictureBox pb_info_field;
        private System.Windows.Forms.Label l_Customer_Fname;
        private System.Windows.Forms.Label l_Customer_Balance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label l_Customer_Card;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}