namespace iikoCardClients
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pb_load = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_CreateCustomer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_NameCustomer = new System.Windows.Forms.TextBox();
            this.tb_CardCustomer = new System.Windows.Forms.TextBox();
            this.cb_OwerwriteName = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_RefreshDataBiz = new System.Windows.Forms.Button();
            this.btn_NewCategory = new System.Windows.Forms.Button();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.btn_UploadCustomers = new System.Windows.Forms.Button();
            this.cb_organizations = new System.Windows.Forms.ComboBox();
            this.cb_Categories = new System.Windows.Forms.ComboBox();
            this.cb_CorporateNutritions = new System.Windows.Forms.ComboBox();
            this.tb_CustomersBalance = new System.Windows.Forms.TextBox();
            this.tb_OpenFile = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_csv = new System.Windows.Forms.RadioButton();
            this.rb_excel = new System.Windows.Forms.RadioButton();
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_ManagerCard = new System.Windows.Forms.CheckBox();
            this.tb_rule = new System.Windows.Forms.TextBox();
            this.btn_SaveAPI = new System.Windows.Forms.Button();
            this.tb_LoginAPI = new System.Windows.Forms.TextBox();
            this.tb_PasswordAPI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_loadReport = new System.Windows.Forms.PictureBox();
            this.tb_fileTabNumber = new System.Windows.Forms.TextBox();
            this.btn_fileTabNumber = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_fileReport = new System.Windows.Forms.TextBox();
            this.btn_fileReport = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_load)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_loadReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pb_load);
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(556, 392);
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
            this.pb_load.Size = new System.Drawing.Size(550, 36);
            this.pb_load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_load.TabIndex = 24;
            this.pb_load.TabStop = false;
            this.pb_load.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btn_CreateCustomer, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tb_NameCustomer, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.tb_CardCustomer, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.cb_OwerwriteName, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_RefreshDataBiz, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_NewCategory, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_OpenFile, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.btn_UploadCustomers, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.cb_organizations, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cb_Categories, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cb_CorporateNutritions, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tb_CustomersBalance, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tb_OpenFile, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(550, 386);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 37);
            this.label13.TabIndex = 18;
            this.label13.Text = "Файл импорта";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_CreateCustomer
            // 
            this.btn_CreateCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CreateCustomer.Location = new System.Drawing.Point(385, 263);
            this.btn_CreateCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CreateCustomer.Name = "btn_CreateCustomer";
            this.tableLayoutPanel2.SetRowSpan(this.btn_CreateCustomer, 2);
            this.btn_CreateCustomer.Size = new System.Drawing.Size(161, 56);
            this.btn_CreateCustomer.TabIndex = 22;
            this.btn_CreateCustomer.Text = "Добавить одного гостя";
            this.btn_CreateCustomer.UseVisualStyleBackColor = true;
            this.btn_CreateCustomer.Click += new System.EventHandler(this.btn_CreateCustomer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "Организация";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_NameCustomer
            // 
            this.tb_NameCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_NameCustomer.Location = new System.Drawing.Point(117, 262);
            this.tb_NameCustomer.Name = "tb_NameCustomer";
            this.tb_NameCustomer.Size = new System.Drawing.Size(261, 26);
            this.tb_NameCustomer.TabIndex = 20;
            // 
            // tb_CardCustomer
            // 
            this.tb_CardCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_CardCustomer.Location = new System.Drawing.Point(117, 294);
            this.tb_CardCustomer.Name = "tb_CardCustomer";
            this.tb_CardCustomer.Size = new System.Drawing.Size(261, 26);
            this.tb_CardCustomer.TabIndex = 21;
            // 
            // cb_OwerwriteName
            // 
            this.cb_OwerwriteName.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.cb_OwerwriteName, 3);
            this.cb_OwerwriteName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_OwerwriteName.Location = new System.Drawing.Point(3, 171);
            this.cb_OwerwriteName.Name = "cb_OwerwriteName";
            this.cb_OwerwriteName.Size = new System.Drawing.Size(544, 23);
            this.cb_OwerwriteName.TabIndex = 26;
            this.cb_OwerwriteName.Text = "Перезаписать имена, используя текущую выгрузку";
            this.cb_OwerwriteName.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 33);
            this.label6.TabIndex = 6;
            this.label6.Text = "Категории";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "Кор. пит.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 32);
            this.label9.TabIndex = 18;
            this.label9.Text = "ФИО гостя";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 32);
            this.label10.TabIndex = 19;
            this.label10.Text = "Карта гостя";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 32);
            this.label8.TabIndex = 13;
            this.label8.Text = "Баланс";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_RefreshDataBiz
            // 
            this.btn_RefreshDataBiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_RefreshDataBiz.Location = new System.Drawing.Point(384, 3);
            this.btn_RefreshDataBiz.Name = "btn_RefreshDataBiz";
            this.btn_RefreshDataBiz.Size = new System.Drawing.Size(163, 27);
            this.btn_RefreshDataBiz.TabIndex = 9;
            this.btn_RefreshDataBiz.Text = "Получить данные";
            this.btn_RefreshDataBiz.UseVisualStyleBackColor = true;
            this.btn_RefreshDataBiz.Click += new System.EventHandler(this.btn_RefreshDataBiz_Click);
            // 
            // btn_NewCategory
            // 
            this.btn_NewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_NewCategory.Location = new System.Drawing.Point(384, 36);
            this.btn_NewCategory.Name = "btn_NewCategory";
            this.btn_NewCategory.Size = new System.Drawing.Size(163, 27);
            this.btn_NewCategory.TabIndex = 12;
            this.btn_NewCategory.Text = "Создать новую";
            this.btn_NewCategory.UseVisualStyleBackColor = true;
            this.btn_NewCategory.Click += new System.EventHandler(this.btn_NewCategory_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_OpenFile.Location = new System.Drawing.Point(385, 135);
            this.btn_OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(161, 29);
            this.btn_OpenFile.TabIndex = 16;
            this.btn_OpenFile.Text = "Открыть";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_UploadCustomers
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btn_UploadCustomers, 3);
            this.btn_UploadCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_UploadCustomers.Location = new System.Drawing.Point(4, 206);
            this.btn_UploadCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UploadCustomers.Name = "btn_UploadCustomers";
            this.btn_UploadCustomers.Size = new System.Drawing.Size(542, 29);
            this.btn_UploadCustomers.TabIndex = 17;
            this.btn_UploadCustomers.Text = "Выгрузить";
            this.btn_UploadCustomers.UseVisualStyleBackColor = true;
            this.btn_UploadCustomers.Click += new System.EventHandler(this.btn_UploadCustomers_Click);
            // 
            // cb_organizations
            // 
            this.cb_organizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_organizations.FormattingEnabled = true;
            this.cb_organizations.Location = new System.Drawing.Point(117, 3);
            this.cb_organizations.Name = "cb_organizations";
            this.cb_organizations.Size = new System.Drawing.Size(261, 27);
            this.cb_organizations.TabIndex = 8;
            // 
            // cb_Categories
            // 
            this.cb_Categories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Categories.FormattingEnabled = true;
            this.cb_Categories.Location = new System.Drawing.Point(117, 36);
            this.cb_Categories.Name = "cb_Categories";
            this.cb_Categories.Size = new System.Drawing.Size(261, 27);
            this.cb_Categories.TabIndex = 10;
            // 
            // cb_CorporateNutritions
            // 
            this.cb_CorporateNutritions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_CorporateNutritions.FormattingEnabled = true;
            this.cb_CorporateNutritions.Location = new System.Drawing.Point(117, 69);
            this.cb_CorporateNutritions.Name = "cb_CorporateNutritions";
            this.cb_CorporateNutritions.Size = new System.Drawing.Size(261, 27);
            this.cb_CorporateNutritions.TabIndex = 11;
            // 
            // tb_CustomersBalance
            // 
            this.tb_CustomersBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_CustomersBalance.Location = new System.Drawing.Point(117, 102);
            this.tb_CustomersBalance.Name = "tb_CustomersBalance";
            this.tb_CustomersBalance.Size = new System.Drawing.Size(261, 26);
            this.tb_CustomersBalance.TabIndex = 14;
            this.tb_CustomersBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_CustomersBalance_KeyPress);
            // 
            // tb_OpenFile
            // 
            this.tb_OpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_OpenFile.Location = new System.Drawing.Point(118, 135);
            this.tb_OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.tb_OpenFile.Name = "tb_OpenFile";
            this.tb_OpenFile.ReadOnly = true;
            this.tb_OpenFile.Size = new System.Drawing.Size(259, 26);
            this.tb_OpenFile.TabIndex = 15;
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
            this.tabPage1.Size = new System.Drawing.Size(556, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Преобразование";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 424);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(556, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btn_SaveAPI, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.tb_rule, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tb_LoginAPI, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.cb_ManagerCard, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tb_PasswordAPI, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(550, 386);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // cb_ManagerCard
            // 
            this.cb_ManagerCard.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.cb_ManagerCard, 2);
            this.cb_ManagerCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_ManagerCard.Enabled = false;
            this.cb_ManagerCard.Location = new System.Drawing.Point(3, 67);
            this.cb_ManagerCard.Name = "cb_ManagerCard";
            this.cb_ManagerCard.Size = new System.Drawing.Size(544, 23);
            this.cb_ManagerCard.TabIndex = 10;
            this.cb_ManagerCard.Text = "Запускать принудительно менеджер карт";
            this.cb_ManagerCard.UseVisualStyleBackColor = true;
            // 
            // tb_rule
            // 
            this.tb_rule.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_rule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.tb_rule, 2);
            this.tb_rule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_rule.Location = new System.Drawing.Point(3, 96);
            this.tb_rule.Multiline = true;
            this.tb_rule.Name = "tb_rule";
            this.tb_rule.ReadOnly = true;
            this.tb_rule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_rule.Size = new System.Drawing.Size(544, 123);
            this.tb_rule.TabIndex = 11;
            this.tb_rule.Text = resources.GetString("tb_rule.Text");
            // 
            // btn_SaveAPI
            // 
            this.btn_SaveAPI.AutoSize = true;
            this.btn_SaveAPI.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_SaveAPI.Location = new System.Drawing.Point(400, 354);
            this.btn_SaveAPI.Name = "btn_SaveAPI";
            this.btn_SaveAPI.Size = new System.Drawing.Size(147, 29);
            this.btn_SaveAPI.TabIndex = 9;
            this.btn_SaveAPI.Text = "Сохранить данные";
            this.btn_SaveAPI.UseVisualStyleBackColor = true;
            this.btn_SaveAPI.Click += new System.EventHandler(this.btn_SaveAPI_Click);
            // 
            // tb_LoginAPI
            // 
            this.tb_LoginAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_LoginAPI.Location = new System.Drawing.Point(96, 3);
            this.tb_LoginAPI.Name = "tb_LoginAPI";
            this.tb_LoginAPI.Size = new System.Drawing.Size(451, 26);
            this.tb_LoginAPI.TabIndex = 7;
            // 
            // tb_PasswordAPI
            // 
            this.tb_PasswordAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_PasswordAPI.Location = new System.Drawing.Point(96, 35);
            this.tb_PasswordAPI.Name = "tb_PasswordAPI";
            this.tb_PasswordAPI.PasswordChar = '*';
            this.tb_PasswordAPI.Size = new System.Drawing.Size(451, 26);
            this.tb_PasswordAPI.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Логин API";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Пароль API";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(556, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Отчеты";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pb_loadReport, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tb_fileTabNumber, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_fileTabNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tb_fileReport, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_fileReport, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_create, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 386);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pb_loadReport
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pb_loadReport, 2);
            this.pb_loadReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_loadReport.Enabled = false;
            this.pb_loadReport.Image = ((System.Drawing.Image)(resources.GetObject("pb_loadReport.Image")));
            this.pb_loadReport.Location = new System.Drawing.Point(3, 347);
            this.pb_loadReport.Name = "pb_loadReport";
            this.pb_loadReport.Size = new System.Drawing.Size(544, 36);
            this.pb_loadReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_loadReport.TabIndex = 25;
            this.pb_loadReport.TabStop = false;
            this.pb_loadReport.Visible = false;
            // 
            // tb_fileTabNumber
            // 
            this.tb_fileTabNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_fileTabNumber.Location = new System.Drawing.Point(3, 22);
            this.tb_fileTabNumber.Name = "tb_fileTabNumber";
            this.tb_fileTabNumber.ReadOnly = true;
            this.tb_fileTabNumber.Size = new System.Drawing.Size(434, 26);
            this.tb_fileTabNumber.TabIndex = 0;
            // 
            // btn_fileTabNumber
            // 
            this.btn_fileTabNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_fileTabNumber.Location = new System.Drawing.Point(443, 22);
            this.btn_fileTabNumber.Name = "btn_fileTabNumber";
            this.btn_fileTabNumber.Size = new System.Drawing.Size(104, 26);
            this.btn_fileTabNumber.TabIndex = 1;
            this.btn_fileTabNumber.Text = "Выбрать";
            this.btn_fileTabNumber.UseVisualStyleBackColor = true;
            this.btn_fileTabNumber.Click += new System.EventHandler(this.btn_fileTabNumber_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(434, 19);
            this.label11.TabIndex = 2;
            this.label11.Text = "Выберите файл с табельными номерами";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(434, 19);
            this.label12.TabIndex = 3;
            this.label12.Text = "Выберите выгруженный отчет";
            // 
            // tb_fileReport
            // 
            this.tb_fileReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_fileReport.Location = new System.Drawing.Point(3, 73);
            this.tb_fileReport.Name = "tb_fileReport";
            this.tb_fileReport.ReadOnly = true;
            this.tb_fileReport.Size = new System.Drawing.Size(434, 26);
            this.tb_fileReport.TabIndex = 4;
            // 
            // btn_fileReport
            // 
            this.btn_fileReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_fileReport.Location = new System.Drawing.Point(443, 73);
            this.btn_fileReport.Name = "btn_fileReport";
            this.btn_fileReport.Size = new System.Drawing.Size(104, 26);
            this.btn_fileReport.TabIndex = 5;
            this.btn_fileReport.Text = "Выбрать";
            this.btn_fileReport.UseVisualStyleBackColor = true;
            this.btn_fileReport.Click += new System.EventHandler(this.btn_fileReport_Click);
            // 
            // btn_create
            // 
            this.btn_create.AutoSize = true;
            this.btn_create.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_create.Location = new System.Drawing.Point(3, 105);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(434, 29);
            this.btn_create.TabIndex = 6;
            this.btn_create.Text = "Сформировать";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(564, 424);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iikoCardClients";
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_load)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_loadReport)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tb_fileTabNumber;
        private System.Windows.Forms.Button btn_fileTabNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_fileReport;
        private System.Windows.Forms.Button btn_fileReport;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cb_OwerwriteName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox tb_rule;
        private System.Windows.Forms.PictureBox pb_loadReport;
    }
}

