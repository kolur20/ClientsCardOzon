namespace iikoCardClients
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pb_load = new System.Windows.Forms.PictureBox();
            this.btn_CreateCustomer = new System.Windows.Forms.Button();
            this.tb_CardCustomer = new System.Windows.Forms.TextBox();
            this.tb_NameCustomer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_UploadCustomers = new System.Windows.Forms.Button();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.tb_OpenFile = new System.Windows.Forms.TextBox();
            this.tb_CustomersBalance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_NewCategory = new System.Windows.Forms.Button();
            this.cb_CorporateNutritions = new System.Windows.Forms.ComboBox();
            this.cb_Categories = new System.Windows.Forms.ComboBox();
            this.btn_RefreshDataBiz = new System.Windows.Forms.Button();
            this.cb_organizations = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.tb_balance = new System.Windows.Forms.TextBox();
            this.tb_group = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Open = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_isDeleted = new System.Windows.Forms.CheckBox();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cb_ManagerCard = new System.Windows.Forms.CheckBox();
            this.btn_SaveAPI = new System.Windows.Forms.Button();
            this.tb_PasswordAPI = new System.Windows.Forms.TextBox();
            this.tb_LoginAPI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_excel = new System.Windows.Forms.RadioButton();
            this.rb_csv = new System.Windows.Forms.RadioButton();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_load)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pb_load);
            this.tabPage2.Controls.Add(this.btn_CreateCustomer);
            this.tabPage2.Controls.Add(this.tb_CardCustomer);
            this.tabPage2.Controls.Add(this.tb_NameCustomer);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btn_UploadCustomers);
            this.tabPage2.Controls.Add(this.btn_OpenFile);
            this.tabPage2.Controls.Add(this.tb_OpenFile);
            this.tabPage2.Controls.Add(this.tb_CustomersBalance);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btn_NewCategory);
            this.tabPage2.Controls.Add(this.cb_CorporateNutritions);
            this.tabPage2.Controls.Add(this.cb_Categories);
            this.tabPage2.Controls.Add(this.btn_RefreshDataBiz);
            this.tabPage2.Controls.Add(this.cb_organizations);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(510, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Выгрузка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pb_load
            // 
            this.pb_load.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb_load.Enabled = false;
            this.pb_load.Image = ((System.Drawing.Image)(resources.GetObject("pb_load.Image")));
            this.pb_load.Location = new System.Drawing.Point(3, 353);
            this.pb_load.Name = "pb_load";
            this.pb_load.Size = new System.Drawing.Size(504, 36);
            this.pb_load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_load.TabIndex = 24;
            this.pb_load.TabStop = false;
            this.pb_load.Visible = false;
            // 
            // btn_CreateCustomer
            // 
            this.btn_CreateCustomer.Location = new System.Drawing.Point(340, 189);
            this.btn_CreateCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CreateCustomer.Name = "btn_CreateCustomer";
            this.btn_CreateCustomer.Size = new System.Drawing.Size(161, 51);
            this.btn_CreateCustomer.TabIndex = 22;
            this.btn_CreateCustomer.Text = "Добавить одного гостя";
            this.btn_CreateCustomer.UseVisualStyleBackColor = true;
            this.btn_CreateCustomer.Click += new System.EventHandler(this.btn_CreateCustomer_Click);
            // 
            // tb_CardCustomer
            // 
            this.tb_CardCustomer.Location = new System.Drawing.Point(109, 218);
            this.tb_CardCustomer.Name = "tb_CardCustomer";
            this.tb_CardCustomer.Size = new System.Drawing.Size(189, 26);
            this.tb_CardCustomer.TabIndex = 21;
            // 
            // tb_NameCustomer
            // 
            this.tb_NameCustomer.Location = new System.Drawing.Point(109, 186);
            this.tb_NameCustomer.Name = "tb_NameCustomer";
            this.tb_NameCustomer.Size = new System.Drawing.Size(189, 26);
            this.tb_NameCustomer.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "Карта гостя";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "ФИО гостя";
            // 
            // btn_UploadCustomers
            // 
            this.btn_UploadCustomers.Location = new System.Drawing.Point(10, 144);
            this.btn_UploadCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UploadCustomers.Name = "btn_UploadCustomers";
            this.btn_UploadCustomers.Size = new System.Drawing.Size(491, 29);
            this.btn_UploadCustomers.TabIndex = 17;
            this.btn_UploadCustomers.Text = "Выгрузить";
            this.btn_UploadCustomers.UseVisualStyleBackColor = true;
            this.btn_UploadCustomers.Click += new System.EventHandler(this.btn_UploadCustomers_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Location = new System.Drawing.Point(401, 109);
            this.btn_OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(100, 29);
            this.btn_OpenFile.TabIndex = 16;
            this.btn_OpenFile.Text = "Открыть";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // tb_OpenFile
            // 
            this.tb_OpenFile.Location = new System.Drawing.Point(190, 111);
            this.tb_OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.tb_OpenFile.Name = "tb_OpenFile";
            this.tb_OpenFile.ReadOnly = true;
            this.tb_OpenFile.Size = new System.Drawing.Size(203, 26);
            this.tb_OpenFile.TabIndex = 15;
            // 
            // tb_CustomersBalance
            // 
            this.tb_CustomersBalance.Location = new System.Drawing.Point(71, 111);
            this.tb_CustomersBalance.Name = "tb_CustomersBalance";
            this.tb_CustomersBalance.Size = new System.Drawing.Size(112, 26);
            this.tb_CustomersBalance.TabIndex = 14;
            this.tb_CustomersBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_CustomersBalance_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Баланс";
            // 
            // btn_NewCategory
            // 
            this.btn_NewCategory.Location = new System.Drawing.Point(358, 41);
            this.btn_NewCategory.Name = "btn_NewCategory";
            this.btn_NewCategory.Size = new System.Drawing.Size(144, 27);
            this.btn_NewCategory.TabIndex = 12;
            this.btn_NewCategory.Text = "Создать новую";
            this.btn_NewCategory.UseVisualStyleBackColor = true;
            this.btn_NewCategory.Click += new System.EventHandler(this.btn_NewCategory_Click);
            // 
            // cb_CorporateNutritions
            // 
            this.cb_CorporateNutritions.FormattingEnabled = true;
            this.cb_CorporateNutritions.Location = new System.Drawing.Point(109, 78);
            this.cb_CorporateNutritions.Name = "cb_CorporateNutritions";
            this.cb_CorporateNutritions.Size = new System.Drawing.Size(243, 27);
            this.cb_CorporateNutritions.TabIndex = 11;
            // 
            // cb_Categories
            // 
            this.cb_Categories.FormattingEnabled = true;
            this.cb_Categories.Location = new System.Drawing.Point(109, 41);
            this.cb_Categories.Name = "cb_Categories";
            this.cb_Categories.Size = new System.Drawing.Size(243, 27);
            this.cb_Categories.TabIndex = 10;
            // 
            // btn_RefreshDataBiz
            // 
            this.btn_RefreshDataBiz.Location = new System.Drawing.Point(358, 6);
            this.btn_RefreshDataBiz.Name = "btn_RefreshDataBiz";
            this.btn_RefreshDataBiz.Size = new System.Drawing.Size(144, 27);
            this.btn_RefreshDataBiz.TabIndex = 9;
            this.btn_RefreshDataBiz.Text = "Получить данные";
            this.btn_RefreshDataBiz.UseVisualStyleBackColor = true;
            this.btn_RefreshDataBiz.Click += new System.EventHandler(this.btn_RefreshDataBiz_Click);
            // 
            // cb_organizations
            // 
            this.cb_organizations.FormattingEnabled = true;
            this.cb_organizations.Location = new System.Drawing.Point(109, 6);
            this.cb_organizations.Name = "cb_organizations";
            this.cb_organizations.Size = new System.Drawing.Size(243, 27);
            this.cb_organizations.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Кор. пит.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Категории";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Организация";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tb_file);
            this.tabPage1.Controls.Add(this.tb_balance);
            this.tabPage1.Controls.Add(this.tb_group);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btn_Open);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cb_isDeleted);
            this.tabPage1.Controls.Add(this.btn_Convert);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(510, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Преобразование";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_file
            // 
            this.tb_file.Location = new System.Drawing.Point(7, 7);
            this.tb_file.Margin = new System.Windows.Forms.Padding(4);
            this.tb_file.Name = "tb_file";
            this.tb_file.ReadOnly = true;
            this.tb_file.Size = new System.Drawing.Size(191, 26);
            this.tb_file.TabIndex = 0;
            // 
            // tb_balance
            // 
            this.tb_balance.Location = new System.Drawing.Point(7, 75);
            this.tb_balance.Margin = new System.Windows.Forms.Padding(4);
            this.tb_balance.Name = "tb_balance";
            this.tb_balance.Size = new System.Drawing.Size(148, 26);
            this.tb_balance.TabIndex = 4;
            this.tb_balance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_balance_KeyPress);
            // 
            // tb_group
            // 
            this.tb_group.Location = new System.Drawing.Point(7, 41);
            this.tb_group.Margin = new System.Windows.Forms.Padding(4);
            this.tb_group.Name = "tb_group";
            this.tb_group.Size = new System.Drawing.Size(148, 26);
            this.tb_group.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Баланс гостя";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(206, 7);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(112, 29);
            this.btn_Open.TabIndex = 1;
            this.btn_Open.Text = "Открыть";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Организация";
            // 
            // cb_isDeleted
            // 
            this.cb_isDeleted.AutoSize = true;
            this.cb_isDeleted.Location = new System.Drawing.Point(7, 122);
            this.cb_isDeleted.Name = "cb_isDeleted";
            this.cb_isDeleted.Size = new System.Drawing.Size(247, 23);
            this.cb_isDeleted.TabIndex = 5;
            this.cb_isDeleted.Text = "Данные гости требуют удаления";
            this.cb_isDeleted.UseVisualStyleBackColor = true;
            // 
            // btn_Convert
            // 
            this.btn_Convert.Location = new System.Drawing.Point(366, 131);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(138, 30);
            this.btn_Convert.TabIndex = 6;
            this.btn_Convert.Text = "Конвертировать";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 424);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cb_ManagerCard);
            this.tabPage3.Controls.Add(this.btn_SaveAPI);
            this.tabPage3.Controls.Add(this.tb_PasswordAPI);
            this.tabPage3.Controls.Add(this.tb_LoginAPI);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(510, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cb_ManagerCard
            // 
            this.cb_ManagerCard.AutoSize = true;
            this.cb_ManagerCard.Location = new System.Drawing.Point(13, 87);
            this.cb_ManagerCard.Name = "cb_ManagerCard";
            this.cb_ManagerCard.Size = new System.Drawing.Size(306, 23);
            this.cb_ManagerCard.TabIndex = 10;
            this.cb_ManagerCard.Text = "Запускать принудительно менеджер карт";
            this.cb_ManagerCard.UseVisualStyleBackColor = true;
            // 
            // btn_SaveAPI
            // 
            this.btn_SaveAPI.Location = new System.Drawing.Point(387, 330);
            this.btn_SaveAPI.Name = "btn_SaveAPI";
            this.btn_SaveAPI.Size = new System.Drawing.Size(115, 54);
            this.btn_SaveAPI.TabIndex = 9;
            this.btn_SaveAPI.Text = "Сохранить данные";
            this.btn_SaveAPI.UseVisualStyleBackColor = true;
            this.btn_SaveAPI.Click += new System.EventHandler(this.btn_SaveAPI_Click);
            // 
            // tb_PasswordAPI
            // 
            this.tb_PasswordAPI.Location = new System.Drawing.Point(109, 44);
            this.tb_PasswordAPI.Name = "tb_PasswordAPI";
            this.tb_PasswordAPI.PasswordChar = '*';
            this.tb_PasswordAPI.Size = new System.Drawing.Size(189, 26);
            this.tb_PasswordAPI.TabIndex = 8;
            // 
            // tb_LoginAPI
            // 
            this.tb_LoginAPI.Location = new System.Drawing.Point(109, 12);
            this.tb_LoginAPI.Name = "tb_LoginAPI";
            this.tb_LoginAPI.Size = new System.Drawing.Size(189, 26);
            this.tb_LoginAPI.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Пароль API";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Логин API";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_csv);
            this.groupBox1.Controls.Add(this.rb_excel);
            this.groupBox1.Location = new System.Drawing.Point(326, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 105);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Формат файла импорта";
            // 
            // rb_excel
            // 
            this.rb_excel.AutoSize = true;
            this.rb_excel.Checked = true;
            this.rb_excel.Location = new System.Drawing.Point(7, 42);
            this.rb_excel.Name = "rb_excel";
            this.rb_excel.Size = new System.Drawing.Size(70, 23);
            this.rb_excel.TabIndex = 0;
            this.rb_excel.TabStop = true;
            this.rb_excel.Text = "xls/xlsx";
            this.rb_excel.UseVisualStyleBackColor = true;
            // 
            // rb_csv
            // 
            this.rb_csv.AutoSize = true;
            this.rb_csv.Location = new System.Drawing.Point(6, 71);
            this.rb_csv.Name = "rb_csv";
            this.rb_csv.Size = new System.Drawing.Size(47, 23);
            this.rb_csv.TabIndex = 1;
            this.rb_csv.Text = "csv";
            this.rb_csv.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 424);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iikoCardClients";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_load)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tb_CustomersBalance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_NewCategory;
        private System.Windows.Forms.ComboBox cb_CorporateNutritions;
        private System.Windows.Forms.ComboBox cb_Categories;
        private System.Windows.Forms.Button btn_RefreshDataBiz;
        private System.Windows.Forms.ComboBox cb_organizations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.TextBox tb_balance;
        private System.Windows.Forms.TextBox tb_group;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_isDeleted;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_CreateCustomer;
        private System.Windows.Forms.TextBox tb_CardCustomer;
        private System.Windows.Forms.TextBox tb_NameCustomer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_UploadCustomers;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.TextBox tb_OpenFile;
        private System.Windows.Forms.PictureBox pb_load;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cb_ManagerCard;
        private System.Windows.Forms.Button btn_SaveAPI;
        private System.Windows.Forms.TextBox tb_PasswordAPI;
        private System.Windows.Forms.TextBox tb_LoginAPI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_csv;
        private System.Windows.Forms.RadioButton rb_excel;
    }
}

