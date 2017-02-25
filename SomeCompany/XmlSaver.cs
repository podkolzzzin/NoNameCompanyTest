using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Xml;

namespace SomeCompanyTest {

  class XmlSaver {

    private XmlWriter resultStream;
    private Stream stream;
    private IEnumerable<ScanInfo> walkResult;
    private Dictionary<string, long> sizes;

    public XmlSaver(Stream stream, IEnumerable<ScanInfo> walkResult) {

      this.resultStream = XmlWriter.Create(stream);
      this.stream = stream;

      this.walkResult = walkResult;
      this.sizes = new Dictionary<string, long>();
    }

    public void Start() {

      ThreadPool.QueueUserWorkItem(Save);
    }

    private void Save(object state) {

      /*
        Dear, SomeCompany!
        I know that you were probably expecting that data in xml whould be saved in a tree-form.
        I am sorry, a had only something like 3 hours of free time to do this task, so I was a bit in a hurry.
        But in fact, there wasn't noticed in task that the structure of file have to be hierarchical.
        Also you were probably expecting me to use polymorphism to build XML and visual tree...
        I am sorry that I haven't done like that, but hope you'd like the solution with active-enumerable)

        Yours,
          Andrey Podkolzin.


        P.S. I have implemented size of directory.
      */

      resultStream.WriteStartElement("Info");
      try {
        LinkedList<ScanInfo> directories = new LinkedList<ScanInfo>();
        foreach (var item in walkResult) {
          if (item.Files != null) {
            WriteFiles(item.Files);
            AddSize(item.Directory.FullName, item.Files.Sum(f => f.Length));
          }
          directories.AddLast(item);
        }

        foreach (var item in directories)
          if (item.Directories != null)
            WriteDirectories(item.Directories);
      }
      finally {
        resultStream.WriteEndElement();
      }
      resultStream.Dispose();
      stream.Dispose();
    }

    private void AddSize(string fullName, long length) {

      while (fullName != null) {
        long size;
        sizes.TryGetValue(fullName, out size);
        size += length;
        sizes[fullName] = size;
        fullName = Path.GetDirectoryName(fullName);
      }
    }

    private void WriteDirectories(DirectoryInfo[] directories) {

      foreach (var dir in directories) {
        resultStream.WriteStartElement("Directory");
        try {
          WriteGeneralInfo(dir);
          WriteSecurityInfo(dir.GetAccessControl());
          long size;
          if (sizes.TryGetValue(dir.FullName, out size))
            resultStream.WriteElementString("Size", size.ToString());
        }
        catch (Exception ex) {
          Output(dir.FullName, ex);
        }
        finally {
          resultStream.WriteEndElement();
        }
      }
    }

    private void WriteFiles(FileInfo[] files) {

      foreach (var file in files) {
        resultStream.WriteStartElement("File");
        try {
          WriteGeneralInfo(file);
          WriteSecurityInfo(file.GetAccessControl());
          resultStream.WriteElementString("Size", file.Length.ToString());
        }
        catch (Exception ex) {
          Output(file.FullName, ex);
        }
        finally {
          resultStream.WriteEndElement();
        }
      }
    }

    private void Output(string fullName, Exception ex) {

      ErrorHandler.Output($"Error during saving {fullName} info to XML file! \r\n\tMessage: {ex.Message}");
    }

    private void WriteSecurityInfo(FileSystemSecurity fileSecurity) {
      
      resultStream.WriteElementString("Owner", fileSecurity.GetOwner(typeof(SecurityIdentifier)).Value);
      resultStream.WriteStartElement("AccessRules");
      try {
        foreach (AuthorizationRule item in fileSecurity.GetAccessRules(true, true, typeof(SecurityIdentifier)))
          WriteAuthorizationRule(item);
      }
      finally {
        resultStream.WriteEndElement();
      }
    }

    private void WriteAuthorizationRule(AuthorizationRule item) {

      resultStream.WriteStartElement("AccessRule");
      try {
        resultStream.WriteElementString("Identity", item.IdentityReference.ToString());
        FileSystemAccessRule accessRule = item as FileSystemAccessRule;
        if (accessRule != null)
          resultStream.WriteElementString("Access", accessRule.FileSystemRights.ToString());
      }
      finally {
        resultStream.WriteEndElement();
      }
    }

    private void WriteGeneralInfo(FileSystemInfo file) {

      resultStream.WriteElementString("Name", file.FullName);
      resultStream.WriteElementString("CreatedAt", file.CreationTime.ToString());
      resultStream.WriteElementString("ModifiedAt", file.LastWriteTime.ToString());
      resultStream.WriteElementString("AccessedAt", file.LastAccessTime.ToString());
      resultStream.WriteElementString("Attributes", file.Attributes.ToString());
    }
  }
}