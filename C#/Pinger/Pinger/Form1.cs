using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;

namespace Pinger
{
  public partial class Form1 : Form
  {
    private Ping pinger;
    private PingReply pr;

    public Form1()
    {
      InitializeComponent();
     // String ip = IPAddress.
      pinger = new Ping();
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      lb_MS.Text = trackBar1.Value + " ms per ping.";

      timer1.Stop();
      timer1.Interval = (int)trackBar1.Value;
      timer1.Start();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      pr = pinger.Send("google.com");

      lb_Status.Text = "Google response time: " + pr.RoundtripTime + " ms";
    }
  }
}
