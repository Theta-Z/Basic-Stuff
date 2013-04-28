using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;

namespace Color_Changer_v2._0
{
  public partial class Form1 : Form
  {
    #region Variables
    private int brush_px, brush_type;
    private string filename;
    private bool ready, mousedwn;
    private Graphics g;
    private Bitmap bp, old;
    private System.Windows.Forms.Timer processing;
    #endregion

    #region Constructor / Loading
    public Form1()
    {
      InitializeComponent();
      //:Allow drag and drop for images.
      DragDrop += new DragEventHandler(pb_IMG_DragDrop);
      DragEnter += new DragEventHandler(pb_IMG_DragEnter);


      ready = false;
      mousedwn = false;
      brush_px = 5;
      brush_type = 1; //: 1 is square, 2 is line
      bp = new Bitmap(1, 1);

      //:Setup the processing timer.
      processing = new System.Windows.Forms.Timer();
      processing.Tick += new EventHandler(processing_Tick);

      //:Setup the mouse events
      pb_IMG.MouseDown += new MouseEventHandler(pb_IMG_MouseDown);
      pb_IMG.MouseUp   += new MouseEventHandler(pb_IMG_MouseUp);
      pb_IMG.MouseMove += new MouseEventHandler(pb_IMG_MouseMove);
    }
    
    #endregion

    #region Self-Defined events
    private void THREAD_AREA(MouseEventArgs e)
    {
      if (g != null) g.Dispose();
      g = pb_IMG.CreateGraphics();

      //:Draw a rectangle around where we will use.
      switch (brush_type)
      {
        //:Square
        case 1:
          g.DrawRectangle(new Pen(Color.Black, 2), e.Location.X - brush_px * ((pb_IMG.Width * 1.0f) / pb_IMG.Image.Width),
                                                   e.Location.Y - brush_px * ((pb_IMG.Height * 1.0f) / pb_IMG.Image.Height),
                                                   brush_px * 2 * ((pb_IMG.Width * 1.0f) / pb_IMG.Image.Width),
                                                   brush_px * 2 * ((pb_IMG.Height * 1.0f) / pb_IMG.Image.Height));
          break;

        //:Horiz. Line
        case 2:
          g.DrawRectangle(new Pen(Color.Black, 2), e.Location.X - brush_px * ((pb_IMG.Width * 1.0f) / pb_IMG.Image.Width),
                                                   e.Location.Y - brush_px * ((pb_IMG.Height * 1.0f) / pb_IMG.Image.Height) / 4,
                                                   brush_px * 2 * ((pb_IMG.Width * 1.0f) / pb_IMG.Image.Width),
                                                   brush_px * 2 * ((pb_IMG.Height * 1.0f) / pb_IMG.Image.Height) / 4);
          break;

        //:Vert. Line
        case 3:
          g.DrawRectangle(new Pen(Color.Black, 2), e.Location.X - brush_px * ((pb_IMG.Width * 1.0f) / pb_IMG.Image.Width) / 4,
                                               e.Location.Y - brush_px * ((pb_IMG.Height * 1.0f) / pb_IMG.Image.Height),
                                               brush_px * 2 * ((pb_IMG.Width * 1.0f) / pb_IMG.Image.Width) / 4,
                                               brush_px * 2 * ((pb_IMG.Height * 1.0f) / pb_IMG.Image.Height));
          break;
      }
    }

    void pb_IMG_MouseMove(object sender, MouseEventArgs e)
    {
      if(!ready)return;

      //:Show where the effect will be applied
      if (old == null) 
        old = new Bitmap(pb_IMG.Image);

      pb_IMG.Image.Dispose();
      pb_IMG.Image = (Bitmap)old.Clone();

      //:Area of effect for showing where to apply effect
      THREAD_AREA(e);
      //:END EFFECT APPLY AREA

      if(mousedwn)
      {
        //switch(SELECTED_TYPE)
        //{
        //}

        //:For now we will only test grayscale.
        int x = (int)(e.Location.X * ((pb_IMG.Image.Width * 1.0f) /pb_IMG.Width));
        int y = (int)(e.Location.Y * ((pb_IMG.Image.Height * 1.0f) /pb_IMG.Height));

        //:We are working, not ready anymore!
        ready = false; 
        bp = new Bitmap(old);

        //:Freeup OLD memory and prepare for new use
        old.Dispose();
        old = null;

        //:Variables for below computations
        int r, g, b, gray, tempx, tempy, low_x = 1, high_x = 1, low_y = 1, high_y = 1;
        Color c;

        #region calculations and plotting
        switch (brush_type)
        {
          //:Square brush
          case 1:
            low_x  = Math.Max(x - brush_px - 1, 1);
            high_x = Math.Max(x + brush_px - 1, 1);

            low_y  = Math.Max(y - brush_px - 1, 1);
            high_y = Math.Max(y + brush_px - 1, 1);
          break;

          //:Horiz Line brush
          case 2:
            low_x  = Math.Max(x - brush_px - 1, 0);
            high_x = Math.Max(x + brush_px - 1, 0);

            low_y  = Math.Max(y - (brush_px / 4) - 1, 1);
            high_y = Math.Max(y + (brush_px / 4) - 1, 1);
          break;

          //:Vert Line brush
          case 3:
            low_x = Math.Max(x - (brush_px / 4) - 1, 0);
            high_x = Math.Max(x + (brush_px / 4) - 1, 0);

            low_y  = Math.Max(y - brush_px - 1, 1);
            high_y = Math.Max(y + brush_px - 1, 1);
          break;
        }

        //:In a square, we will make a section of this image grayscale.
        for (int i = low_x; i < high_x; i++)
          for (int j = low_y; j < high_y; j++)
          {
            #region GRAYSCALE
            tempx = i;
            tempy = j;

            //:Make sure we dont go out of bounds.
            if (tempx >= bp.Width)
              tempx = bp.Width - 1;

            if (tempy >= bp.Height - 1)
              tempy = bp.Height - 1;

            //:This area will have a switch
            //:For each type of painting.
            c = bp.GetPixel(tempx, tempy);
            gray = ((c.R + c.G + c.B) / 3);
            c = Color.FromArgb(gray, gray, gray);
            #endregion
            bp.SetPixel(tempx, tempy, c);
          }
        #endregion
        //:Ready to show and do more operations!
        ready = true;
        pb_IMG.Image.Dispose();
        pb_IMG.Image = (Bitmap)bp.Clone();
        bp.Dispose();
        //bp = new Bitmap(pb_IMG.Image);
      }
    }

    void pb_IMG_MouseUp(object sender, MouseEventArgs e)
    {
      mousedwn = false; 
    }

    void pb_IMG_MouseDown(object sender, MouseEventArgs e)
    {
      mousedwn = true;
    }  

    void processing_Tick(object sender, EventArgs e)
    {
      if (ready)
      {
        pb_IMG.Image.Dispose();
        pb_IMG.Image = (Image)bp.Clone();
        bp.Dispose();
        if (old != null)
        {
          old.Dispose();
          old = null;
        }
        processing.Stop();
      }
    }

    void pb_IMG_DragEnter(object sender, DragEventArgs e)
    {
      //:Required for Drag and drop.
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Move;
    }

    void pb_IMG_DragDrop(object sender, DragEventArgs e)
    {
      //:Get the filename of the DragDrop file.
      Array file_arr = (Array)e.Data.GetData("FileName");

      //:Make sure this is valid.
      if(file_arr != null)
        if (file_arr.Length == 1 && file_arr.GetValue(0) is string)
        {
          //:The above if is to make sure we have the filename.
          //:Below- Make sure this is an image we can work with.
          string extension = Path.GetExtension(((string[])file_arr)[0]).ToLower();

          if (extension.Equals(".png") || extension.Equals(".jpg") || extension.Equals(".bmp") || extension.Equals(".gif"))
          {
            //:We "should" have the filename now.
            //:-Cast the Data from DragArgs as a string and get the first one
            //:--The filename.
            filename = ((string[])file_arr)[0];

            pb_IMG.Image = Image.FromFile(filename);
            ready = true;
          }
          else
            MessageBox.Show("Accepted file types are png, jpg, bmp, gif.", "Invalid file type!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion

    #region Non-Action methods

    private string CheckNames(string s, int i)
    {
      //:Simple way to backup files without overwriting.
      if (File.Exists(s.Substring(0, s.Length - 4) +
                     "_CCd" + i + s.Substring(s.Length - 4)))
        return CheckNames(s, i + 1);
      else
        return s.Substring(0, s.Length - 4) +
               "_CCd" + i + s.Substring(s.Length - 4);
    }

    private void SaveImg(bool OW)
    {
      if (!ready) return;
      //:Setup the image to be saved.

      string t_filename = "";

      //:Save file.
      if (OW)
      {
        //:Freeup the old file for usage.
        //:AKA store it in memory.
        bp = new Bitmap(pb_IMG.Image.Width, pb_IMG.Image.Height);
        Bitmap temp = new Bitmap(pb_IMG.Image);
        for (int i = 1; i < bp.Width; i++)
          for (int j = 1; j < bp.Height; j++)
            bp.SetPixel(i, j, temp.GetPixel(i, j));

        pb_IMG.Image.Dispose();
        pb_IMG.Image = bp;

        //:Over writing old file.
        bp.Save(filename);
        t_filename = filename;
      }
      else
      {
        t_filename = CheckNames(filename, 1);
        //:Making completely new file.
        bp.Save(t_filename);
      }

      //:Ask to show image
      if (DialogResult.Yes == MessageBox.Show("View output image?", "Done!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
      {
        System.Diagnostics.Process.Start(@"" + t_filename);
      }
    }
    #endregion

    #region Action methods
    #region Exit, Refresh, Save, New
    private void ts_EXIT_Click(object sender, EventArgs e)
    {
      if (DialogResult.No == MessageBox.Show("Really exit?", "EXITING", MessageBoxButtons.YesNo))
        return;

      //:EXIT ALL THREADS

      //:Ask to save current work.

      Close();
    }

    private void ts_REFRESHIMG_Click(object sender, EventArgs e)
    {
      if (!ready) return;
      pb_IMG.Image = Image.FromFile(filename);
    }

    private void ts_EXPORTNEW_Click(object sender, EventArgs e)
    {
      bp = new Bitmap(pb_IMG.Image);
      SaveImg(false);
    }

    private void ts_EXPORTOLD_Click(object sender, EventArgs e)
    {
      bp = new Bitmap(pb_IMG.Image);
      SaveImg(true);
    }

    private void ts_NEWIMG_Click(object sender, EventArgs e)
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
        filename = ofd.FileName;
        pb_IMG.Image = Image.FromFile(filename);
        ready = true;
      }
      #endregion

      #region remove 'old' image
      if (old != null)
      {
        old.Dispose();
        old = null;
      }
      #endregion
    }
    #endregion

    #region GRAYSCALE OPERATIONS
    private void GrayScale()
    {
      int gray;
      Color  c;

      for(int i = 1; i < bp.Width; i++)
        for (int j = 1; j < bp.Height; j++)
        {
          c = bp.GetPixel(i, j);
          gray = ((c.R + c.G + c.B) / 3);
          bp.SetPixel(i,j, Color.FromArgb(gray, gray, gray));
        }
      //:Ready to show the image!
      ready = true;
    }

    private void ts_GRYSCL_Click(object sender, EventArgs e)
    {
      if (!ready) return;

      //:We are now working, so we are not ready.
      ready = false;
      bp = new Bitmap(pb_IMG.Image);

      //:Start the timer for when we are done with the below thread.
      processing.Interval = 400;
      processing.Start();

      //:Thread to do grayscale.
      //:-At a later date, this may be turned into 2 threads.
      //:--One starting bottom, one top. Meet in the middle.
      //:---So far there is no reason to do this.
      Thread th = new Thread(new ThreadStart(GrayScale));
      th.Start();
    }
    #endregion//grayscale

    #endregion

    #region BRUSHES
    private void tb_BRUSHSIZE_Scroll(object sender, EventArgs e)
    {
      lb_SIZEPX.Text = tb_BRUSHSIZE.Value + "px";
      brush_px = tb_BRUSHSIZE.Value;
    }

    private void btn_BRUSHSQUARE_Click(object sender, EventArgs e)
    {
      brush_type = 1;
    }

    private void btn_BRUSHLINE_Click(object sender, EventArgs e)
    {
      brush_type = 2;
    }
    
    private void btn_BRUSHLINE2_Click(object sender, EventArgs e)
    {
      brush_type = 3;
    }
    #endregion


    #region HELP Toolstrip area
    private void ts_HELP_Click(object sender, EventArgs e)
    {
      Thread th = new Thread(() => MessageBox.Show("This program supports Drag and drop." + 
                                           "\r\nWhat this means: You can drag and drop an image file on here!\r\n" + 
                                           "Load image via drag/drop or File->New Image\r\n" + 
                                           "Then apply changed and export it via the File menu.","Help!"));
      th.Start();
    }
    
    private void ts_ABOUT_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region black/white AUTO  using OTSU
    private void BW()
    {
      int[] lvls = new int[256];
      Color c;

      #region find grayscale levels
      for (int i = 1; i < bp.Width; i++)
        for (int j = 1; j < bp.Height; j++)
        {
          c = bp.GetPixel(i, j);
          lvls[(int)((c.R + c.G + c.B) / 3)]++;
        }
      #endregion

      #region find 2 largest areas
      //:Now we have the grayscale levels.
      //:Find 2 largest areas, and set the thresh to be inbetween them.
      int largest = 0, large = 0;
      int largest_index = 0, large_index = 0;

      for (int i = 0; i < 256; i++)
      {
        //:If current is larger than 2nd largest, 2nd largest = current.
        if (lvls[i] > large)
        {
          large = lvls[i];
          large_index = i;
        }
        //:If current is larger than largest, largest = current, 2nd largest = old largest.
        if (lvls[i] > largest)
        {
          large         = largest;
          large_index   = largest_index;

          largest       = lvls[i];
          largest_index = i;
        }
      }//:end forloop

      if (largest_index < large_index)
      {
        int temp        = largest_index;
        largest_index   = large_index;
        large_index     = temp;
      }

      //:Get the average and threshold
      int total = 0;
      for (int i = large_index; i <= largest_index; i++)
        total += lvls[i];

      ulong average = 0;
      for (int i = large_index; i <= largest_index; i++)
        average += (ulong)(lvls[i] * i);

      average = average / (ulong)total;

      int THRESHOLD = Int32.Parse(average + "");
      #endregion

      #region make black and white image
      for(int i = 1; i < bp.Width; i++)
        for (int j = 1; j < bp.Height; j++)
        {
          c = bp.GetPixel(i, j);
          if (((c.R + c.B + c.G) / 3) < THRESHOLD)
          {
            //:If the grayscale is less than threshold -> White otherwise, black
            bp.SetPixel(i, j, Color.Black);
          }
          else
          {
            bp.SetPixel(i, j, Color.White);
          }
        }

      //:Done!
      ready = true;
      #endregion
    }

    private void ts_BW_Click(object sender, EventArgs e)
    {
      if (!ready) return;

      //:We are now working, so we are not ready.
      ready = false;
      bp = new Bitmap(pb_IMG.Image);

      //:Start the timer for when we are done with the below thread.
      processing.Interval = 400;
      processing.Start();

      //:Thread to do bw.
      //:-At a later date, this may be turned into 2 threads.
      //:--One starting bottom, one top. Meet in the middle.
      //:---So far there is no reason to do this.
      Thread th = new Thread(new ThreadStart(BW));
      th.Start();
    }
    #endregion
  }
}
