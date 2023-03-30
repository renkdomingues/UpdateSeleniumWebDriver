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

        public frmDownload()
        {
            InitializeComponent();
            Download();
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
                DownloadFileInBackGround(downloadURL);
            }
            else
            {
                pnlArqExiste.Visible = true;
                btnFechar.Enabled = true;
                lblStatus.Text = "Para continuar, feche este formulário.";
            }
               

        }

        private void DownloadFileInBackGround(string url)
        {
            timer1.Start();
            using (var cliente = new WebClient())
            {
                cliente.DownloadFile(url, Path.Combine(Directory.GetCurrentDirectory(), "edgedriver_" + version + ".zip"));
                ZipFile.ExtractToDirectory(driver, Directory.GetCurrentDirectory());

                if(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "msedgedriver.exe")))
                {
                    btnFechar.Enabled = true;
                    lblStatus.Text = "Download feito com sucesso, feche este formulário.";
                    prgBarDownload.Style = ProgressBarStyle.Continuous;
                    prgBarDownload.MarqueeAnimationSpeed = 0;
                }
            }
            timer1.Stop();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(prgBarDownload.Value >= 100)
                prgBarDownload.Value = 100;
            else
                prgBarDownload.Value += 5;
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            int x = (panel1.Size.Width - lblStatus.Width) / 2;
            int y = (panel1.Size.Height - lblStatus.Height) / 2;

            lblStatus.Location = new Point(x, y);
        }
    }
}