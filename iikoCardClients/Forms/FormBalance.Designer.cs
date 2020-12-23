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
            this.label4 = new System.Windows.Forms.Label();
            this.l_Description = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.l_stat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.l_Name = new System.Windows.Forms.Label();
            this.l_Balance = new System.Windows.Forms.Label();
            this.l_Card = new System.Windows.Forms.Label();
            this.timer_settings = new System.Windows.Forms.Timer(this.components);
            this.timer_readerConnection = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "Доп информация:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // l_Description
            // 
            this.l_Description.AutoSize = true;
            this.l_Description.Dock = System.Windows.Forms.DockStyle.Left;
            this.l_Description.Location = new System.Drawing.Point(275, 0);
            this.l_Description.Name = "l_Description";
            this.l_Description.Size = new System.Drawing.Size(202, 37);
            this.l_Description.TabIndex = 6;
            this.l_Description.Text = "l_Description";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(616, 37);
            this.label3.TabIndex = 9;
            this.label3.Text = "Баланс карты";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(616, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "ФИО владельца карты";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(602, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Прокатайте карту для проверки баланса";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.l_Description, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 434);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 37);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.l_stat, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.l_Name, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.l_Balance, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.l_Card, 1, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(798, 471);
            this.tableLayoutPanel2.TabIndex = 10;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // l_stat
            // 
            this.l_stat.AutoSize = true;
            this.l_stat.BackColor = System.Drawing.Color.Lime;
            this.l_stat.Dock = System.Windows.Forms.DockStyle.Right;
            this.l_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.l_stat.Location = new System.Drawing.Point(755, 0);
            this.l_stat.MaximumSize = new System.Drawing.Size(40, 40);
            this.l_stat.MinimumSize = new System.Drawing.Size(40, 40);
            this.l_stat.Name = "l_stat";
            this.l_stat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.l_stat.Size = new System.Drawing.Size(40, 40);
            this.l_stat.TabIndex = 1;
            this.l_stat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(616, 37);
            this.label5.TabIndex = 13;
            this.label5.Text = "Карта сотрудника";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Name
            // 
            this.l_Name.AutoSize = true;
            this.l_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Name.Location = new System.Drawing.Point(91, 177);
            this.l_Name.Name = "l_Name";
            this.l_Name.Size = new System.Drawing.Size(616, 39);
            this.l_Name.TabIndex = 15;
            this.l_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Balance
            // 
            this.l_Balance.AutoSize = true;
            this.l_Balance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Balance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Balance.Location = new System.Drawing.Point(91, 253);
            this.l_Balance.Name = "l_Balance";
            this.l_Balance.Size = new System.Drawing.Size(616, 39);
            this.l_Balance.TabIndex = 16;
            this.l_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Card
            // 
            this.l_Card.AutoSize = true;
            this.l_Card.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Card.Location = new System.Drawing.Point(91, 329);
            this.l_Card.Name = "l_Card";
            this.l_Card.Size = new System.Drawing.Size(616, 39);
            this.l_Card.TabIndex = 17;
            this.l_Card.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Card.TextChanged += new System.EventHandler(this.l_Card_TextChanged);
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
            // FormBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(798, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "FormBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBalance_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_Description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer_settings;
        private System.Windows.Forms.Label l_stat;
        private System.Windows.Forms.Label l_Name;
        private System.Windows.Forms.Label l_Balance;
        private System.Windows.Forms.Label l_Card;
        private System.Windows.Forms.Timer timer_readerConnection;
    }
}