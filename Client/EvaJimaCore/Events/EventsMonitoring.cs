using EvaJimaCore;

namespace EveJimaCore.Monitoring
{
    public class EventsMonitoring
    {
        private ClipboardMonitoring ClipboardMonitoring { get; set; }

        private BookmarksMonitoring BookmarksMonitoring { get; set; }

        private ActiveWindowMonitoring ActiveWindowMonitoring { get; set; }

        public void Activate()
        {
            ActiveWindowMonitoring = new ActiveWindowMonitoring(Global.ApplicationSettings);
            ActiveWindowMonitoring.Activate();

            BookmarksMonitoring = new BookmarksMonitoring(Global.ApplicationSettings);
            BookmarksMonitoring.Activate();

            ClipboardMonitoring = new ClipboardMonitoring(Global.ApplicationSettings);
            ClipboardMonitoring.Activate();
        }

        public void Dispose()
        {
            ActiveWindowMonitoring.Dispose();
            BookmarksMonitoring.Dispose();
            ClipboardMonitoring.Dispose();
        }
    }
}
