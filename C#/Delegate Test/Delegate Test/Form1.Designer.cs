namespace Delegate_Test
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
      this.label1 = new System.Windows.Forms.Label();
      this.btn_close = new System.Windows.Forms.Button();
      this.pnl_container = new System.Windows.Forms.Panel();
      this.btn_help = new System.Windows.Forms.Button();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.btn_append = new System.Windows.Forms.Button();
      this.gb_delegates = new System.Windows.Forms.GroupBox();
      this.lbl_result = new System.Windows.Forms.Label();
      this.btn_mult = new System.Windows.Forms.Button();
      this.btn_add = new System.Windows.Forms.Button();
      this.pnl_container.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.gb_delegates.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.PeachPuff;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(109, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Delegate Test";
      // 
      // btn_close
      // 
      this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
      this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btn_close.Location = new System.Drawing.Point(333, 5);
      this.btn_close.Name = "btn_close";
      this.btn_close.Size = new System.Drawing.Size(30, 28);
      this.btn_close.TabIndex = 1;
      this.btn_close.UseVisualStyleBackColor = true;
      this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
      // 
      // pnl_container
      // 
      this.pnl_container.BackColor = System.Drawing.Color.PeachPuff;
      this.pnl_container.Controls.Add(this.btn_help);
      this.pnl_container.Controls.Add(this.numericUpDown1);
      this.pnl_container.Controls.Add(this.btn_append);
      this.pnl_container.Controls.Add(this.gb_delegates);
      this.pnl_container.Location = new System.Drawing.Point(8, 43);
      this.pnl_container.Name = "pnl_container";
      this.pnl_container.Size = new System.Drawing.Size(354, 226);
      this.pnl_container.TabIndex = 2;
      // 
      // btn_help
      // 
      this.btn_help.Location = new System.Drawing.Point(257, 99);
      this.btn_help.Name = "btn_help";
      this.btn_help.Size = new System.Drawing.Size(89, 23);
      this.btn_help.TabIndex = 4;
      this.btn_help.Text = "Documentation";
      this.btn_help.UseVisualStyleBackColor = true;
      this.btn_help.Visible = false;
      this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(50, 33);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
      this.numericUpDown1.TabIndex = 3;
      // 
      // btn_append
      // 
      this.btn_append.Location = new System.Drawing.Point(217, 32);
      this.btn_append.Name = "btn_append";
      this.btn_append.Size = new System.Drawing.Size(75, 23);
      this.btn_append.TabIndex = 2;
      this.btn_append.Text = "Add Number";
      this.btn_append.UseVisualStyleBackColor = true;
      this.btn_append.Click += new System.EventHandler(this.button1_Click);
      // 
      // gb_delegates
      // 
      this.gb_delegates.Controls.Add(this.lbl_result);
      this.gb_delegates.Controls.Add(this.btn_mult);
      this.gb_delegates.Controls.Add(this.btn_add);
      this.gb_delegates.Location = new System.Drawing.Point(3, 128);
      this.gb_delegates.Name = "gb_delegates";
      this.gb_delegates.Size = new System.Drawing.Size(343, 84);
      this.gb_delegates.TabIndex = 1;
      this.gb_delegates.TabStop = false;
      this.gb_delegates.Text = "Delegates";
      // 
      // lbl_result
      // 
      this.lbl_result.AutoSize = true;
      this.lbl_result.Location = new System.Drawing.Point(148, 41);
      this.lbl_result.Name = "lbl_result";
      this.lbl_result.Size = new System.Drawing.Size(49, 13);
      this.lbl_result.TabIndex = 2;
      this.lbl_result.Text = "Result: --";
      this.lbl_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_mult
      // 
      this.btn_mult.Location = new System.Drawing.Point(251, 27);
      this.btn_mult.Name = "btn_mult";
      this.btn_mult.Size = new System.Drawing.Size(75, 41);
      this.btn_mult.TabIndex = 1;
      this.btn_mult.Text = "multiply";
      this.btn_mult.UseVisualStyleBackColor = true;
      this.btn_mult.Click += new System.EventHandler(this.btn_mult_Click);
      // 
      // btn_add
      // 
      this.btn_add.Location = new System.Drawing.Point(17, 27);
      this.btn_add.Name = "btn_add";
      this.btn_add.Size = new System.Drawing.Size(75, 41);
      this.btn_add.TabIndex = 0;
      this.btn_add.Text = "add";
      this.btn_add.UseVisualStyleBackColor = true;
      this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
      // 
      // Form1
      // 
      this.AcceptButton = this.btn_append;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(371, 277);
      this.Controls.Add(this.pnl_container);
      this.Controls.Add(this.btn_close);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Delegate Test";
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.pnl_container.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.gb_delegates.ResumeLayout(false);
      this.gb_delegates.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btn_close;
    private System.Windows.Forms.Panel pnl_container;
    private System.Windows.Forms.GroupBox gb_delegates;
    private System.Windows.Forms.Label lbl_result;
    private System.Windows.Forms.Button btn_mult;
    private System.Windows.Forms.Button btn_add;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Button btn_append;
    private System.Windows.Forms.Button btn_help;

  }
}

