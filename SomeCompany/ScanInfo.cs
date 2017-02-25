using System.IO;

namespace SomeCompanyTest {

  public class ScanInfo {

    public ScanInfo(DirectoryInfo directory, DirectoryInfo[] directories, FileInfo[] files) {

      Directory = directory;
      Directories = directories;
      Files = files;
    }

    public DirectoryInfo Directory {
      get;
      private set;
    }

    public DirectoryInfo[] Directories {
      get;
      private set;
    }

    public FileInfo[] Files {
      get;
      private set;
    }
  }
}
