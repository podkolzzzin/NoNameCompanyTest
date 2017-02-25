using System.Windows.Forms;

namespace SomeCompanyTest {

  interface IErrorHandlerTarget : IWin32Window {

    void Output(string message);
  }
}
