namespace API_Client
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.llUsers = new System.Windows.Forms.LinkLabel();
            this.dgwMain = new System.Windows.Forms.DataGridView();
            this.panelBotom = new System.Windows.Forms.Panel();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.nextPage = new System.Windows.Forms.Button();
            this.prevPage = new System.Windows.Forms.Button();
            this.PanelUserDetales = new System.Windows.Forms.Panel();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbGeender = new System.Windows.Forms.ComboBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).BeginInit();
            this.panelBotom.SuspendLayout();
            this.PanelUserDetales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnAddNew);
            this.panelTop.Controls.Add(this.llUsers);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.MaximumSize = new System.Drawing.Size(0, 30);
            this.panelTop.MinimumSize = new System.Drawing.Size(0, 30);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 30);
            this.panelTop.TabIndex = 0;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(713, 4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "button1";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // llUsers
            // 
            this.llUsers.AutoSize = true;
            this.llUsers.Location = new System.Drawing.Point(12, 9);
            this.llUsers.Name = "llUsers";
            this.llUsers.Size = new System.Drawing.Size(35, 15);
            this.llUsers.TabIndex = 1;
            this.llUsers.TabStop = true;
            this.llUsers.Text = "Users";
            this.llUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dgwMain
            // 
            this.dgwMain.AllowUserToAddRows = false;
            this.dgwMain.AllowUserToDeleteRows = false;
            this.dgwMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwMain.Location = new System.Drawing.Point(0, 84);
            this.dgwMain.Name = "dgwMain";
            this.dgwMain.RowHeadersVisible = false;
            this.dgwMain.RowTemplate.Height = 25;
            this.dgwMain.Size = new System.Drawing.Size(800, 333);
            this.dgwMain.TabIndex = 1;
            this.dgwMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwMain_CellContentClick);
            // 
            // panelBotom
            // 
            this.panelBotom.Controls.Add(this.lblCurrentPage);
            this.panelBotom.Controls.Add(this.nextPage);
            this.panelBotom.Controls.Add(this.prevPage);
            this.panelBotom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotom.Location = new System.Drawing.Point(0, 417);
            this.panelBotom.Name = "panelBotom";
            this.panelBotom.Size = new System.Drawing.Size(800, 33);
            this.panelBotom.TabIndex = 2;
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(363, 10);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(61, 15);
            this.lblCurrentPage.TabIndex = 2;
            this.lblCurrentPage.Text = "Page num";
            // 
            // nextPage
            // 
            this.nextPage.Location = new System.Drawing.Point(430, 6);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(75, 23);
            this.nextPage.TabIndex = 1;
            this.nextPage.Text = "Next";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // prevPage
            // 
            this.prevPage.Location = new System.Drawing.Point(282, 6);
            this.prevPage.Name = "prevPage";
            this.prevPage.Size = new System.Drawing.Size(75, 23);
            this.prevPage.TabIndex = 0;
            this.prevPage.Text = "Previous";
            this.prevPage.UseVisualStyleBackColor = true;
            this.prevPage.Click += new System.EventHandler(this.prevPage_Click);
            // 
            // PanelUserDetales
            // 
            this.PanelUserDetales.Controls.Add(this.btnSaveUser);
            this.PanelUserDetales.Controls.Add(this.label4);
            this.PanelUserDetales.Controls.Add(this.label3);
            this.PanelUserDetales.Controls.Add(this.label2);
            this.PanelUserDetales.Controls.Add(this.label1);
            this.PanelUserDetales.Controls.Add(this.cbStatus);
            this.PanelUserDetales.Controls.Add(this.cbGeender);
            this.PanelUserDetales.Controls.Add(this.tbEmail);
            this.PanelUserDetales.Controls.Add(this.tbName);
            this.PanelUserDetales.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelUserDetales.Location = new System.Drawing.Point(0, 30);
            this.PanelUserDetales.Name = "PanelUserDetales";
            this.PanelUserDetales.Size = new System.Drawing.Size(800, 54);
            this.PanelUserDetales.TabIndex = 1;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(665, 8);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(123, 36);
            this.btnSaveUser.TabIndex = 10;
            this.btnSaveUser.Text = "Save changes";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gender";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(532, 21);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(127, 23);
            this.cbStatus.TabIndex = 5;
            // 
            // cbGeender
            // 
            this.cbGeender.FormattingEnabled = true;
            this.cbGeender.Location = new System.Drawing.Point(405, 21);
            this.cbGeender.Name = "cbGeender";
            this.cbGeender.Size = new System.Drawing.Size(127, 23);
            this.cbGeender.TabIndex = 4;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(160, 21);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(245, 23);
            this.tbEmail.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 21);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(142, 23);
            this.tbName.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgwMain);
            this.Controls.Add(this.PanelUserDetales);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBotom);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).EndInit();
            this.panelBotom.ResumeLayout(false);
            this.panelBotom.PerformLayout();
            this.PanelUserDetales.ResumeLayout(false);
            this.PanelUserDetales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelTop;
        private DataGridView dgwMain;
        private Panel panelBotom;
        private LinkLabel llUsers;
        private Panel PanelUserDetales;
        private Label lblCurrentPage;
        private Button nextPage;
        private Button prevPage;
        private BindingSource bsMain;
        private TextBox tbName;
        private Button btnSaveUser;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbStatus;
        private ComboBox cbGeender;
        private TextBox tbEmail;
        private Button btnAddNew;
    }
}