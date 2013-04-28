using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TazLib
{
  class WindowsFormMods
  {
    #region GetMovables
    public Panel GetMovablePanel()
    {
      return new MovablePanel();
    }

    public Form GetMovableForm()
    {
      return new MovableForm();
    }

    public TabControl GetMovableTabs()
    {
      return new MovableTabs();
    }

    public GroupBox GetMovableGroupBox()
    {
      return new MovableGB();
    }
    #endregion

    #region actual movable classes
    private class MovablePanel : Panel
    {
      #region *CONST
      const int WM_NCHITTEST = 0x84;
      const int HTCLIENT = 0x1;
      const int HTCAPTION = 0x2;
      #region make movable
      protected override void WndProc(ref Message m)
      {
        switch (m.Msg)
        {
          case WM_NCHITTEST:
            base.WndProc(ref m);
            if ((int)m.Result == HTCLIENT)
              m.Result = (IntPtr)HTCAPTION;
            return;
            break;
        }
        base.WndProc(ref m);
      }
      #endregion
      #endregion
      public MovablePanel() { }
    }

    private class MovableForm : Form
    {
      #region *CONST
      private const int WM_NCHITTEST = 0x84;
      private const int HTCLIENT = 0x1;
      private const int HTCAPTION = 0x2;
      #region make movable
      protected override void WndProc(ref Message m)
      {
        switch (m.Msg)
        {
          case WM_NCHITTEST:
            base.WndProc(ref m);
            if ((int)m.Result == HTCLIENT)
              m.Result = (IntPtr)HTCAPTION;
            return;
            break;
        }
        base.WndProc(ref m);
      }
      #endregion
      #endregion
      public MovableForm() { }
    }

    private class MovableTabs : TabControl
    {
      #region *CONST
      const int WM_NCHITTEST = 0x84;
      const int HTCLIENT = 0x1;
      const int HTCAPTION = 0x2;
      #region make movable
      protected override void WndProc(ref Message m)
      {
        switch (m.Msg)
        {
          case WM_NCHITTEST:
            base.WndProc(ref m);
            if ((int)m.Result == HTCLIENT)
              m.Result = (IntPtr)HTCAPTION;
            return;
            break;
        }
        base.WndProc(ref m);
      }
      #endregion
      #endregion

      public MovableTabs() { }
    }

    private class MovableGB : GroupBox
    {
      #region *CONST
      const int WM_NCHITTEST = 0x84;
      const int HTCLIENT = 0x1;
      const int HTCAPTION = 0x2;
      #region make movable
      protected override void WndProc(ref Message m)
      {
        switch (m.Msg)
        {
          case WM_NCHITTEST:
            base.WndProc(ref m);
            if ((int)m.Result == HTCLIENT)
              m.Result = (IntPtr)HTCAPTION;
            return;
            break;
        }
        base.WndProc(ref m);
      }
      #endregion
      #endregion
      public MovableGB() { }
    }
    #endregion
  }
}


