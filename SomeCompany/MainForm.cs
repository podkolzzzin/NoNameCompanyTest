using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeCompanyTest {

  public partial class MainForm : Form, IErrorHandlerTarget {

    public MainForm() {

      InitializeComponent();
      tvResults.ImageList = ImageConstants.GetList();
    }

    private bool InputAllowed {
      get {
        return btProcess.Enabled;
      }
      set {
        tbResultPath.Enabled = tbScanPath.Enabled = btProcess.Enabled = value;
      }
    }

    public void Output(string message) {

      BeginInvoke(new Action(() => tbOutput.AppendText(message + Environment.NewLine)));
    }

    private void btProcess_Click(object sender, EventArgs e) {

      if (!CheckScanPath())
        return;

      Stream resultStream;
      try {
        resultStream = File.OpenWrite(tbResultPath.Text);
      }
      catch (Exception ex) {
        ErrorHandler.Notify(ex);
        return;
      }

      tvResults.Nodes.Clear();

      InputAllowed = false;
      var walker = new FileSystemWalker(tbScanPath.Text);
      var builder = new TreeBuilder(tvResults, walker.Result);
      var saver = new XmlSaver(resultStream, walker.Result);
      builder.Finished += Builder_Finished;
      builder.Start();
      walker.Start();
      saver.Start();
    }

    private bool CheckScanPath() {

      try {
        Directory.GetAccessControl(tbScanPath.Text);
        return true;
      }
      catch (Exception ex) {
        ErrorHandler.Notify(ex);
        return false;
      }
    }

    private void Builder_Finished(object sender, EventArgs e) {

      InputAllowed = true;
    }
  }
}
