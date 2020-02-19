using System.Collections.Generic;
using System.Diagnostics;

namespace EveJimaCore.Clients
{
    public static class Active
    {
        public static List<Client> GetList(string clientTitle)
        {
            var list = new List<Client>();

            var processes = Process.GetProcesses();


            var listProcesses = new List<string>();

            foreach (var pList in Process.GetProcesses())
            {
                if (string.IsNullOrEmpty(pList.MainWindowTitle) == false)
                {
                    listProcesses.Add(pList.MainWindowTitle);
                }
            }



            foreach (var pList in Process.GetProcesses())
            {
                if (!pList.MainWindowTitle.Contains(clientTitle)) continue;

                var hWnd = pList.MainWindowHandle;
                var name = pList.MainWindowTitle.Replace(clientTitle, "");

                list.Add(new Client(name, hWnd));
            }

            return list;
        }
    }
}
