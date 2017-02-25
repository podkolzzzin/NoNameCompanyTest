using System;
using System.Windows.Forms;

namespace SomeCompanyTest {

  static class ErrorHandler {

    private static bool initialized;
    private static IErrorHandlerTarget form;

    public static void Initialize(IErrorHandlerTarget mainForm) {

      if (!initialized) {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        form = mainForm;
      }
      initialized = true;
    }

    public static void Notify(Exception ex) {

      MessageBox.Show(form, ex.Message, "Runtime error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void Output(string message) {

      form.Output(message);
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {

      var ex = e.ExceptionObject as Exception;
      if (ex != null)
        Notify(ex);
    }
  }
}
