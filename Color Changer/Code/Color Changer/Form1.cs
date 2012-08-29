using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Color_Changer
{
    public partial class Form1 : Form
    {
      private string IMAGE;
        public Form1()
        {
          InitializeComponent();
          this.MinimizeBox = false;
          this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

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
            ButtonsEnabled(true);
          }//:end if
          #endregion
        }

      /// <summary>
      /// turns on or off the buttons based on Paramter->option
      /// </summary>
      /// <param name="option"></param>
        private void ButtonsEnabled(bool option)
        {
          btn_BLUE.Enabled   = option;
          btn_RED.Enabled    = option;
          btn_GREEN.Enabled  = option;
          btn_BR.Enabled = option;
          btn_RG.Enabled = option;
          btn_GB.Enabled = option;     
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
          //:Refresh the image.
          pb_IMAGE.Image = Image.FromFile(IMAGE);
          pb_IMAGE.Refresh();
          ButtonsEnabled(true);//:Image can be edited again.
        }

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
          //:You can not make an only red image blue / green
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
          //:You can not make an only red image blue / green
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

          //:You can not make an only red image blue / green
          ButtonsEnabled(false);
        }

      //:RedGreen
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
          //:You can not make an only red image blue / green
          ButtonsEnabled(false);
        }

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
          //:You can not make an only red image blue / green
          ButtonsEnabled(false);
        }

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
          //:You can not make an only red image blue / green
          ButtonsEnabled(false);
        }

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
    }
}
