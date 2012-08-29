namespace Color_Changer
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
          this.pb_IMAGE = new System.Windows.Forms.PictureBox();
          this.btn_newIMG = new System.Windows.Forms.Button();
          this.btn_GREEN = new System.Windows.Forms.Button();
          this.btn_BLUE = new System.Windows.Forms.Button();
          this.gb_Alterations = new System.Windows.Forms.GroupBox();
          this.btn_BR = new System.Windows.Forms.Button();
          this.btn_GB = new System.Windows.Forms.Button();
          this.btn_RG = new System.Windows.Forms.Button();
          this.btn_RED = new System.Windows.Forms.Button();
          this.btn_Refresh = new System.Windows.Forms.Button();
          this.btn_Export = new System.Windows.Forms.Button();
          ((System.ComponentModel.ISupportInitialize)(this.pb_IMAGE)).BeginInit();
          this.gb_Alterations.SuspendLayout();
          this.SuspendLayout();
          // 
          // pb_IMAGE
          // 
          this.pb_IMAGE.Location = new System.Drawing.Point(0, -2);
          this.pb_IMAGE.Name = "pb_IMAGE";
          this.pb_IMAGE.Size = new System.Drawing.Size(784, 480);
          this.pb_IMAGE.TabIndex = 0;
          this.pb_IMAGE.TabStop = false;
          // 
          // btn_newIMG
          // 
          this.btn_newIMG.Location = new System.Drawing.Point(7, 504);
          this.btn_newIMG.Name = "btn_newIMG";
          this.btn_newIMG.Size = new System.Drawing.Size(75, 47);
          this.btn_newIMG.TabIndex = 1;
          this.btn_newIMG.Text = "New IMG";
          this.btn_newIMG.UseVisualStyleBackColor = true;
          this.btn_newIMG.Click += new System.EventHandler(this.btn_newIMG_Click);
          // 
          // btn_GREEN
          // 
          this.btn_GREEN.Enabled = false;
          this.btn_GREEN.Location = new System.Drawing.Point(205, 16);
          this.btn_GREEN.Name = "btn_GREEN";
          this.btn_GREEN.Size = new System.Drawing.Size(75, 23);
          this.btn_GREEN.TabIndex = 2;
          this.btn_GREEN.Text = "Make Green";
          this.btn_GREEN.UseVisualStyleBackColor = true;
          this.btn_GREEN.Click += new System.EventHandler(this.btn_GREEN_Click);
          // 
          // btn_BLUE
          // 
          this.btn_BLUE.Enabled = false;
          this.btn_BLUE.Location = new System.Drawing.Point(397, 16);
          this.btn_BLUE.Name = "btn_BLUE";
          this.btn_BLUE.Size = new System.Drawing.Size(75, 23);
          this.btn_BLUE.TabIndex = 3;
          this.btn_BLUE.Text = "Make Blue";
          this.btn_BLUE.UseVisualStyleBackColor = true;
          this.btn_BLUE.Click += new System.EventHandler(this.btn_BLUE_Click);
          // 
          // gb_Alterations
          // 
          this.gb_Alterations.Controls.Add(this.btn_BR);
          this.gb_Alterations.Controls.Add(this.btn_GB);
          this.gb_Alterations.Controls.Add(this.btn_RG);
          this.gb_Alterations.Controls.Add(this.btn_RED);
          this.gb_Alterations.Controls.Add(this.btn_BLUE);
          this.gb_Alterations.Controls.Add(this.btn_GREEN);
          this.gb_Alterations.Location = new System.Drawing.Point(300, 484);
          this.gb_Alterations.Name = "gb_Alterations";
          this.gb_Alterations.Size = new System.Drawing.Size(482, 76);
          this.gb_Alterations.TabIndex = 4;
          this.gb_Alterations.TabStop = false;
          this.gb_Alterations.Text = "Alterations (Freezing may occur, thank you for your patience)";
          // 
          // btn_BR
          // 
          this.btn_BR.Enabled = false;
          this.btn_BR.Location = new System.Drawing.Point(205, 43);
          this.btn_BR.Name = "btn_BR";
          this.btn_BR.Size = new System.Drawing.Size(75, 23);
          this.btn_BR.TabIndex = 7;
          this.btn_BR.Text = "Make BR";
          this.btn_BR.UseVisualStyleBackColor = true;
          this.btn_BR.Click += new System.EventHandler(this.btn_BR_Click);
          // 
          // btn_GB
          // 
          this.btn_GB.Enabled = false;
          this.btn_GB.Location = new System.Drawing.Point(346, 43);
          this.btn_GB.Name = "btn_GB";
          this.btn_GB.Size = new System.Drawing.Size(75, 23);
          this.btn_GB.TabIndex = 6;
          this.btn_GB.Text = "Make GB";
          this.btn_GB.UseVisualStyleBackColor = true;
          this.btn_GB.Click += new System.EventHandler(this.btn_GB_Click);
          // 
          // btn_RG
          // 
          this.btn_RG.Enabled = false;
          this.btn_RG.Location = new System.Drawing.Point(60, 43);
          this.btn_RG.Name = "btn_RG";
          this.btn_RG.Size = new System.Drawing.Size(75, 23);
          this.btn_RG.TabIndex = 5;
          this.btn_RG.Text = "Make RG";
          this.btn_RG.UseVisualStyleBackColor = true;
          this.btn_RG.Click += new System.EventHandler(this.button1_Click);
          // 
          // btn_RED
          // 
          this.btn_RED.Enabled = false;
          this.btn_RED.Location = new System.Drawing.Point(14, 16);
          this.btn_RED.Name = "btn_RED";
          this.btn_RED.Size = new System.Drawing.Size(75, 23);
          this.btn_RED.TabIndex = 4;
          this.btn_RED.Text = "Make Red";
          this.btn_RED.UseVisualStyleBackColor = true;
          this.btn_RED.Click += new System.EventHandler(this.btn_RED_Click);
          // 
          // btn_Refresh
          // 
          this.btn_Refresh.Enabled = false;
          this.btn_Refresh.Location = new System.Drawing.Point(219, 504);
          this.btn_Refresh.Name = "btn_Refresh";
          this.btn_Refresh.Size = new System.Drawing.Size(75, 47);
          this.btn_Refresh.TabIndex = 5;
          this.btn_Refresh.Text = "Refresh";
          this.btn_Refresh.UseVisualStyleBackColor = true;
          this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
          // 
          // btn_Export
          // 
          this.btn_Export.Enabled = false;
          this.btn_Export.Location = new System.Drawing.Point(88, 504);
          this.btn_Export.Name = "btn_Export";
          this.btn_Export.Size = new System.Drawing.Size(75, 47);
          this.btn_Export.TabIndex = 6;
          this.btn_Export.Text = "Export IMG";
          this.btn_Export.UseVisualStyleBackColor = true;
          this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(784, 562);
          this.Controls.Add(this.btn_Export);
          this.Controls.Add(this.btn_Refresh);
          this.Controls.Add(this.gb_Alterations);
          this.Controls.Add(this.btn_newIMG);
          this.Controls.Add(this.pb_IMAGE);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximumSize = new System.Drawing.Size(800, 600);
          this.MinimumSize = new System.Drawing.Size(800, 600);
          this.Name = "Form1";
          this.Text = "Image Colour Changer";
          this.Load += new System.EventHandler(this.Form1_Load);
          ((System.ComponentModel.ISupportInitialize)(this.pb_IMAGE)).EndInit();
          this.gb_Alterations.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_IMAGE;
        private System.Windows.Forms.Button btn_newIMG;
        private System.Windows.Forms.Button btn_GREEN;
        private System.Windows.Forms.Button btn_BLUE;
        private System.Windows.Forms.GroupBox gb_Alterations;
        private System.Windows.Forms.Button btn_RED;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_BR;
        private System.Windows.Forms.Button btn_GB;
        private System.Windows.Forms.Button btn_RG;
        private System.Windows.Forms.Button btn_Export;
    }
}

