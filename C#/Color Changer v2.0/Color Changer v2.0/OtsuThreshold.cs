using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Color_Changer_v2._0
{
  class OtsuThreshold
  {
    public static void Otsu(ref Bitmap bp)
    {
      int[] HIST = Histogram.Histo(bp);
      Color c;

      int THRESHOLD = OTSUTHRESHOLD(HIST);

      for (int i = 1; i < bp.Width; i++)
        for (int j = 1; j < bp.Height; j++)
        {
          c = bp.GetPixel(i, j);
          if (((c.R + c.B + c.G) / 3) <= THRESHOLD)
          {
            //:If the grayscale is less than threshold -> White otherwise, black
            bp.SetPixel(i, j, Color.Black);
          }
          else
          {
            bp.SetPixel(i, j, Color.White);
          }
        }
    }

    private static int OTSUTHRESHOLD(int[] HIST)
    {
      int totalPixels = 0;
      for (int i = 0; i < 256; i++)
        totalPixels += HIST[i];


      double pxSum = 0;
      for (int i = 0; i < 256; i++)
        pxSum += i * HIST[i];

      double pxSumBG = 0;
      double vMAX = 0;
      double varience;
      int wBG = 0; //:Background
      int wFG = 0; //:Foreground
      int threshold = 0;

      float meanBG, meanFG;

      for (int i = 0; i < 256; i++)
      {
        wBG += HIST[i];
        if (wBG == 0) continue;

        wFG = totalPixels - wBG;
        if (wFG == 0) break;

        pxSumBG += i * HIST[i];

        meanBG = (float)(pxSumBG / wBG);
        meanFG = (float)((pxSum - pxSumBG) / wFG);

        varience = (1.0f * wBG) * (1.0f * wFG) * Math.Pow((meanBG - meanFG), 2);

        if (varience > vMAX)
        {
          threshold = i;
          vMAX = varience;
        }
      }

      return threshold;
    }
  }
}
