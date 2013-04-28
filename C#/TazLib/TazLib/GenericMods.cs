using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace TazLib
{
  public class GenericMods
  {
    #region Get Date
    /// <summary>
    ///   Get the current Date Time
    /// </summary>
    /// <param name="month">Do you want the month?</param>
    /// <param name="day">The day?</param>
    /// <param name="year">The year?</param>
    /// <param name="hours_minutes">Time in hours + minutes?</param>
    /// <param name="seconds">Seconds as well?</param>
    /// <returns>date</returns>
    public string GetCurrentDateTime(bool month, bool day, bool year, bool hours_minutes, bool seconds)
    {
      DateTime now = DateTime.Now;

      string date = (month)   ? "__MMMM " : "__";
      date += (day)           ? "dd, "    : "";
      date += (year)          ? "yyyy"    : "";
      date += (hours_minutes) ? "__H:mm"  : "";
      date += (seconds)       ? ":ss__"   : "__";

      return now.ToString(date);
    }

    /// <summary>
    ///   Return the current date time in full.
    /// </summary>
    public string GetCurrentDateTime()
    {
      DateTime now = DateTime.Now;
      string date = "__MMMM dd, yyyy__H:mm:ss__";
      return now.ToString(date);
    }
    #endregion

    #region Startup
    /// <summary>
    ///   Make a program run at startup.
    /// </summary>
    /// <param name="appname">Name of your application.</param>
    /// <param name="path">Where the application is located</param>
    /// <param name="all">All users = true, just currentuser = false</param>
    /// <returns>
    ///   True if successful. False if not successful.
    ///   If false, please check error log.
    /// </returns>
    public bool RunAtStart(string appname, string path, bool all)
    {
      try
      {
        RegistryKey temp = (all) ? Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true)
                                           :
                                   Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        temp.SetValue(appname, "\"" + path + "\"");
        temp.Close();
      }
      catch (Exception e)
      {
				if (!Directory.Exists("logs\\")) Directory.CreateDirectory("logs\\");
        if (!File.Exists("logs\\ERR_LG.TKQ")) File.Create("logs\\ERR_LG.TKQ");
        StreamReader SR = new StreamReader("logs\\ERR_LG.TKQ");
        string temp = SR.ReadToEnd();
        SR.Close();

        StreamWriter SW = new StreamWriter("logs\\ERR_LG.TKQ");
        SW.WriteLine(temp + "\n----------------------------------\n");
        SW.WriteLine(GetCurrentDateTime() + "\n" +
                     e.Message + "\n" +
                     e.Source + "\n" +
                     e.InnerException + "\n" +
                     e.Data + "\n" + 
                     e.StackTrace);
        SW.Close();
        return false;
      }
      return true;
    }
    #endregion

    #region Saving
    /// <summary>
    ///   For those times when you think a loop will be better.
    ///   Pre-existing files:
    ///   Logs
    ///   Logs1
    ///   Logs2
    ///   Logs3
    ///   Logs4 <-- Most recent file.
    /// </summary>
    /// <param name="path">Where they are located. (EX: @"C:\program\logs\"</param>
    /// <returns>
    ///   A Number that you can assign to your saved file, and
    ///   not overwrite anything.
    /// </returns>
    public int SaveNumber(string path)
    {
      return Directory.GetFiles(path).Length;
    }
    #endregion
  }
}
