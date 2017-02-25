using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeCompanyTest {

  class FileSystemWalkResult : IEnumerable<ScanInfo> {

    private class FileSystemWalkResultEnumerator : IEnumerator<ScanInfo> {

      private FileSystemWalkResult data;
      private LinkedListNode<ScanInfo> current;

      public FileSystemWalkResultEnumerator(FileSystemWalkResult data) {

        this.data = data;
      }

      public ScanInfo Current {
        get {
          return current?.Value;
        }
      }

      object IEnumerator.Current {
        get {
          return Current;
        }
      }

      public void Dispose() {
      }

      public bool MoveNext() {

        bool wait = false;
        lock (data.syncObject) {
          if (data.finished && current == data.info.Last)
            return false;

          if ((current == null && data.info.First == null) || (current != null && current.Next == null))
            wait = true;
          else
            current = current == null ? data.info.First : current.Next;
        }
        if (wait) {
          data.evt.WaitOne();
          return MoveNext();
        }

        return true;
      }

      public void Reset() {

        throw new NotImplementedException();
      }
    }

    private object syncObject = new object();

    private FileSystemWalker walker;
    private AutoResetEvent evt;
    private LinkedList<ScanInfo> info;

    private bool finished;

    public FileSystemWalkResult(FileSystemWalker walker) {

      this.walker = walker;
      this.info = new LinkedList<ScanInfo>();
      this.evt = new AutoResetEvent(false);
    }

    public void Finish() {

      finished = true;
      evt.Set();
    }

    public void Add(ScanInfo dataItem) {

      lock (syncObject)
        info.AddLast(dataItem);
      evt.Set();
    }

    public IEnumerator<ScanInfo> GetEnumerator() {

      return new FileSystemWalkResultEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() {

      return GetEnumerator();
    }
  }
}
