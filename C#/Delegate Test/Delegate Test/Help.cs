using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Delegate_Test
{
  public partial class Help : Form
  {
    public Help()
    {
      InitializeComponent();
    }

    private void Help_Load(object sender, EventArgs e)
    {
      webBrowser1.Navigate("file:///" + Directory.GetCurrentDirectory() + "/doc.xml");
    }
  }
}
