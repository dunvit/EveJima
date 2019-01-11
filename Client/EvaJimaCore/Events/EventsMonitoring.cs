
namespace EveJimaCore.Monitoring
{
    public class EventsMonitoring
    {
        private ClipboardMonitoring ClipboardMonitoring { get; set; }

        private BookmarksMonitoring BookmarksMonitoring { get; set; }

        private ActiveWindowMonitoring ActiveWindowMonitoring { get; set; }

        public void Activate()
        {
            ActiveWindowMonitoring = new ActiveWindowMonitoring();

            BookmarksMonitoring = new BookmarksMonitoring();

            ClipboardMonitoring = new ClipboardMonitoring();
        }

    }
}
