using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Delegate_Test
{
  #region driver
  /// <summary>
  ///   Driver for our Delegate Test.
  ///   
  ///   Author: S. Copeland
  /// </summary>
  public partial class Form1 : TazLib.WindowsFormMods.MovableForm
  {
    private DelegateTest dt;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      dt = new DelegateTest();
    }

    private void btn_close_Click(object sender, EventArgs e)
    {
      GC.Collect();
      Close();
    }

    #region Delegate Buttons
    private void btn_add_Click(object sender, EventArgs e)
    {
      int result = dt.Operation(new DelegateTest.perform_operation(DelegateMethods.Add));

      lbl_result.Text = "Result:\r\n" + result;
    }

    private void btn_mult_Click(object sender, EventArgs e)
    {
      int result = dt.Operation(new DelegateTest.perform_operation(DelegateMethods.Mult));

      lbl_result.Text = "Result:\r\n" + result;
    }
    #endregion

    private void button1_Click(object sender, EventArgs e)
    {
      dt.append((int)numericUpDown1.Value);
      MessageBox.Show(numericUpDown1.Value + " added!\r\nPress [enter] to continue...", 
                        "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

      numericUpDown1.Value = 0;
      numericUpDown1.Select(0, 1);
    }

    private void btn_help_Click(object sender, EventArgs e)
    {
      (new Help()).Show();
    }
  }//:End form1
  #endregion

  #region Delegate Methods class [add,mult]
  /// <summary>
  ///   Methods for delegate testing.
  ///   
  ///   Author: S. Copeland
  /// </summary>
  class DelegateMethods
  {
    public static int Add(int sum, int cur)
    {
      return sum + cur;
    }

    public static int Mult(int sum, int cur)
    {
      return sum * cur;
    }
  }
  #endregion

  #region Delegate Test
  /// <summary>
  ///   The class for our Delegate Operations.
  ///   Contains no methods, just the outline for allowing delegates.
  ///   
  ///   Author: S. Copeland
  /// </summary>
  class DelegateTest
  {
    public delegate int perform_operation(int sum, int cur);
    private List<Int32> numbers;

    public DelegateTest()
    {
      numbers = new List<Int32>();
    }

    public void append(int i)
    {
      numbers.Add(i);
    }

    public int Operation(perform_operation po)
    {
      if(numbers.Count == 0) return 0;

      int sum = (po.Method.Name.Equals("Mult")) ? 1 : 0;
      foreach(int i in numbers)
      {
        sum = po(sum, i);
      }

      return sum;
    }//:end Operation
  }
  #endregion
}
