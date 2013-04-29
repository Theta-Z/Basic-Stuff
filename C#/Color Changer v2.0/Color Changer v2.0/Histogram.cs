using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Color_Changer_v2._0
{
  class Histogram
  {
    public static int[] Histo(Bitmap bp)
    {
      int[] lvls = new int[256];
      Color c;

      for (int i = 1; i < bp.Width; i++)
        for (int j = 1; j < bp.Height; j++)
        {
          c = bp.GetPixel(i, j);
          lvls[(int)((c.R + c.G + c.B) / 3)]++;
        }

      return lvls;
    }
  }
}
