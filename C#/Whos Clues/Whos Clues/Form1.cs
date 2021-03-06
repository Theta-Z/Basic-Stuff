﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Whos_Clues
{
  public partial class Form1 : Form
  {
    #region vars
    private bool walking, thinking, right;
    private int thinkCount, walkCount, temp, YY;
    private Bitmap img, cur;
    private Random r;
    #endregion
	
    public Form1()
    {
      InitializeComponent();
      
			#region init
			r = new Random();
      thinkCount = r.Next(10) * 3 + 3;
      thinking   = true;
      walking    = false;
      right      = false;
      walkCount  = 0;
      img = new Bitmap(Image.FromFile("Settings\\stebe.png"));
			#endregion
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (DialogResult.OK == MessageBox.Show("Really close?", "Are you sure?", MessageBoxButtons.OKCancel))
        Close();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      GC.Collect();
   
			#region move sprite
      if (thinking)
      {
        if (thinkCount-- > 0)
        {
          temp = thinkCount % 3;
          cur  = img.Clone(new Rectangle(320 + ((temp) * 40), 0, 40, 81), img.PixelFormat);        
        }
        else 
        {
          thinking  = false;
          walking   = true;
          walkCount = (r.Next(7) * 7) + 7;
        }

        this.BackgroundImage = cur;
      }//:thinking
      else if (walking)
      {
        if (this.Location.X + 36 <= Screen.PrimaryScreen.WorkingArea.Left)
        {
          //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right + 32, YY);
          right = true;
        }

        if (this.Location.X >= Screen.PrimaryScreen.WorkingArea.Right)
        {
          //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right + 32, YY);
          right = false;
        }

        if (walkCount-- > 0)
        {
          temp = walkCount % 8;
          cur = img.Clone(new Rectangle((temp) * 40, 0, 40, 81), img.PixelFormat);
        }
        else
        {
          walking    = false;
          thinking   = true;
          thinkCount = (r.Next(10) * 3 + 12);
        }

        if (right)
          cur.RotateFlip(RotateFlipType.RotateNoneFlipX);

        this.BackgroundImage = cur;
        this.Location = new Point(this.Location.X + ((right) ? 4 : -4), YY);
      }//:walking 
			#endregion
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Location = new Point(10, Screen.PrimaryScreen.WorkingArea.Height - 80);
      YY = this.Location.Y;
    }
  }
}
