using System.Drawing;

namespace WormholeNavigator
{
    internal class WindowStatus
    {
        public bool IsWindowMaximized { get; set; } = true;
        public bool IsWindowPinned { get; set; } = false;

        public int Width { get; set; } = 650;
        public int Height { get; set; } = 300;

        internal Size Resize()
        {
            IsWindowMaximized = !IsWindowMaximized;

            Height = IsWindowMaximized ? 300 : 25;
            Width = IsWindowMaximized ? 650 : 300;

            return new Size(Width, Height);
        }

        internal Size Maximize()
        {
            IsWindowMaximized = true;

            Width = 650;
            Height = 300;

            return new Size(Width, Height);
        }

        internal Size Minimize()
        {
            IsWindowMaximized = false;

            Width = 150;
            Height = 25;

            return new Size(Width, Height);
        }

        internal void Pin()
        {
            IsWindowPinned = false;
        }

        internal void UnPin()
        {
            IsWindowPinned = true;
        }
    }
}
