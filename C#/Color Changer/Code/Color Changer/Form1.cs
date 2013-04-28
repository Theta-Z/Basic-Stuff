using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;


//////////////////////////////////////////////////////////////////////
//                    C# Image Colour Changer                       //
//                        Shelby Copeland                           //
//     You may use this code if you give me credit where used.      //
//              Otherwise, you may not use this code.               //
//////////////////////////////////////////////////////////////////////

///<summary>
///  A simple program designed to outline the basics of image colours.
///</summary>
namespace Color_Changer
{
    public partial class Form1 : Form
    {
        #region Constructor and Variables
        private string IMAGE;
        private bool ready;
        private Bitmap bp;
        public Form1()
        {
          InitializeComponent();
          this.MinimizeBox = false;
          this.MaximizeBox = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
          if (!ready)
          {
            MessageBox.Show("Please wait for the current Auto BW to finish.");
            return;
          }
          base.OnClosing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          ready = true;
        }
      #endregion

        #region Select a new Image to work with
        private void btn_newIMG_Click(object sender, EventArgs e)
        {
          #region Setup the Open File Dialog
          OpenFileDialog ofd = new OpenFileDialog();
          ofd.DefaultExt = "jpg";
          ofd.Filter = "JPG Image|*.jpg|PNG Image|*.png|GIF Image|*.gif|Bmp Image|*.bmp";
          ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
          #endregion

          #region open the file and put it on the image box
          if (ofd.ShowDialog() == DialogResult.OK)
          {
            //:They have chosen their file at this point, so lets show it.
            //:Size of image box is roughly a 16:10 ratio.
            IMAGE = ofd.FileName;
            pb_IMAGE.Image = Image.FromFile(IMAGE);
            pb_IMAGE.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_IMAGE.Refresh();
            
            //:Image is here, we can refresh and do other operations.
            btn_Refresh.Enabled = true;
            btn_Export.Enabled  = true;
            btn_BLKWHT.Enabled  = true;
            btn_GRYSCL.Enabled     = true;
            nud_BWSCALE.Enabled    = true;
            btn_BLKWHTAUTO.Enabled = true;
            ButtonsEnabled(true);
          }//:end if
          #endregion
        }
        #endregion

        #region Enable or disable buttons
        /// <summary>
        /// turns on or off the buttons based on Paramter->option
        /// </summary>
        /// <param name="option"></param>
        private void ButtonsEnabled(bool option)
        {
          //:RGB
          btn_BLUE.Enabled   = option;
          btn_RED.Enabled    = option;
          btn_GREEN.Enabled  = option;

          //:REMOVE RGB
          btn_GB.Enabled = option;
          btn_BR.Enabled = option;
          btn_RG.Enabled = option;       

          //:Black/white/greyscale operations
          //btn_BLKWHT.Enabled     = option;
          //btn_GRYSCL.Enabled     = option;
          //nud_BWSCALE.Enabled    = option;
          //btn_BLKWHTAUTO.Enabled = option;
        }
        #endregion

        #region Refresh image function
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
          //:Refresh the image.
          pb_IMAGE.Image = Image.FromFile(IMAGE);
          pb_IMAGE.Refresh();
          ButtonsEnabled(true);//:Image can be edited again.
          btn_BLKWHT.Enabled     = true;
          btn_GRYSCL.Enabled     = true;
          nud_BWSCALE.Enabled    = true;
          btn_BLKWHTAUTO.Enabled = true;
        }
        #endregion

        #region Removal of all but 1 colour functions.
        private void btn_BLUE_Click(object sender, EventArgs e)
        {
          #region Take the red and green out of the image.
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);
          Color blue;

          for(int i = 1; i < pb_IMAGE.Image.Width; i++)
            for(int j = 1; j < pb_IMAGE.Image.Height; j++)
            {
              //:Get the blue level of the image and set the image to that.
              blue = Color.FromArgb(0, 0, newimg.GetPixel(i, j).B);
              newimg.SetPixel(i, j, blue);
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion
          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
        }

        private void btn_GREEN_Click(object sender, EventArgs e)
        {
          #region Take the red and blue out of the image.
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);
          Color green;

          for (int i = 1; i < pb_IMAGE.Image.Width; i++)
            for (int j = 1; j < pb_IMAGE.Image.Height; j++)
            {
              //:Get the green level of the image and set the image to that.
              green = Color.FromArgb(0, newimg.GetPixel(i,j).G, 0);
              newimg.SetPixel(i, j, green);
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion
          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
        }

        private void btn_RED_Click(object sender, EventArgs e)
        {
          #region Take the green and blue out of the image.
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);
          Color red;

          for (int i = 1; i < pb_IMAGE.Image.Width; i++)
            for (int j = 1; j < pb_IMAGE.Image.Height; j++)
            {
              //:Get the red level of the image and set the image to that.
              red = Color.FromArgb(newimg.GetPixel(i, j).R, 0, 0);
              newimg.SetPixel(i, j, red);
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion

          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
        }
        #endregion

        #region Removal of single colour functions.
        //:Remove Blue
        private void button1_Click(object sender, EventArgs e)
        {
          #region Leave the red and green in the image.
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);
          Color rg;

          for (int i = 1; i < pb_IMAGE.Image.Width; i++)
            for (int j = 1; j < pb_IMAGE.Image.Height; j++)
            {
              //:Get the red/green level of the image and set the image to that.
              rg = Color.FromArgb(newimg.GetPixel(i, j).R, newimg.GetPixel(i, j).G, 0);
              newimg.SetPixel(i, j, rg);
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion
          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
        }

        //:Remove green
        private void btn_BR_Click(object sender, EventArgs e)
        {
          #region Leave the blue and red in the image.
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);
          Color br;

          for (int i = 1; i < pb_IMAGE.Image.Width; i++)
            for (int j = 1; j < pb_IMAGE.Image.Height; j++)
            {
              //:Get the blue/red level of the image and set the image to that.
              br = Color.FromArgb(newimg.GetPixel(i, j).R, 0, newimg.GetPixel(i, j).B);
              newimg.SetPixel(i, j, br);
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion
          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
        }

        //:Remove red
        private void btn_GB_Click(object sender, EventArgs e)
        {
          #region Leave the blue and green in the image.
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);
          Color gb;

          for (int i = 1; i < pb_IMAGE.Image.Width; i++)
            for (int j = 1; j < pb_IMAGE.Image.Height; j++)
            {
              //:Get the blue/green level of the image and set the image to that.
              gb = Color.FromArgb(0, newimg.GetPixel(i, j).G, newimg.GetPixel(i, j).B);
              newimg.SetPixel(i, j, gb);
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion
          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
        }
        #endregion

        #region EXPORT function
        private string CheckExistingFilename(string filename, int i)
        {
          string filename1 = IMAGE.Substring(0, IMAGE.Length - 4) + "_CCd" + i + IMAGE.Substring(IMAGE.Length - 4);

          if (File.Exists(filename1))
            return CheckExistingFilename(filename1, i + 1);

          return filename1;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
          //:Save the file.
          string filename = IMAGE.Substring(0, IMAGE.Length - 4) + "_CCd" + IMAGE.Substring(IMAGE.Length - 4);

          if (File.Exists(filename))
            filename = CheckExistingFilename(filename, 1);


          Image i = pb_IMAGE.Image;
          i.Save(filename);

          //:See if they want to view it.
          if (DialogResult.Yes == MessageBox.Show("Would you like to view your new image?", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            System.Diagnostics.Process.Start(@"" + filename);
        }
        #endregion

        #region Black and White based functions : Including Grayscale
        private void btn_BLKWHT_Click(object sender, EventArgs e)
        {
          #region Make image black and white.
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);
          Color bw;
          float total;

          for (int i = 1; i < pb_IMAGE.Image.Width; i++)
            for (int j = 1; j < pb_IMAGE.Image.Height; j++)
            {
              //::check to see if it is more black or white.
              total = (newimg.GetPixel(i, j).R + newimg.GetPixel(i, j).G + newimg.GetPixel(i, j).B)/2.0f;

              if (total < (float)nud_BWSCALE.Value)
                bw = Color.Black;
              else
                bw = Color.White;

              //::Set new pixel to black or white
              newimg.SetPixel(i, j, bw);
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion
          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
          btn_BLKWHT.Enabled     = false;
          btn_GRYSCL.Enabled     = false;
          nud_BWSCALE.Enabled    = false;
          btn_BLKWHTAUTO.Enabled = false;
        }


        #region Thread for Auto BlackWhite
        private void BWAUTO_TH()
        {
          #region Make image black and white.
          Bitmap newimg;
          Color bw;

          //:Good values that I have found to be good with different images.
          int[] bw_values = { 50, 85, 100, 135, 155, 185, 225, 265, 300, 325, 382, 400, 425, 464, 500 };
          int bw_current = 10,
                bw_max = 12;

          float total;
          long px_black;

          bool done = false;

          //:This is where it gets more complicated.
          //:Since the user chose Auto, we need to get the one with the best ratio of blk : white.

          do
          {
            //:Instantiate black pixel count to 0.
            px_black = 0;
            newimg = new Bitmap(pb_IMAGE.Image);


            //:Same old same old comparisons.
            for (int i = 1; i < pb_IMAGE.Image.Width; i++)
              for (int j = 1; j < pb_IMAGE.Image.Height; j++)
              {
                //::check to see if it is more black or white.
                total = (newimg.GetPixel(i, j).R + newimg.GetPixel(i, j).G + newimg.GetPixel(i, j).B) / 2.0f;

                if (total < bw_values[bw_current])
                {
                  bw = Color.Black;
                  px_black++;
                }
                else
                  bw = Color.White;

                //::Set new pixel to black or white
                newimg.SetPixel(i, j, bw);
              }

            //:Now for the tricky part, deciding where to test next
            total = 1.0f * px_black;
            total /= (newimg.Width * newimg.Height * 1.0f);

            //:For a nice general look we want the black to white ratio to be roughly 2:1 or 1:2
            if (total > 0.55f)
              bw_current--;
            else if (total < 0.30f)
              bw_current++;
            else
              done = true;

            if (bw_current == 0 || bw_current == bw_max) done = true;

          } while (!done);
          #endregion

          //:Set the new image to show.
          bp = newimg;
          ready = true;
        }
        #endregion

        #region Timer because C# is stupid about threading.
        private void t_Tick(object sender, EventArgs e)
        {
          if (ready)
          {
            this.Text = "Image Colour Changer";
            pb_IMAGE.Image = bp;

            ButtonsEnabled(false);

            btn_Refresh.Enabled = true;
            btn_newIMG.Enabled  = true;
            btn_Export.Enabled  = true;

            ((System.Windows.Forms.Timer)sender).Stop();
          }
        }
        #endregion

        private void btn_BLKWHTAUTO_Click(object sender, EventArgs e)
        {
          //:Let them know this is a larger operation.
          this.Text = "Please be patient, this is a larger comparison.";

          //:We do NOT want them clicking while the thread is running.
          ButtonsEnabled(false);
          btn_Refresh.Enabled    = false;
          btn_newIMG.Enabled     = false;
          btn_Export.Enabled     = false;
          btn_GRYSCL.Enabled     = false;
          btn_BLKWHT.Enabled     = false;
          nud_BWSCALE.Enabled    = false;
          btn_BLKWHTAUTO.Enabled = false;
          ready = false; //:Not ready to continue other functions. [excluding this]

          //:Start a timer along with a thread to multithread the process gargling AutoBW
          System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
          t.Interval = 1000;
          t.Tick += new EventHandler(t_Tick);

          Thread th = new Thread(new ThreadStart(BWAUTO_TH));
          t.Start();
          th.Start();
        }   

        #region RGB to Grayscale
        /// <summary>
        ///   Method to turn regular RGB into grayscale.
        /// </summary>
        /// <param name="c">The colour to be turned to grayscale.</param>
        /// <returns></returns>
        private Color RGBtoGRAY(Color c)
        {
          //:We want brightness ONLY, for grayscale.
          int brightness = (int)Math.Min(c.GetBrightness() * 256, 255.0f);
          
          //:We want grayscale.
          int r = brightness, g = brightness, b = brightness;

          //:Return the grayscale colour.
          return Color.FromArgb(r, g, b);
        }
        #endregion

        private void btn_GRYSCL_Click(object sender, EventArgs e)
        {
          #region Make image grayscale
          Bitmap newimg = new Bitmap(pb_IMAGE.Image);

          for (int i = 1; i < pb_IMAGE.Image.Width; i++)
            for (int j = 1; j < pb_IMAGE.Image.Height; j++)
            { 
              //::Set new pixel to grayscale
              newimg.SetPixel(i, j, RGBtoGRAY(newimg.GetPixel(i,j)));
            }

          //:Set the new image to show.
          pb_IMAGE.Image = newimg;
          #endregion
          //:You can not make an only colour image a seperate colour
          ButtonsEnabled(false);
          btn_GRYSCL.Enabled = false;
        }
        #endregion
    }
}
