namespace Pinger
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.label1 = new System.Windows.Forms.Label();
      this.lb_Status = new System.Windows.Forms.Label();
      this.lb_MS = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 104);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(40, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Status:";
      // 
      // lb_Status
      // 
      this.lb_Status.AutoSize = true;
      this.lb_Status.Location = new System.Drawing.Point(58, 104);
      this.lb_Status.Name = "lb_Status";
      this.lb_Status.Size = new System.Drawing.Size(13, 13);
      this.lb_Status.TabIndex = 1;
      this.lb_Status.Text = "--";
      // 
      // lb_MS
      // 
      this.lb_MS.AutoSize = true;
      this.lb_MS.Location = new System.Drawing.Point(12, 60);
      this.lb_MS.Name = "lb_MS";
      this.lb_MS.Size = new System.Drawing.Size(13, 13);
      this.lb_MS.TabIndex = 2;
      this.lb_MS.Text = "--";
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // trackBar1
      // 
      this.trackBar1.LargeChange = 50;
      this.trackBar1.Location = new System.Drawing.Point(2, 12);
      this.trackBar1.Maximum = 1000;
      this.trackBar1.Minimum = 10;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(333, 45);
      this.trackBar1.TabIndex = 3;
      this.trackBar1.TickFrequency = 20;
      this.trackBar1.Value = 10;
      this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(338, 126);
      this.Controls.Add(this.trackBar1);
      this.Controls.Add(this.lb_MS);
      this.Controls.Add(this.lb_Status);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(354, 164);
      this.MinimumSize = new System.Drawing.Size(354, 164);
      this.Name = "Form1";
      this.Text = "PINGUS!";
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lb_Status;
    private System.Windows.Forms.Label lb_MS;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.TrackBar trackBar1;
  }
}

