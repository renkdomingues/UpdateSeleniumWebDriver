using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Runtime.CompilerServices;

namespace UpdateSeleniumWebDriver
{
    public partial class frmDownload : Form
    {
        static string version;
        static string driver = "";
        static bool? isCompleted = null;

        public frmDownload()
        {
            InitializeComponent();
        }

        private void Download()
        {
            var psi = new ProcessStartInfo("wmic");
            psi.Arguments = @"datafile where 'name=""C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe""' get version";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var p = Process.Start(psi);
            p.WaitForExit();
            String output = p.StandardOutput.ReadToEnd();
            String errOutput = p.StandardError.ReadToEnd();

            if(!string.IsNullOrEmpty(output))
            {
                version = output.Replace("Version", "").Trim();
                DownloadWebDriver();
            }

            
        }

        private void DownloadWebDriver()
        {
            var downloadURL = "https://msedgedriver.azureedge.net/" + version + "/edgedriver_win32.zip";
            driver = Directory.GetFiles(Directory.GetCurrentDirectory(), "*" + version + "*").ToList().FirstOrDefault();
            
            var lstDrivers = Directory.GetFiles(Directory.GetCurrentDirectory(), "edge*").ToList();
            if (string.IsNullOrEmpty(driver))
            {
                driver = Path.Combine(Directory.GetCurrentDirectory(), "edgedriver_" + version + ".zip");

                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "msedgedriver.exe")))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "msedgedriver.exe"));

                if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Driver_Notes")))
                    Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Driver_Notes"), true);

                foreach (var item in lstDrivers)
                {
                    if(!item.Contains(version))
                        File.Delete(item);
                }

                pnlDownload.Visible = true;
                DownloadFileInBackGroundAsync(downloadURL);
            }
            else
            {
                pnlArqExiste.Visible = true;
                btnFechar.Enabled = true;
                lblStatus.Text = "Para continuar, feche este formulário.";
                //OU FECHAR O FORM
            }
               

        }

        private void DownloadFileInBackGroundAsync(string url)
        {
            Thread thread = new Thread((p) =>
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += Client_DownloadProgressChanged1;
                cliente.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);
                cliente.DownloadFileAsync(new Uri(url), Path.Combine(Directory.GetCurrentDirectory(), "edgedriver_" + version + ".zip"));
                   
                return;
            });
            thread.Start();
            
        }

        private void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("File download cancelled.");
            }

            if (e.Error != null)
            {
                Console.WriteLine(e.Error.ToString());
            }

            isCompleted = true;
            timer1.Start();
        }

        private void Client_DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;

                if(percentage > 0)
                    prgBarDownload.Value = Convert.ToInt32(percentage);
                // you can use to show to calculated % of download
            });
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            int x = (panel1.Size.Width / 2) - lblStatus.Text.Length * 3;
            int y = (panel1.Size.Height - lblStatus.Height) / 2;

            lblStatus.Location = new Point(x, y);
        }

        private void frmDownload_Load(object sender, EventArgs e)
        {
            Download();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCompleted == true)
            {
                ZipFile.ExtractToDirectory(driver, Directory.GetCurrentDirectory());
                btnFechar.Enabled = true;
                lblStatus.Text = "Download feito com sucesso, feche este formulário.";
                isCompleted = false;
                timer1.Stop();
            }
        }
    }
}