using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WmRestClients;
using System.IO;
using System.Net;
using System.Reflection;

namespace WMRESTJSON
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion //Constructors

        #region Event Handlers

        private void mnuSearchItunes_Click(object sender, EventArgs e)
        {
            string originalStatus = statusMain.Text;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                statusMain.Text = "Querying service ...";
                Application.DoEvents();

                NewsJsonWebService service = new NewsJsonWebService();
                NewsResultsCache iNewsResultsCache = service.QueryINews();
                grdITunesSearchResult.DataSource = iNewsResultsCache.GetDataTable();

                SendData();
                service.UploadFile("dfdf");
                service.Login("ich.alednostrad@gmail.com", "ALED", "godisme0");
                

                MessageBox.Show(
                    "Service query completed successfully.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                statusMain.Text = originalStatus;
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void SendData()
        {
            // Read file data
            string fileName = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\img1.png";
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();

            // Generate post objects
            Dictionary<string, object> postParameters = new Dictionary<string, object>();
            postParameters.Add("uploaded_file", "img1.png");
            postParameters.Add("uploaded_file", "png");
            postParameters.Add("uploaded_file", new FormUpload.FileParameter(data, "img1.png", "application/image"));

            // Create request and receive response
            string postURL = "http://alednb:82/php_upload/upload.php";
            string userAgent = "Someone";
            HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(postURL, userAgent, postParameters);

            // Process response
            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            string fullResponse = responseReader.ReadToEnd();
            webResponse.Close();
        }

        #endregion //Event Handlers
    }
}