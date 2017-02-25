using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SomeCompanyTest {

  class FileSystemWalker {

    private string path;
    private FileSystemWalkResult result;

    public FileSystemWalker(string path) {

      this.path = path;
      this.result = new FileSystemWalkResult(this);
    }

    public IEnumerable<ScanInfo> Result {
      get {
        return result;
      }
    }

    public void Start() {

      ThreadPool.QueueUserWorkItem(Walk);
    }

    private void Walk(object state) {

      WalkInternal(new DirectoryInfo(path));
      result.Finish();
    }

    private void WalkInternal(DirectoryInfo directoryInfo) {

      DirectoryInfo[] directories;
      FileInfo[] files;
      try {
        directories= directoryInfo.GetDirectories();
        files = directoryInfo.GetFiles();
      }
      catch (UnauthorizedAccessException ex) {
        OutputError(directoryInfo, ex);
        return;
      }
      catch (IOException ex) {
        OutputError(directoryInfo, ex);
        return;
      }
      catch (Exception ex) {
        ErrorHandler.Notify(ex);
        return;
      }

      var info = new ScanInfo(directoryInfo, directories, files);
      result.Add(info);

      if (info.Directories != null)
        foreach (var dir in info.Directories)
          WalkInternal(dir);
    }

    private void OutputError(DirectoryInfo directoryInfo, Exception ex) {

      ErrorHandler.Output($"Error occured while scanning \"{directoryInfo.FullName}\" \r\n\tMessage: {ex.Message}");
    }
  }
}
