using System;


namespace EveJimaCore
{
    public class Messages
    {
        public event Action<string> OnGetGlobalMessage;

        private static readonly Messages instance = new Messages();

        public string Name { get; private set; }

        private Messages()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static Messages GetInstance()
        {
            return instance;
        }

        public void PublishMessage(string message)
        {
            if(OnGetGlobalMessage != null) OnGetGlobalMessage(message);
        }
    }
}
