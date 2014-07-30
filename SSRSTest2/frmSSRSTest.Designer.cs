namespace SSRSTest2
{
    partial class frmSSRSTest
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnGetFolderPath = new System.Windows.Forms.Button();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.lblSourcePath = new System.Windows.Forms.Label();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.folderBrowseDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grpCreateFolder = new System.Windows.Forms.GroupBox();
            this.lblFolderList = new System.Windows.Forms.Label();
            this.cboFolderList = new System.Windows.Forms.ComboBox();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtTestInfo = new System.Windows.Forms.TextBox();
            this.btnUpdateDataSource = new System.Windows.Forms.Button();
            this.grpDataSource = new System.Windows.Forms.GroupBox();
            this.txtDataSourceLocation = new System.Windows.Forms.TextBox();
            this.lblDataSourceLocation = new System.Windows.Forms.Label();
            this.btnCreateDataSource = new System.Windows.Forms.Button();
            this.lblDataSourceConnectionString = new System.Windows.Forms.Label();
            this.txtDataSourceName = new System.Windows.Forms.TextBox();
            this.lblDataSourceName = new System.Windows.Forms.Label();
            this.grpDeployReports = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.grpCreateFolder.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.grpDataSource.SuspendLayout();
            this.grpDeployReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(165, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(278, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(278, 645);
            this.txtLog.TabIndex = 4;
            // 
            // btnGetFolderPath
            // 
            this.btnGetFolderPath.Location = new System.Drawing.Point(221, 26);
            this.btnGetFolderPath.Name = "btnGetFolderPath";
            this.btnGetFolderPath.Size = new System.Drawing.Size(19, 20);
            this.btnGetFolderPath.TabIndex = 2;
            this.btnGetFolderPath.Text = "...";
            this.btnGetFolderPath.UseVisualStyleBackColor = true;
            this.btnGetFolderPath.Click += new System.EventHandler(this.btnGetFolderPath_Click);
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(81, 26);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(134, 20);
            this.txtRootPath.TabIndex = 1;
            this.txtRootPath.Text = "C:\\Program Files (x86)\\Voice4net\\";
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(6, 29);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(69, 13);
            this.lblSourcePath.TabIndex = 0;
            this.lblSourcePath.Text = "Source Path:";
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(81, 52);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(75, 23);
            this.btnDeploy.TabIndex = 3;
            this.btnDeploy.Text = "&Upload";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // folderBrowseDlg
            // 
            this.folderBrowseDlg.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(7, 94);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(41, 13);
            this.lblServerName.TabIndex = 5;
            this.lblServerName.Text = "Server:";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(7, 116);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(56, 13);
            this.lblDatabaseName.TabIndex = 7;
            this.lblDatabaseName.Text = "Database:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 139);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(32, 13);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(7, 162);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(66, 91);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(100, 20);
            this.txtServerName.TabIndex = 6;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(66, 113);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(100, 20);
            this.txtDatabaseName.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(66, 136);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(66, 159);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // grpCreateFolder
            // 
            this.grpCreateFolder.Controls.Add(this.lblFolderList);
            this.grpCreateFolder.Controls.Add(this.cboFolderList);
            this.grpCreateFolder.Controls.Add(this.btnCreateFolder);
            this.grpCreateFolder.Controls.Add(this.txtFolderName);
            this.grpCreateFolder.Controls.Add(this.lblFolderName);
            this.grpCreateFolder.Location = new System.Drawing.Point(12, 57);
            this.grpCreateFolder.Name = "grpCreateFolder";
            this.grpCreateFolder.Size = new System.Drawing.Size(260, 125);
            this.grpCreateFolder.TabIndex = 0;
            this.grpCreateFolder.TabStop = false;
            this.grpCreateFolder.Text = "Folders";
            // 
            // lblFolderList
            // 
            this.lblFolderList.AutoSize = true;
            this.lblFolderList.Location = new System.Drawing.Point(11, 34);
            this.lblFolderList.Name = "lblFolderList";
            this.lblFolderList.Size = new System.Drawing.Size(58, 13);
            this.lblFolderList.TabIndex = 0;
            this.lblFolderList.Text = "Folder List:";
            // 
            // cboFolderList
            // 
            this.cboFolderList.FormattingEnabled = true;
            this.cboFolderList.Location = new System.Drawing.Point(81, 31);
            this.cboFolderList.Name = "cboFolderList";
            this.cboFolderList.Size = new System.Drawing.Size(121, 21);
            this.cboFolderList.TabIndex = 1;
            this.cboFolderList.DropDown += new System.EventHandler(this.cboFolderList_DropDown);
            this.cboFolderList.SelectedValueChanged += new System.EventHandler(this.cboFolderList_SelectedValueChanged);
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Location = new System.Drawing.Point(59, 96);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(122, 23);
            this.btnCreateFolder.TabIndex = 4;
            this.btnCreateFolder.Text = "C&reate Folder";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(81, 58);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(100, 20);
            this.txtFolderName.TabIndex = 3;
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Location = new System.Drawing.Point(8, 61);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(67, 13);
            this.lblFolderName.TabIndex = 2;
            this.lblFolderName.Text = "Folder Name";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtTestInfo);
            this.grpInfo.Controls.Add(this.btnUpdateDataSource);
            this.grpInfo.Location = new System.Drawing.Point(13, 515);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(257, 142);
            this.grpInfo.TabIndex = 3;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Info";
            // 
            // txtTestInfo
            // 
            this.txtTestInfo.Location = new System.Drawing.Point(23, 19);
            this.txtTestInfo.Multiline = true;
            this.txtTestInfo.Name = "txtTestInfo";
            this.txtTestInfo.ReadOnly = true;
            this.txtTestInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTestInfo.Size = new System.Drawing.Size(217, 81);
            this.txtTestInfo.TabIndex = 0;
            this.txtTestInfo.Text = "Testing only:\r\n\r\nReport: PromptsList.rdl\r\nChanging existing datasource name to V4" +
    "_SPPS_V6\r\nbefore updating report to use shared data source.\r\n";
            // 
            // btnUpdateDataSource
            // 
            this.btnUpdateDataSource.Location = new System.Drawing.Point(57, 113);
            this.btnUpdateDataSource.Name = "btnUpdateDataSource";
            this.btnUpdateDataSource.Size = new System.Drawing.Size(122, 23);
            this.btnUpdateDataSource.TabIndex = 1;
            this.btnUpdateDataSource.Text = "U&pdate Data Source";
            this.btnUpdateDataSource.UseVisualStyleBackColor = true;
            this.btnUpdateDataSource.Click += new System.EventHandler(this.btnUpdateDataSource_Click);
            // 
            // grpDataSource
            // 
            this.grpDataSource.Controls.Add(this.btnTest);
            this.grpDataSource.Controls.Add(this.txtDataSourceLocation);
            this.grpDataSource.Controls.Add(this.lblDataSourceLocation);
            this.grpDataSource.Controls.Add(this.btnCreateDataSource);
            this.grpDataSource.Controls.Add(this.lblDataSourceConnectionString);
            this.grpDataSource.Controls.Add(this.txtDataSourceName);
            this.grpDataSource.Controls.Add(this.lblDataSourceName);
            this.grpDataSource.Controls.Add(this.lblServerName);
            this.grpDataSource.Controls.Add(this.lblDatabaseName);
            this.grpDataSource.Controls.Add(this.lblUserName);
            this.grpDataSource.Controls.Add(this.txtPassword);
            this.grpDataSource.Controls.Add(this.lblPassword);
            this.grpDataSource.Controls.Add(this.txtUserName);
            this.grpDataSource.Controls.Add(this.txtServerName);
            this.grpDataSource.Controls.Add(this.txtDatabaseName);
            this.grpDataSource.Location = new System.Drawing.Point(12, 188);
            this.grpDataSource.Name = "grpDataSource";
            this.grpDataSource.Size = new System.Drawing.Size(257, 232);
            this.grpDataSource.TabIndex = 1;
            this.grpDataSource.TabStop = false;
            this.grpDataSource.Text = "Data Source";
            // 
            // txtDataSourceLocation
            // 
            this.txtDataSourceLocation.Location = new System.Drawing.Point(130, 40);
            this.txtDataSourceLocation.Name = "txtDataSourceLocation";
            this.txtDataSourceLocation.Size = new System.Drawing.Size(120, 20);
            this.txtDataSourceLocation.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtDataSourceLocation, "Use \"/\" for root.");
            // 
            // lblDataSourceLocation
            // 
            this.lblDataSourceLocation.AutoSize = true;
            this.lblDataSourceLocation.Location = new System.Drawing.Point(9, 43);
            this.lblDataSourceLocation.Name = "lblDataSourceLocation";
            this.lblDataSourceLocation.Size = new System.Drawing.Size(114, 13);
            this.lblDataSourceLocation.TabIndex = 2;
            this.lblDataSourceLocation.Text = "Data Source Location:";
            // 
            // btnCreateDataSource
            // 
            this.btnCreateDataSource.Location = new System.Drawing.Point(128, 203);
            this.btnCreateDataSource.Name = "btnCreateDataSource";
            this.btnCreateDataSource.Size = new System.Drawing.Size(122, 23);
            this.btnCreateDataSource.TabIndex = 13;
            this.btnCreateDataSource.Text = "Create &Data Source";
            this.btnCreateDataSource.UseVisualStyleBackColor = true;
            this.btnCreateDataSource.Click += new System.EventHandler(this.btnCreateDataSource_Click);
            // 
            // lblDataSourceConnectionString
            // 
            this.lblDataSourceConnectionString.AutoSize = true;
            this.lblDataSourceConnectionString.Location = new System.Drawing.Point(9, 75);
            this.lblDataSourceConnectionString.Name = "lblDataSourceConnectionString";
            this.lblDataSourceConnectionString.Size = new System.Drawing.Size(94, 13);
            this.lblDataSourceConnectionString.TabIndex = 4;
            this.lblDataSourceConnectionString.Text = "Connection String:";
            // 
            // txtDataSourceName
            // 
            this.txtDataSourceName.Location = new System.Drawing.Point(116, 13);
            this.txtDataSourceName.Name = "txtDataSourceName";
            this.txtDataSourceName.Size = new System.Drawing.Size(134, 20);
            this.txtDataSourceName.TabIndex = 1;
            // 
            // lblDataSourceName
            // 
            this.lblDataSourceName.AutoSize = true;
            this.lblDataSourceName.Location = new System.Drawing.Point(9, 20);
            this.lblDataSourceName.Name = "lblDataSourceName";
            this.lblDataSourceName.Size = new System.Drawing.Size(101, 13);
            this.lblDataSourceName.TabIndex = 0;
            this.lblDataSourceName.Text = "Data Source Name:";
            // 
            // grpDeployReports
            // 
            this.grpDeployReports.Controls.Add(this.lblSourcePath);
            this.grpDeployReports.Controls.Add(this.btnDeploy);
            this.grpDeployReports.Controls.Add(this.txtRootPath);
            this.grpDeployReports.Controls.Add(this.btnGetFolderPath);
            this.grpDeployReports.Controls.Add(this.btnCancel);
            this.grpDeployReports.Location = new System.Drawing.Point(12, 426);
            this.grpDeployReports.Name = "grpDeployReports";
            this.grpDeployReports.Size = new System.Drawing.Size(257, 83);
            this.grpDeployReports.TabIndex = 2;
            this.grpDeployReports.TabStop = false;
            this.grpDeployReports.Text = "Reports";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(13, 31);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(256, 20);
            this.txtURL.TabIndex = 6;
            this.txtURL.Text = "http://localhost/ReportServer/";
            this.toolTip1.SetToolTip(this.txtURL, "Report Server URL\r\nhttp://localhost/reportserver/");
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(9, 15);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(101, 13);
            this.lblURL.TabIndex = 5;
            this.lblURL.Text = "Report Server URL:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(14, 202);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmSSRSTest
            // 
            this.AcceptButton = this.btnDeploy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 664);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.grpDeployReports);
            this.Controls.Add(this.grpDataSource);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpCreateFolder);
            this.Controls.Add(this.txtLog);
            this.Name = "frmSSRSTest";
            this.Text = "SSRS Manager";
            this.Load += new System.EventHandler(this.frmSSRSTest_Load);
            this.grpCreateFolder.ResumeLayout(false);
            this.grpCreateFolder.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpDataSource.ResumeLayout(false);
            this.grpDataSource.PerformLayout();
            this.grpDeployReports.ResumeLayout(false);
            this.grpDeployReports.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnGetFolderPath;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.FolderBrowserDialog folderBrowseDlg;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grpCreateFolder;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.ComboBox cboFolderList;
        private System.Windows.Forms.Label lblFolderList;
        private System.Windows.Forms.GroupBox grpDataSource;
        private System.Windows.Forms.Label lblDataSourceConnectionString;
        private System.Windows.Forms.TextBox txtDataSourceName;
        private System.Windows.Forms.Label lblDataSourceName;
        private System.Windows.Forms.GroupBox grpDeployReports;
        private System.Windows.Forms.Button btnCreateDataSource;
        private System.Windows.Forms.TextBox txtDataSourceLocation;
        private System.Windows.Forms.Label lblDataSourceLocation;
        private System.Windows.Forms.Button btnUpdateDataSource;
        private System.Windows.Forms.TextBox txtTestInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnTest;
    }
}

