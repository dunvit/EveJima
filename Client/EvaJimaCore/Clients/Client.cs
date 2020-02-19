using System;

namespace EveJimaCore.Clients
{
    public class Client
    {
        public string Name { get; }

        public IntPtr HWnd { get; }

        public Client(string clientName, IntPtr hWnd)
        {
            Name = clientName;
            HWnd = hWnd;
        }
    }
}
