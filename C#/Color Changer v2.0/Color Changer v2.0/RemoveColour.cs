using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Color_Changer_v2._0
{
  class RemoveColour
  {
    public const int BLUE = 0, RED = 1, GREEN = 2;

    public static void Remove(int colour, ref Bitmap bp)
    {
      Color c;
      switch (colour)
      {
        case BLUE:
          for (int i = 1; i < bp.Width; i++)
            for (int j = 1; j < bp.Height; j++)
            {
              c = bp.GetPixel(i, j);
              bp.SetPixel(i, j, Color.FromArgb(c.R, c.G, 0));
            }
          break;

        case RED:
          for (int i = 1; i < bp.Width; i++)
            for (int j = 1; j < bp.Height; j++)
            {
              c = bp.GetPixel(i, j);
              bp.SetPixel(i, j, Color.FromArgb(0, c.G, c.B));
            }
          break;

        case GREEN:
          for (int i = 1; i < bp.Width; i++)
            for (int j = 1; j < bp.Height; j++)
            {
              c = bp.GetPixel(i, j);
              bp.SetPixel(i, j, Color.FromArgb(c.R, 0, c.B));
            }
          break;
      }
    }
  }
}
