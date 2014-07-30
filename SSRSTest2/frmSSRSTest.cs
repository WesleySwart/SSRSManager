using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.IO;
using SSRSTest2.ReportingService2010;
using System.Web.Services.Protocols;
using System.Threading;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using V4Utils;
using System.Data.SqlClient;

namespace SSRSTest2
{
    public partial class frmSSRSTest : Form
    {
        V4Utils.Logger logger;

        private ReportingService2010.ReportingService2010 mvar_rs = new ReportingService2010.ReportingService2010();
          
        public frmSSRSTest()
        {

            InitializeComponent();

            //System.Reflection.Assembly ThisAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            //string gAppPath = ThisAssembly.Location;
            //gAppPath = gAppPath.Substring(0, gAppPath.LastIndexOf('\\') + 1);
            //gAppPath += "Logs\\";
            //if (!System.IO.Directory.Exists(gAppPath))
            //{
            //    System.IO.Directory.CreateDirectory(gAppPath);
            //}
            //logger = Logger.GetLogger(gAppPath, "SSRSTest");

            //logger.LogMsg("Logger Initialized.", Logger.LogLevel.LogIsErr);

            logger = V4Utils.Logger.GetLogger("SSRSTest");

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            BackgroundWorker bw2 = new BackgroundWorker();

            bw2.WorkerReportsProgress = true;
            bw2.WorkerSupportsCancellation = true;
            bw2.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw2.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw2_RunWorkerCompleted);

            mvar_rs.Url = txtURL.Text + "reportservice2010.asmx"; //"http://localhost/ReportServer/reportservice2010.asmx"; //WebService url in ReportingServicesConfigurationManager; localhost = server name
            mvar_rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
        }

        //private string GetReportServerURL()
        //{
        //    string url = string.Empty;
        //    try
        //    {             
        //        string sql = string.Empty;

        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            SqlCommand cmd = new SqlCommand(sql, conn);

        //            conn.Open();

        //            object objScalar = cmd.ExecuteScalar();

        //            if (objScalar != null)
        //            {
        //                url = objScalar.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception Err)
        //    {
        //        this.WriteLog(Err.ToString());
        //    }
        //    return url;
        //}

        void bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private BackgroundWorker bw = new BackgroundWorker();

        private string mvar_ServerName = string.Empty; //"localhost";
        public string ServerName
        {
            get
            {
                return mvar_ServerName;
            }
            set
            {
                mvar_ServerName = value;
            }
        }
        private string mvar_DatabaseName;// = "V4_SPPS_V6";
        public string DatabaseName 
        { 
            get 
            { 
                return mvar_DatabaseName; 
            } 
            set 
            { 
                mvar_DatabaseName = value; 
            } 
        }
        private string mvar_UserID;// = "sa";
        public string UserID
        {
            get
            {
                return mvar_UserID;
            }
            set
            {
                mvar_UserID = value;
            }
        }
        private string mvar_Password = string.Empty;
        public string Password
        {
            get
            {
                return mvar_Password;
            }
            set
            {
                mvar_Password = value;
            }
        }
        //private string mvar_ConnectionString = string.Format("DataSource={0};InitialCatalog=master;User ID={1};Password{2}", mvar_ServerName, mvar_UserID, mvar_Password);

        private string mvar_DataSourceName = string.Empty;
        public string DataSourceName 
        {
            get 
            { 
                return mvar_DataSourceName; 
            }
            set 
            {
                mvar_DataSourceName = value;
            }
        }
        private string mvar_DataSourceLocation = string.Empty;// = @"/Data Sources";
        public string DataSourceLocation 
        { 
            get
            {
                return mvar_DataSourceLocation;
            }
            set 
            {
                mvar_DataSourceLocation = value;
            }
        }
        private string mvar_SelectedFolder = string.Empty;
        public string SelectedFolder 
        {
            get 
            {
                return mvar_SelectedFolder;
            }
            set 
            { 
                mvar_SelectedFolder = value;
            }
        }
        private string sroot = string.Empty;

        //private string parent = string.Empty;

        private List<string> folderList { get; set; }


        private void btnGetFolderPath_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowseDlg.SelectedPath = txtRootPath.Text; // @"C:\Program Files (x86)\Voice4net\
                if (!Directory.Exists(folderBrowseDlg.SelectedPath))
                {
                    Directory.CreateDirectory(folderBrowseDlg.SelectedPath);
                }
                if (folderBrowseDlg.ShowDialog() == DialogResult.OK)
                {
                    this.txtRootPath.Text = folderBrowseDlg.SelectedPath;
                }
            }
            catch (Exception Err)
            {
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                //WriteLog(Err.ToString());
                WriteLog(Err.ToString());
            }
        }

        public void WriteLog(string log)
        {
            try
            {
                txtLog.AppendText(DateTime.Now + " : " + log + Environment.NewLine);
                Application.DoEvents();
                txtLog.ScrollToCaret();
            }
            catch (Exception Err)
            {

                Console.WriteLine(Err.ToString());
            }

        }

        #region BackgroundWorker
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            string cmd = e.Argument.ToString();

            if (cmd == "DeployReport")
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    //break;
                }
                else
                {
                    //btnDeploy.Enabled = false;

                    DeployReport(sroot);
                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //string percentage = e.ProgressPercentage.ToString() + "%";
            string msg = e.UserState.ToString();
            logger.LogMsg(msg, Logger.LogLevel.LogIsErr);
            WriteLog(msg);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            btnDeploy.Enabled = true;
            if (e.Cancelled == true)
            {
                WriteLog("Canceled!");
            }
            else if (!(e.Error == null))
            {
                WriteLog("Error: " + e.Error.Message);
            }
            else
            {
                WriteLog("Done!");
            }
        }
        #endregion BackgroundWorker

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
            }
        }

        private void ReportProgress(/*int intProgress,*/ string strMsg)
        {
            try
            {
                DeployReportEventArgs e = new DeployReportEventArgs();
                //e.Progress = intProgress;
                e.Message = strMsg;

                bw.ReportProgress(e.Progress, e.Message);

                //if (ReportProgress != null)
                //{

                //    this.ReportProgress(this, e);

                //}
            }
            catch (Exception Err)
            {

                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
            }
        }

        public class DeployReportEventArgs : EventArgs
        {
            public int Progress { get; set; }
            public string Message { get; set; }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                string sPath = string.Empty;
                sroot = txtRootPath.Text;
                if (!sroot.EndsWith("\\"))
                {
                    sroot += "\\";
                }
                //DeployReport(sroot

                //Run DeployReport on background worker thread
                if (bw.IsBusy != true)
                {
                    btnDeploy.Enabled = false;
                    //Test splash screen with progress bar

                    bw.RunWorkerAsync("DeployReport");
                }
            }
            catch (Exception Err)
            {

                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
            }
        }

        private void DeployReport(string sroot)
        {
            try
            {
               // ReportingService2010.ReportingService2010= new ReportingService2010.ReportingService2010();
                //CatalogItem[] items;

                //Pass delegate
                //Delegate parent = getComboItem();
                
                //sroot = sroot + "Bin\\V4Web\\SSRS Reports\\"; //V4\\";
                string strItemType = "Report";
                string strReportName = string.Empty;
                string strFilePath = string.Empty;
                string parent = "/" + this.getSelectedComboItem().ToString(); //"/V4"; //V4 //Not thread safe

                //mvar_rs.Url = "http://localhost/ReportServer/reportservice2010.asmx"; //WebService url in ReportingServicesConfigurationManager; localhost = server name
                //mvar_rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

                //Don't know what this is, so I'm commenting it out!!! Yeah!!!
                //items =mvar_rs.ListChildren(parent, true);

                // Serialize the contents as an XML document and write the contents to a file.
                //Serialize(items);

                //items =mvar_rs.ListChildren(mvar_DataSourceLocation, true);

                // Serialize the contents as an XML document and write the contents to a file.
                //Serialize(items);

                //Get folder name; if exists, skip
                //foreach (var item in items)
                //{
                //    ReportProgress(item.ToString());
                //    logger.LogMsg(item.ToString(), Logger.LogLevel.LogIsErr);
                //    //if (item.Name != mvar_DataSourceName )
                //    //{

                //    //}
                //}

                //Create Folders
                //rs.CreateFolder(mvar_DataSourceLocation.Substring(mvar_DataSourceLocation.LastIndexOf("/") + 1), @"/", null); //DataSourceFolder
                //rs.CreateFolder("V4", "/", null); //V4 folder



                string[] aReportList = Directory.GetFiles(sroot, "*.rdl*", SearchOption.AllDirectories);
                //ReportingService2010[] Reports = null;

                Byte[] definition = null;
                ReportingService2010.Warning[] warnings = null;


                //#region CreateDataSource
                //// Create DataSource that Report will Use
                //logger.LogMsg("Begin CreateDataSource: ", Logger.LogLevel.LogIsErr);
                //ReportProgress("Begin CreateDataSource: ");
                //DataSource dSource = new DataSource();
                //DataSourceDefinition dDefinition = new DataSourceDefinition();

                //dSource.Item = dDefinition;
                //dDefinition.Extension = "SQL";
                //dDefinition.ConnectString = @"Data Source=" + mvar_ServerName
                //    + @";Initial Catalog=" + mvar_DatabaseName;
                //ReportProgress(dDefinition.ConnectString.ToString());
                //dDefinition.ImpersonateUserSpecified = true;
                //dDefinition.Prompt = null;
                //dDefinition.WindowsCredentials = false;
                //dDefinition.UserName = mvar_UserID;
                //dDefinition.Password = mvar_Password;
                //dDefinition.CredentialRetrieval = CredentialRetrievalEnum.Store;
                //dSource.Name = mvar_DataSourceName;

                //try
                //{
                //   mvar_rs.CreateDataSource(mvar_DataSourceName, mvar_DataSourceLocation, false,
                //        dDefinition, null);
                //    logger.LogMsg("Create DataSource " + mvar_DataSourceName + ": Success!!", Logger.LogLevel.LogIsErr);
                //    ReportProgress("Create DataSource " + mvar_DataSourceName + ": Success!!");
                //}
                //catch (System.Web.Services.Protocols.SoapException Err)
                //{
                //    logger.LogMsg(Err.Detail.InnerXml.ToString(), Logger.LogLevel.LogIsErr);
                //    WriteLog(Err.Detail.InnerXml.ToString());
                //}
                //logger.LogMsg("End CreateDataSource", Logger.LogLevel.LogIsErr);
                //ReportProgress("End CreateDataSource");
                //#endregion CreateDataSource

                #region DeployReportList
                for (int i = 0; i < aReportList.Length; i++) //foreach (aReportList 
                {
                    strReportName = aReportList[i].Substring(aReportList[i].LastIndexOf("\\") + 1); //file name only
                    logger.LogMsg("Report: " + strReportName, Logger.LogLevel.LogIsErr);
                    ReportProgress("Report: " + strReportName);
                    strFilePath = aReportList[i];
                    logger.LogMsg("File path: " + strFilePath, Logger.LogLevel.LogIsErr);
                    ReportProgress("File path: " + strFilePath);



                    try
                    {
                        FileStream stream = File.OpenRead(strFilePath);
                        definition = new Byte[stream.Length];
                        stream.Read(definition, 0, (int)stream.Length);
                        stream.Close();
                    }
                    catch (IOException Err)
                    {
                        logger.LogMsg(Err.Message.ToString(), Logger.LogLevel.LogIsErr);
                        ReportProgress(Err.Message.ToString());
                    }

                    try
                    {

                        ReportingService2010.CatalogItem report = mvar_rs.CreateCatalogItem(strItemType, strReportName, parent, true, definition, null, out warnings);
                        logger.LogMsg(report.ToString(), Logger.LogLevel.LogIsErr);
                        ReportProgress(report.ToString());

                        #region Test
                        // Get datasource of report
                        string sReportPath = parent + "/" + strReportName;
                        DataSource ds = new DataSource();
                        DataSource[] dataSources = mvar_rs.GetItemDataSources(sReportPath);
                        ds = dataSources[0];
                        //DataSourceDefinition dsd = ds as DataSourceDefinition();
                        //if(dsd == null)
                        //    throw new Exception();
                        //String connectionString = ds.Item;
                        logger.LogMsg("Name: " + ds.Name + " , " + "Item: " + ds.Item, Logger.LogLevel.LogIsErr);
                        ReportProgress("Name: " + ds.Name + " , " + "Item: " + ds.Item);

                        #endregion Test

                        byte[] reportDefinition = null;
                        XmlDocument xmldoc = null;

                        //Upload report
                        reportDefinition = mvar_rs.GetItemDefinition(sReportPath);

                        using (MemoryStream rdlFile = new MemoryStream(reportDefinition))
                        {
                            xmldoc = new XmlDocument();
                            xmldoc.Load(rdlFile);
                            rdlFile.Close();
                        }

                        #region XML
                        //Return dataset items within report

                        XmlNode root = xmldoc.DocumentElement;
                        //Get all elements under root node
                        XmlNodeList nodelist = root.SelectNodes("descendant::*");

                        foreach (XmlNode node in nodelist)
                        {
                            if (node.Name == "DataSets")//only search datasets
                            {
                                XmlNodeList childList = node.ChildNodes;

                                foreach (XmlNode childnode in childList)
                                {
                                    if (childnode.Name == "DataSet")//check if dataset element
                                    {
                                        logger.LogMsg(childnode.Attributes["Name"].Value, Logger.LogLevel.LogIsErr);
                                        ReportProgress(childnode.Attributes["Name"].Value);
                                    }
                                }
                            }
                        }
                        #endregion XML

                        if (warnings != null)
                        {
                            foreach (ReportingService2010.Warning warning in warnings)
                            {
                                logger.LogMsg(warning.Message, Logger.LogLevel.LogIsErr);
                                ReportProgress(warning.Message);
                            }
                        }

                        else
                        logger.LogMsg("Report " + strReportName + " created successfully with no warnings", Logger.LogLevel.LogIsErr);
                        ReportProgress("Report " + strReportName + " created successfully with no warnings");
                    }
                    catch (SoapException Err)
                    {
                        logger.LogMsg(Err.Detail.InnerXml.ToString(), Logger.LogLevel.LogIsErr);
                        ReportProgress(Err.Detail.InnerXml.ToString());

                    }
                #endregion DeployReportList
                }
            }
            catch (Exception Err)
            {
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                ReportProgress(Err.ToString());
            }
        }


        private void Serialize(CatalogItem[] items)
        {
            try
            {
                FileStream fs = new FileStream("DataSourceCatalogItems.xml", FileMode.Create);
                XmlTextWriter writer = new XmlTextWriter(fs, Encoding.Unicode);

                XmlSerializer serializer = new XmlSerializer(typeof(CatalogItem[]));
                serializer.Serialize(writer, items);

                ReportProgress("Server contents successfully written to a file.");
                logger.LogMsg("Server contents successfully written to a file.", Logger.LogLevel.LogIsErr);
            }

            catch (Exception e)
            {
                ReportProgress(e.Message);
                logger.LogMsg(e.Message, Logger.LogLevel.LogIsErr);
            }
        }

        private void frmSSRSTest_Load(object sender, EventArgs e)
        {
            LoadFolderList();
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportingService2010.ReportingService2010= new ReportingService2010.ReportingService2010();
                CatalogItem[] items;

                //mvar_rs.Url = "http://localhost/ReportServer/reportservice2010.asmx"; //WebService url in ReportingServicesConfigurationManager; localhost = server name
                //mvar_rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

                //Get children
                items = mvar_rs.ListChildren(@"/", true);

                // Serialize the contents as an XML document and write the contents to a file.
                //Serialize(items);

                //Create Folders
                //rs.CreateFolder(mvar_DataSourceLocation.Substring(mvar_DataSourceLocation.LastIndexOf("/") + 1), @"/", null); //DataSourceFolder
                List<string> itemNames = new List<string>();
                foreach (CatalogItem item in items)
                {
                    //logger.LogMsg(item.ToString(), Logger.LogLevel.LogIsErr);
                    WriteLog("Type: " + item.TypeName.ToString() + ", Name: " + item.Name.ToString());

                    if (item.TypeName == "Folder")
                    {
                        itemNames.Add(item.Name);
                        WriteLog(item.Name + " added to " + itemNames);
                    }
                    //if !(rs.FindItems(@"/","","",txtFolderName.Text))
                    //{
                    //   mvar_rs.CreateFolder(txtFolderName.Text, @"/", null);
                    //    logger.LogMsg("Folder " + txtFolderName.Text + " successfully created.", Logger.LogLevel.LogIsErr);
                    //    WriteLog("Folder " + txtFolderName.Text + " successfully created.");
                    //}
                    //else
                    //{
                    //    logger.LogMsg("Folder " + txtFolderName.Text + " already exists!", Logger.LogLevel.LogIsErr);
                    //    WriteLog("Folder " + txtFolderName.Text + " already exists!");
                    //}
                }
                if (!itemNames.Contains(txtFolderName.Text))
                {
                    mvar_rs.CreateFolder(txtFolderName.Text, @"/", null);
                    WriteLog("Create folder" + txtFolderName.Text);
                }
                else
                {
                    WriteLog("Folder " + txtFolderName.Text + " already exists!");
                }
               //mvar_rs.CreateFolder(txtFolderName.Text, @"/", null); //V4 folder

                LoadFolderList();
            }
            catch (Exception Err)
            {
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
            }
        }

        private void LoadFolderList()
        {
            try
            {
                //ReportingService2010.ReportingService2010= new ReportingService2010.ReportingService2010();
                CatalogItem[] items;

               mvar_rs.Url = "http://localhost/ReportServer/reportservice2010.asmx"; //WebService url in ReportingServicesConfigurationManager; localhost = server name
               mvar_rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

                //Load folder list in root only

                //Get children
                items =mvar_rs.ListChildren(@"/", true);
                List<string> itemNames = new List<string>();
                foreach (CatalogItem item in items)
                {
                    //logger.LogMsg(item.ToString(), Logger.LogLevel.LogIsErr);
                    WriteLog("Type: " + item.TypeName.ToString() + ", Name: " + item.Name.ToString());

                    if (item.TypeName == "Folder")
                    {
                        if (!cboFolderList.Items.Contains(item.Name))
                        {
                        //itemNames.Add(item.Name);
                        cboFolderList.Items.Add(item.Name);
                        WriteLog(item.Name + " added to " + cboFolderList.Name);
                        }
                    }
                }
            }
            catch (Exception Err)
            {

                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
            }

        }

        private void LoadSelectedFolderList()
        {
            //ReportingService2010.ReportingService2010= new ReportingService2010.ReportingService2010();
            CatalogItem[] items;

           //mvar_rs.Url = "http://localhost/ReportServer/reportservice2010.asmx"; //WebService url in ReportingServicesConfigurationManager; localhost = server name
           //mvar_rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

            try
            {
                //Get children
                items = mvar_rs.ListChildren(@"/" + cboFolderList.SelectedItem.ToString(), true);
                List<string> itemNames = new List<string>();
                WriteLog("Items in " + cboFolderList.SelectedItem.ToString() + " : ");
                foreach (CatalogItem item in items)
                {
                    //logger.LogMsg(item.ToString(), Logger.LogLevel.LogIsErr);
                    WriteLog("Type: " + item.TypeName.ToString() + ", Name: " + item.Name.ToString());

                    //if (item.TypeName == "Folder")
                    //{
                    //    //itemNames.Add(item.Name);
                    //    //cboFolderList.Items.Add(item.Name);
                    //    WriteLog(item.Name + " added to " + cboFolderList.Name);
                    //}
                }
            }
            catch (Exception Err)
            {
                
                WriteLog(Err.ToString());
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
            }

        }

        private void cboFolderList_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSelectedFolderList();
        }

        private void cboFolderList_DropDown(object sender, EventArgs e)
        {
            //LoadFolderList();
        }

        private void CreateDataSource()
        {
            mvar_ServerName = txtServerName.Text;
            mvar_DatabaseName = txtDatabaseName.Text;
            mvar_UserID = txtUserName.Text;
            mvar_Password = txtPassword.Text;
            mvar_DataSourceName = txtDataSourceName.Text;
            mvar_DataSourceLocation = txtDataSourceLocation.Text;

            try
            {
                //DataSourceLocation requires '/' at beginning of string

                //Sets parent/data source location to root
                if (mvar_DataSourceLocation == "/")
                {
                    mvar_DataSourceLocation = @"/";
                }
                
                //if "/" + txtDataSourceLocation doesn't exist, add @"/"
                //Check if DataSource exists, if !exists, continue, else error

                //ReportingService2010.ReportingService2010= new ReportingService2010.ReportingService2010();
                //CatalogItem[] items;

                //sroot = sroot + "Bin\\V4Web\\SSRS Reports\\"; //V4\\";
                //string strItemType = "Report";
                //string strReportName = string.Empty;
                //string strFilePath = string.Empty;
                //string parent = "/V4"; //V4

               //mvar_rs.Url = "http://localhost/ReportServer/reportservice2010.asmx"; //WebService url in ReportingServicesConfigurationManager; localhost = server name
               //mvar_rs.Credentials = System.Net.CredentialCache.DefaultCredentials;


                #region CreateDataSource
                // Create DataSource that Report will Use
                logger.LogMsg("Begin CreateDataSource: ", Logger.LogLevel.LogIsErr);
                WriteLog("Begin CreateDataSource: ");
                DataSource dSource = new DataSource();
                DataSourceDefinition dDefinition = new DataSourceDefinition();

                dSource.Item = dDefinition;
                dDefinition.Extension = "SQL";
                dDefinition.ConnectString = @"Data Source=" + mvar_ServerName
                    + @";Initial Catalog=" + mvar_DatabaseName;
                WriteLog(dDefinition.ConnectString.ToString());
                dDefinition.ImpersonateUserSpecified = true;
                dDefinition.Prompt = null;
                dDefinition.WindowsCredentials = false;
                dDefinition.UserName = mvar_UserID;
                dDefinition.Password = mvar_Password;
                dDefinition.CredentialRetrieval = CredentialRetrievalEnum.Store;
                dSource.Name = mvar_DataSourceName;

                try
                {
                   mvar_rs.CreateDataSource(mvar_DataSourceName, mvar_DataSourceLocation, false,
                        dDefinition, null);
                    logger.LogMsg("Create DataSource " + mvar_DataSourceName + ": Success!!", Logger.LogLevel.LogIsErr);
                    WriteLog("Create DataSource " + mvar_DataSourceName + ": Success!!");
                }
                catch (System.Web.Services.Protocols.SoapException Err)
                {
                    logger.LogMsg(Err.Detail.InnerXml.ToString(), Logger.LogLevel.LogIsErr);
                    WriteLog(Err.Detail.InnerXml.ToString());
                }
                logger.LogMsg("End CreateDataSource", Logger.LogLevel.LogIsErr);
                WriteLog("End CreateDataSource");
                #endregion CreateDataSource
            }
            catch (Exception Err)
            {
                
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
            }
        }

        private void btnCreateDataSource_Click(object sender, EventArgs e)
        {
            try
            {
                CreateDataSource();
            }
            catch (Exception Err)
            {
                
                logger.LogMsg(Err.ToString(),Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
            } 
        }

        private static DataSource[] GetSharedDataSource(ReportingService2010.ReportingService2010 rs, string reportsFolder, string reportName)
        {
            V4Utils.Logger logger;
            logger = V4Utils.Logger.GetLogger("SSRSTest");

            try
            {
                DataSourceReference reference = new DataSourceReference();
                DataSource ds = new DataSource();
                reference.Reference = @"/"; //+ reportsFolder + "/" + "SharedDataSource";
                ds.Item = (DataSourceDefinitionOrReference)reference;
                //Get original report Data Source Name
                DataSource[] reportDataSource = rs.GetItemDataSources(@"/" + reportsFolder + @"/" + reportName);
                ds.Name = reportDataSource[0].Name;
                //Testing: change existing data source name to match shared data source
                //ds.Name = "V4_SPPS_V6";
                return new DataSource[] { ds };
            }

            catch (System.Web.Services.Protocols.SoapException Err)
            {

                logger.LogMsg(Err.Detail.InnerXml.ToString(), Logger.LogLevel.LogIsErr);
                //WriteLog(Err.Detail.InnerXml.ToString());
            }
            return null;
        }

        private void btnUpdateDataSource_Click(object sender, EventArgs e)
        {

            try
            {
                string reportsFolder = "V4";
                string reportName = "PromptsList.rdl";
                //Get Shared Data Source of report
                DataSource[] ds = GetSharedDataSource(mvar_rs, reportsFolder, reportName);
                //Set Report's Data Source
                mvar_rs.SetItemDataSources(@"/" + reportsFolder + @"/" + reportName, ds);
            }
            catch (System.Web.Services.Protocols.SoapException Err)
            {
                logger.LogMsg(Err.Detail.InnerXml.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.Detail.InnerXml.ToString());
            }

        }

        //Create delegate for cboFolderList.SelectedItem
        private delegate object getComboItem();

        //Get cboFolderList.SelectedItem
        private object getSelectedComboItem()
        { 
            if(cboFolderList.InvokeRequired)
            {
                getComboItem gci = new getComboItem(getSelectedComboItem);
                return cboFolderList.Invoke(gci);
            }
            else
                return cboFolderList.SelectedItem;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                //Call the Function for Mandatory Fields..
                if (this.ValidateMandatoryFields())
                {
                    if (this.TestConnection())
                    {
                        MessageBox.Show("Connection Successfull");
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid database credential", "Connection Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter all details");
                }
            }
            catch (Exception Err)
            {
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
            }
        }

        //This Function Check for Mandatory Fields..
        private bool ValidateMandatoryFields()
        {
            bool validationStatus = false;
            if (txtDatabaseName.Text.Trim() != string.Empty && txtPassword.Text.Trim() != string.Empty && txtServerName.Text.Trim() != string.Empty && txtUserName.Text.Trim() != string.Empty)
            {
                validationStatus = true;
            }
            return validationStatus;
        }
        //This Function Check the Database Connection is Successfull or not..
        private bool TestConnection()
        {
            bool conStatus = false;
            try
            {

                using (SqlConnection con = new SqlConnection(this.GetConnectionString()))
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        conStatus = true;
                    }
                    catch (Exception Err)
                    {
                        MessageBox.Show(Err.Message);
                    }
                    //return conStatus;
                }
            }
            catch (Exception Err)
            {
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
            }

            return conStatus;
        }
        //get the Connection string..
        public string GetConnectionString()
        {
            string sRet = string.Empty;
            try
            {
                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", txtServerName.Text.Trim(), "master", txtUserName.Text.Trim(), txtPassword.Text.Trim());
                sRet = connectionString.ToString();
                string sEncryptedPWD = V4Utils.cEncryption.EncryptString(txtPassword.Text, "Voice4net");
                logger.LogMsg("Connection String set to " + sRet, Logger.LogLevel.LogIsErr);
                WriteLog("Connection String set to " + sRet);
                return sRet;
            }
            catch (Exception Err)
            {
                logger.LogMsg(Err.ToString(), Logger.LogLevel.LogIsErr);
                WriteLog(Err.ToString());
                return sRet;
            }
        }

    }
}
