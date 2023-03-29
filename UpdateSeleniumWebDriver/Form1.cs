using System.Diagnostics;
using System.IO.Compression;
using System.Net;

namespace UpdateSeleniumWebDriver
{
    public partial class Form1 : Form
    {
        static string version;
        public Form1()
        {
            InitializeComponent();
            teste();
        }

        private void teste()
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
        static string driver = "";
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

                DownloadFileInBackGround(downloadURL);
            }
            

        }

        private static void DownloadFileInBackGround(string url)
        {
            using (var cliente = new WebClient())
            {
                cliente.DownloadFile(url, Path.Combine(Directory.GetCurrentDirectory(), "edgedriver_" + version + ".zip"));

                ZipFile.ExtractToDirectory(driver, Directory.GetCurrentDirectory());
            }
        }
    }
}