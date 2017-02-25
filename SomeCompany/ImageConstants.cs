using System.Drawing;
using System.Windows.Forms;

namespace SomeCompanyTest {

  static class ImageConstants {

    public const int DirectoryIcon = 0;
    public const int FileIcon = 1;

    public static ImageList GetList() {

      var imgList = new ImageList();
      imgList.Images.Add(SystemIcons.WinLogo);
      imgList.Images.Add(SystemIcons.Information);
      return imgList;
    }
  }
}
