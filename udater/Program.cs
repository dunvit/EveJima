using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using EveJimaSettings;
using Newtonsoft.Json;

namespace udater
{
    class Program
    {

        static void Main(string[] args)
        {
            var settings = new Settings();
            settings.CurrentVersion = settings.CurrentVersion.Trim();
            var fileName = settings.Client_execution_file;

            var Server_update_content_version = settings.Server_update_content_version;

            string process = fileName.Replace(".exe", "");

            if (File.Exists(@"Logs") == false)
            {
                Directory.CreateDirectory(@"Logs");
            }

            if (File.Exists(@"Logs/updater_log.txt") == false)
            {
                using (File.Create(@"Logs/updater_log.txt")){}
            }

            Console.WriteLine("Terminate process \"" + fileName + "\"");
            File.AppendAllText(@"Logs/updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Terminate process \"" + fileName + "\"" + Environment.NewLine);
            while (Process.GetProcessesByName(process).Length > 0)
            {
                Process[] myProcesses2 = Process.GetProcessesByName(process);
                for (int i = 1; i < myProcesses2.Length; i++) { myProcesses2[i].Kill(); }
                Console.WriteLine("Try kill process \"" + fileName + "\" Please close EveJima application");
                File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Try kill process \"" + fileName + "\" Please close EveJima application" + Environment.NewLine);

                Thread.Sleep(300);
            }

            Console.WriteLine("Start update EveJima application");
            File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Start update EveJima application" + Environment.NewLine);
            Thread.Sleep(500);
            Console.WriteLine("Connecting to server.");
            Thread.Sleep(500);
            Console.WriteLine("Connecting to server..");
            Thread.Sleep(500);
            Console.WriteLine("Connecting to server...");

            var client = new WebClient();

            Console.WriteLine("Version number is " + settings.Version);
            File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Version number is " + settings.Version + Environment.NewLine);


            var versionContent = client.DownloadString(Server_update_content_version);

            Console.WriteLine("Version content is " + versionContent);
            File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Version content is " + versionContent + Environment.NewLine);


            foreach (var file in GetVersionContent(versionContent).Files)
            {
                try
                {
                    Console.WriteLine("Start download file " + file.Name + " from " + file.Address + "");
                    File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Start download file " + file.Name + " from " + file.Address + "" + Environment.NewLine);

                    if (File.Exists(file.Name) == false)
                    {
                        File.Delete(file.Name);
                    }

                    client.DownloadFile(file.Address, file.Name);

                    Console.WriteLine("File " + file.Name + " downloaded successfully");
                    File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "File " + file.Name + " downloaded successfully" + Environment.NewLine);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Critical error in download and update file " + file.Name + ". Exception is " + ex.Message);
                    File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Critical error in download and update file " + file.Name + ". Exception is " + ex + Environment.NewLine);

                }
            }

            try
            {
                try
                {
                    if (File.Exists("Version.txt") == false)
                    {
                        File.Delete("Version.txt");
                    }

                    using (File.Create(@"Version.txt")) ;

                    File.AppendAllText(@"Version.txt", settings.Version);

                    File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Revrate version to " + settings.Version + Environment.NewLine);

                    File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Start EvaJima.exe" + Environment.NewLine);
                    Process.Start(fileName);
                    File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Start EvaJima.exe successfully" + Environment.NewLine);
                }
                catch (Exception ex2)
                {
                    File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Error: " + ex2 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                File.AppendAllText(@"Logs\updater_log.txt", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + " " + "Error: " + e + Environment.NewLine);
            }

        }


        private static VersionContent GetVersionContent(string json)
        {
            var result = JsonConvert.DeserializeObject<VersionContent>(json);

            return result;
        }
    }
}
