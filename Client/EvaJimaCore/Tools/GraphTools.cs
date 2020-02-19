using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace EveJimaCore.Tools
{
    public class GraphTools
    {
        public static bool FindObjectInScreen(List<Bitmap> patterns, Bitmap bitmapScreen, int screenModeDelta)
        {
            try
            {
                foreach (var element in patterns)
                {
                    var result = SearchBitmap(ConvertToFormat(element, PixelFormat.Format24bppRgb), ConvertToFormat(bitmapScreen, PixelFormat.Format24bppRgb), 0.1);

                    if (result.X > 0 && result.Y > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // ignore
            }

            return false;
        }

        private static Bitmap ConvertToFormat(Image image, PixelFormat format)
        {
            var copy = new Bitmap(image.Width, image.Height, format);
            using (var gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }

        private static Rectangle SearchBitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
        {
            var smallData = smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);
            var bigData = bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);

            int smallStride = smallData.Stride;
            int bigStride = bigData.Stride;

            int bigWidth = bigBmp.Width;
            int bigHeight = bigBmp.Height - smallBmp.Height + 1;
            int smallWidth = smallBmp.Width * 3;
            int smallHeight = smallBmp.Height;

            Rectangle location = Rectangle.Empty;
            int margin = Convert.ToInt32(255.0 * tolerance);

            unsafe
            {
                byte* pSmall = (byte*)(void*)smallData.Scan0;
                byte* pBig = (byte*)(void*)bigData.Scan0;

                int smallOffset = smallStride - smallBmp.Width * 3;
                int bigOffset = bigStride - bigBmp.Width * 3;

                bool matchFound = true;

                for (int y = 0; y < bigHeight; y++)
                {
                    for (int x = 0; x < bigWidth; x++)
                    {
                        byte* pBigBackup = pBig;
                        byte* pSmallBackup = pSmall;

                        //Look for the small picture.
                        for (int i = 0; i < smallHeight; i++)
                        {
                            int j = 0;
                            matchFound = true;
                            for (j = 0; j < smallWidth; j++)
                            {
                                //With tolerance: pSmall value should be between margins.
                                int inf = pBig[0] - margin;
                                int sup = pBig[0] + margin;
                                if (sup < pSmall[0] || inf > pSmall[0])
                                {
                                    matchFound = false;
                                    break;
                                }

                                pBig++;
                                pSmall++;
                            }

                            if (!matchFound) break;

                            //We restore the pointers.
                            pSmall = pSmallBackup;
                            pBig = pBigBackup;

                            //Next rows of the small and big pictures.
                            pSmall += smallStride * (1 + i);
                            pBig += bigStride * (1 + i);
                        }

                        //If match found, we return.
                        if (matchFound)
                        {
                            location.X = x;
                            location.Y = y;
                            location.Width = smallBmp.Width;
                            location.Height = smallBmp.Height;
                            break;
                        }
                        //If no match found, we restore the pointers and continue.
                        else
                        {
                            pBig = pBigBackup;
                            pSmall = pSmallBackup;
                            pBig += 3;
                        }
                    }

                    if (matchFound) break;

                    pBig += bigOffset;
                }
            }

            bigBmp.UnlockBits(bigData);
            smallBmp.UnlockBits(smallData);

            return location;
        }

    }
}
