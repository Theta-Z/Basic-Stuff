using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Color_Changer_v2._0
{
  class GrayScale
  {
    public static void Prepare(ref Bitmap bp)
    {
      int gray;
      Color c;

      for (int i = 1; i < bp.Width; i++)
        for (int j = 1; j < bp.Height; j++)
        {
          c = bp.GetPixel(i, j);
          gray = ((c.R + c.G + c.B) / 3);
          bp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
        }
    }
  }
}