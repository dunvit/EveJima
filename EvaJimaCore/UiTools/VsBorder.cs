using System.Drawing;

namespace WHLocator.UiTools
{
    public static class VsBorder
    {
        public static void DrawBorderToolTip(Graphics fGraph, int left, int top, int width, int heigth)
        {
            var mSimpleRect = new Rectangle(left, top, width, heigth);

            var mPen = new Pen(Color.FromArgb(225, 225, 225), 1);

            fGraph.DrawRectangle(mPen, mSimpleRect);
        }

        public static void DrawBorder(Graphics fGraph, int left, int top, int width, int heigth)
        {
            var mSimpleRect = new Rectangle(left, top, width, heigth);

            var mPen = new Pen(Color.FromArgb(89, 78, 66), 1);

            fGraph.DrawRectangle(mPen, mSimpleRect);


            mSimpleRect = new Rectangle(left + 1, top + +1, width - 2, heigth - 2);

            mPen = new Pen(Color.FromArgb(150, 140, 131), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);
        }

        public static void DrawBorderButton(Graphics fGraph, int left, int top, int width, int heigth)
        {
            var mSimpleRect = new Rectangle(left, top, width, heigth);

            var mPen = new Pen(Color.FromArgb(89, 78, 66), 1);

            fGraph.DrawRectangle(mPen, mSimpleRect);


            mSimpleRect = new Rectangle(left + 1, top + +1, width - 2, heigth - 2);

            mPen = new Pen(Color.FromArgb(150, 140, 131), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

            mSimpleRect = new Rectangle(left + 2, top + 2, width - 4, heigth - 4);

            mPen = new Pen(Color.FromArgb(44, 37, 29), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

            mSimpleRect = new Rectangle(left + 3, top + 3, width - 6, heigth - 6);

            mPen = new Pen(Color.FromArgb(111, 100, 89), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);
        }

        public static void DrawBorderFrame(Graphics fGraph, int left, int top, int width, int heigth)
        {
            var mSimpleRect = new Rectangle(left, top, width, heigth);

            var mPen = new Pen(Color.FromArgb(89, 78, 66), 1);

            fGraph.DrawRectangle(mPen, mSimpleRect);


            mSimpleRect = new Rectangle(left + 1, top + +1, width - 2, heigth - 2);

            mPen = new Pen(Color.FromArgb(150, 140, 131), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

            mSimpleRect = new Rectangle(left + 2, top + 2, width - 4, heigth - 4);

            mPen = new Pen(Color.FromArgb(44, 37, 29), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

        }

        public static void DrawBorderSmallWindow(Graphics fGraph, int left, int top, int width, int heigth)
        {
            var mSimpleRect = new Rectangle(left, top, width, heigth);

            var mPen = new Pen(Color.FromArgb(100, Color.Black), 1);

            fGraph.DrawRectangle(mPen, mSimpleRect);


            mSimpleRect = new Rectangle(left + 1, top + +1, width - 2, heigth - 2);

            mPen = new Pen(Color.FromArgb(100, Color.FromArgb(80, 80, 80)), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

            mSimpleRect = new Rectangle(left + 2, top + 2, width - 4, heigth - 4);

            mPen = new Pen(Color.FromArgb(100, Color.FromArgb(56, 56, 56)), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

        }

        public static void DrawBorderButtonInFocus(Graphics fGraph, int left, int top, int width, int heigth)
        {
            var mSimpleRect = new Rectangle(left, top, width, heigth);

            var mPen = new Pen(Color.FromArgb(89, 78, 66), 1);

            fGraph.DrawRectangle(mPen, mSimpleRect);


            mSimpleRect = new Rectangle(left + 1, top + +1, width - 2, heigth - 2);

            mPen = new Pen(Color.FromArgb(200, 200, 75), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

            mSimpleRect = new Rectangle(left + 2, top + 2, width - 4, heigth - 4);

            mPen = new Pen(Color.FromArgb(44, 37, 29), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

            mSimpleRect = new Rectangle(left + 3, top + 3, width - 6, heigth - 6);

            mPen = new Pen(Color.FromArgb(111, 100, 89), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);
        }


        public static void DrawBorderWindow(Graphics fGraph, int left, int top, int width, int heigth)
        {
            var mSimpleRect = new Rectangle(left + 1, top + 1, width - 3, heigth - 3);

            var mPen = new Pen(Color.FromArgb(44, 37, 29), 3);

            fGraph.DrawRectangle(mPen, mSimpleRect);



            mSimpleRect = new Rectangle(left + 4, top + 4, width - 8, heigth - 8);

            mPen = new Pen(Color.FromArgb(111, 100, 89), 2);
            fGraph.DrawRectangle(mPen, mSimpleRect);


            mSimpleRect = new Rectangle(left + 5, top + 5, width - 11, heigth - 11);

            mPen = new Pen(Color.FromArgb(44, 37, 29), 1);
            fGraph.DrawRectangle(mPen, mSimpleRect);

        }
    }
}
