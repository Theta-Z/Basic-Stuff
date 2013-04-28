namespace Color_Changer_v2._0
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_NEWIMG = new System.Windows.Forms.ToolStripMenuItem();
      this.exportCurrentImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_EXPORTOLD = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_EXPORTNEW = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_REFRESHIMG = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_EXIT = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_BW = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_GRYSCL = new System.Windows.Forms.ToolStripMenuItem();
      this.removeColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_HELP = new System.Windows.Forms.ToolStripMenuItem();
      this.ts_ABOUT = new System.Windows.Forms.ToolStripMenuItem();
      this.pb_IMG = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btn_BRUSHLINE2 = new System.Windows.Forms.Button();
      this.btn_BRUSHLINE = new System.Windows.Forms.Button();
      this.btn_BRUSHSQUARE = new System.Windows.Forms.Button();
      this.lb_BRSH = new System.Windows.Forms.Label();
      this.lb_SIZEPX = new System.Windows.Forms.Label();
      this.lb_SIZE = new System.Windows.Forms.Label();
      this.tb_BRUSHSIZE = new System.Windows.Forms.TrackBar();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb_IMG)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tb_BRUSHSIZE)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_NEWIMG,
            this.exportCurrentImageToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ts_REFRESHIMG,
            this.ts_EXIT});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // ts_NEWIMG
      // 
      this.ts_NEWIMG.Name = "ts_NEWIMG";
      this.ts_NEWIMG.Size = new System.Drawing.Size(186, 22);
      this.ts_NEWIMG.Text = "New Image";
      this.ts_NEWIMG.Click += new System.EventHandler(this.ts_NEWIMG_Click);
      // 
      // exportCurrentImageToolStripMenuItem
      // 
      this.exportCurrentImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_EXPORTOLD,
            this.ts_EXPORTNEW});
      this.exportCurrentImageToolStripMenuItem.Name = "exportCurrentImageToolStripMenuItem";
      this.exportCurrentImageToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.exportCurrentImageToolStripMenuItem.Text = "Export Current Image";
      // 
      // ts_EXPORTOLD
      // 
      this.ts_EXPORTOLD.Name = "ts_EXPORTOLD";
      this.ts_EXPORTOLD.Size = new System.Drawing.Size(182, 22);
      this.ts_EXPORTOLD.Text = "Overwrite old Image";
      this.ts_EXPORTOLD.Click += new System.EventHandler(this.ts_EXPORTOLD_Click);
      // 
      // ts_EXPORTNEW
      // 
      this.ts_EXPORTNEW.Name = "ts_EXPORTNEW";
      this.ts_EXPORTNEW.Size = new System.Drawing.Size(182, 22);
      this.ts_EXPORTNEW.Text = "Export to new Image";
      this.ts_EXPORTNEW.Click += new System.EventHandler(this.ts_EXPORTNEW_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
      this.toolStripMenuItem2.Text = "==============";
      // 
      // ts_REFRESHIMG
      // 
      this.ts_REFRESHIMG.Name = "ts_REFRESHIMG";
      this.ts_REFRESHIMG.Size = new System.Drawing.Size(186, 22);
      this.ts_REFRESHIMG.Text = "Refresh Image";
      this.ts_REFRESHIMG.Click += new System.EventHandler(this.ts_REFRESHIMG_Click);
      // 
      // ts_EXIT
      // 
      this.ts_EXIT.Name = "ts_EXIT";
      this.ts_EXIT.Size = new System.Drawing.Size(186, 22);
      this.ts_EXIT.Text = "Exit";
      this.ts_EXIT.Click += new System.EventHandler(this.ts_EXIT_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_BW,
            this.ts_GRYSCL,
            this.removeColourToolStripMenuItem});
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
      this.toolStripMenuItem1.Text = "Image";
      // 
      // ts_BW
      // 
      this.ts_BW.Name = "ts_BW";
      this.ts_BW.Size = new System.Drawing.Size(159, 22);
      this.ts_BW.Text = "Black and White";
      this.ts_BW.Click += new System.EventHandler(this.ts_BW_Click);
      // 
      // ts_GRYSCL
      // 
      this.ts_GRYSCL.Name = "ts_GRYSCL";
      this.ts_GRYSCL.Size = new System.Drawing.Size(159, 22);
      this.ts_GRYSCL.Text = "Grayscale";
      this.ts_GRYSCL.Click += new System.EventHandler(this.ts_GRYSCL_Click);
      // 
      // removeColourToolStripMenuItem
      // 
      this.removeColourToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem});
      this.removeColourToolStripMenuItem.Name = "removeColourToolStripMenuItem";
      this.removeColourToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
      this.removeColourToolStripMenuItem.Text = "Remove Colour";
      // 
      // redToolStripMenuItem
      // 
      this.redToolStripMenuItem.Name = "redToolStripMenuItem";
      this.redToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
      this.redToolStripMenuItem.Text = "Red";
      // 
      // greenToolStripMenuItem
      // 
      this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
      this.greenToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
      this.greenToolStripMenuItem.Text = "Green";
      // 
      // blueToolStripMenuItem
      // 
      this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
      this.blueToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
      this.blueToolStripMenuItem.Text = "Blue";
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.toolsToolStripMenuItem.Text = "Tools";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_HELP,
            this.ts_ABOUT});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // ts_HELP
      // 
      this.ts_HELP.Name = "ts_HELP";
      this.ts_HELP.Size = new System.Drawing.Size(107, 22);
      this.ts_HELP.Text = "Help";
      this.ts_HELP.Click += new System.EventHandler(this.ts_HELP_Click);
      // 
      // ts_ABOUT
      // 
      this.ts_ABOUT.Name = "ts_ABOUT";
      this.ts_ABOUT.Size = new System.Drawing.Size(107, 22);
      this.ts_ABOUT.Text = "About";
      this.ts_ABOUT.Click += new System.EventHandler(this.ts_ABOUT_Click);
      // 
      // pb_IMG
      // 
      this.pb_IMG.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.pb_IMG.Location = new System.Drawing.Point(0, 27);
      this.pb_IMG.Name = "pb_IMG";
      this.pb_IMG.Size = new System.Drawing.Size(960, 540);
      this.pb_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pb_IMG.TabIndex = 1;
      this.pb_IMG.TabStop = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btn_BRUSHLINE2);
      this.groupBox1.Controls.Add(this.btn_BRUSHLINE);
      this.groupBox1.Controls.Add(this.btn_BRUSHSQUARE);
      this.groupBox1.Controls.Add(this.lb_BRSH);
      this.groupBox1.Controls.Add(this.lb_SIZEPX);
      this.groupBox1.Controls.Add(this.lb_SIZE);
      this.groupBox1.Controls.Add(this.tb_BRUSHSIZE);
      this.groupBox1.Location = new System.Drawing.Point(962, 27);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(44, 551);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      // 
      // btn_BRUSHLINE2
      // 
      this.btn_BRUSHLINE2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BRUSHLINE2.BackgroundImage")));
      this.btn_BRUSHLINE2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btn_BRUSHLINE2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btn_BRUSHLINE2.Location = new System.Drawing.Point(6, 77);
      this.btn_BRUSHLINE2.Name = "btn_BRUSHLINE2";
      this.btn_BRUSHLINE2.Size = new System.Drawing.Size(32, 23);
      this.btn_BRUSHLINE2.TabIndex = 6;
      this.btn_BRUSHLINE2.UseVisualStyleBackColor = true;
      this.btn_BRUSHLINE2.Click += new System.EventHandler(this.btn_BRUSHLINE2_Click);
      // 
      // btn_BRUSHLINE
      // 
      this.btn_BRUSHLINE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BRUSHLINE.BackgroundImage")));
      this.btn_BRUSHLINE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btn_BRUSHLINE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btn_BRUSHLINE.Location = new System.Drawing.Point(6, 48);
      this.btn_BRUSHLINE.Name = "btn_BRUSHLINE";
      this.btn_BRUSHLINE.Size = new System.Drawing.Size(32, 23);
      this.btn_BRUSHLINE.TabIndex = 5;
      this.btn_BRUSHLINE.UseVisualStyleBackColor = true;
      this.btn_BRUSHLINE.Click += new System.EventHandler(this.btn_BRUSHLINE_Click);
      // 
      // btn_BRUSHSQUARE
      // 
      this.btn_BRUSHSQUARE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BRUSHSQUARE.BackgroundImage")));
      this.btn_BRUSHSQUARE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btn_BRUSHSQUARE.Location = new System.Drawing.Point(6, 19);
      this.btn_BRUSHSQUARE.Name = "btn_BRUSHSQUARE";
      this.btn_BRUSHSQUARE.Size = new System.Drawing.Size(32, 23);
      this.btn_BRUSHSQUARE.TabIndex = 4;
      this.btn_BRUSHSQUARE.UseVisualStyleBackColor = true;
      this.btn_BRUSHSQUARE.Click += new System.EventHandler(this.btn_BRUSHSQUARE_Click);
      // 
      // lb_BRSH
      // 
      this.lb_BRSH.AutoSize = true;
      this.lb_BRSH.Location = new System.Drawing.Point(1, 0);
      this.lb_BRSH.Name = "lb_BRSH";
      this.lb_BRSH.Size = new System.Drawing.Size(34, 13);
      this.lb_BRSH.TabIndex = 3;
      this.lb_BRSH.Text = "Brush";
      // 
      // lb_SIZEPX
      // 
      this.lb_SIZEPX.AutoSize = true;
      this.lb_SIZEPX.Location = new System.Drawing.Point(5, 199);
      this.lb_SIZEPX.Name = "lb_SIZEPX";
      this.lb_SIZEPX.Size = new System.Drawing.Size(24, 13);
      this.lb_SIZEPX.TabIndex = 2;
      this.lb_SIZEPX.Text = "5px";
      // 
      // lb_SIZE
      // 
      this.lb_SIZE.AutoSize = true;
      this.lb_SIZE.Location = new System.Drawing.Point(3, 181);
      this.lb_SIZE.Name = "lb_SIZE";
      this.lb_SIZE.Size = new System.Drawing.Size(37, 13);
      this.lb_SIZE.TabIndex = 1;
      this.lb_SIZE.Text = "_size_";
      // 
      // tb_BRUSHSIZE
      // 
      this.tb_BRUSHSIZE.Location = new System.Drawing.Point(6, 211);
      this.tb_BRUSHSIZE.Maximum = 50;
      this.tb_BRUSHSIZE.Minimum = 1;
      this.tb_BRUSHSIZE.Name = "tb_BRUSHSIZE";
      this.tb_BRUSHSIZE.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.tb_BRUSHSIZE.Size = new System.Drawing.Size(45, 334);
      this.tb_BRUSHSIZE.TabIndex = 0;
      this.tb_BRUSHSIZE.Value = 1;
      this.tb_BRUSHSIZE.Scroll += new System.EventHandler(this.tb_BRUSHSIZE_Scroll);
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1008, 642);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pb_IMG);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(1024, 680);
      this.MinimumSize = new System.Drawing.Size(1024, 680);
      this.Name = "Form1";
      this.Text = "Image Colour Changer v2.0";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb_IMG)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tb_BRUSHSIZE)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ts_NEWIMG;
    private System.Windows.Forms.ToolStripMenuItem exportCurrentImageToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem ts_REFRESHIMG;
    private System.Windows.Forms.ToolStripMenuItem ts_EXIT;
    private System.Windows.Forms.ToolStripMenuItem ts_EXPORTOLD;
    private System.Windows.Forms.ToolStripMenuItem ts_EXPORTNEW;
    private System.Windows.Forms.PictureBox pb_IMG;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem ts_BW;
    private System.Windows.Forms.ToolStripMenuItem ts_GRYSCL;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lb_BRSH;
    private System.Windows.Forms.Label lb_SIZEPX;
    private System.Windows.Forms.Label lb_SIZE;
    private System.Windows.Forms.TrackBar tb_BRUSHSIZE;
    private System.Windows.Forms.Button btn_BRUSHLINE;
    private System.Windows.Forms.Button btn_BRUSHSQUARE;
    private System.Windows.Forms.Button btn_BRUSHLINE2;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ts_HELP;
    private System.Windows.Forms.ToolStripMenuItem ts_ABOUT;
    private System.Windows.Forms.ToolStripMenuItem removeColourToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
  }
}

