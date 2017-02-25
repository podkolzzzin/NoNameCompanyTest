using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SomeCompanyTest {

  class TreeBuilder {

    private IEnumerable<ScanInfo> walkResult;
    private TreeView output;

    public TreeBuilder(TreeView output, IEnumerable<ScanInfo> walkResult) {

      this.walkResult = walkResult;
      this.output = output;
    }

    public void Start() {

      ThreadPool.QueueUserWorkItem(Build);
    }

    private void Build(object state) {

      Dictionary<string, TreeNode> nodes = new Dictionary<string, TreeNode>();

      var updateOutput = new Action<TreeNode, TreeNodeCollection, TreeNode[]>((childNode, listNodes, fileNodes) => {
        if (childNode != null)
          listNodes.Add(childNode);
        else
          listNodes.AddRange(fileNodes);
      });

      foreach (var item in walkResult) {

        TreeNode parent, grandParent;
        IList parentNodes;

        var parentPath = Path.GetDirectoryName(item.Directory.FullName);
        if (parentPath!= null && nodes.TryGetValue(parentPath, out grandParent))
          parentNodes = grandParent.Nodes;
        else
          parentNodes = output.Nodes;

        nodes.TryGetValue(item.Directory.FullName, out parent);

        var fileNodes = item.Files == null ? new TreeNode[0] : new TreeNode[item.Files.Length];

        if (item.Files != null)
          for (int i = 0; i < item.Files.Length; i++)
            fileNodes[i] = new TreeNode(item.Files[i].Name, ImageConstants.FileIcon, ImageConstants.FileIcon);

        if (item.Directories != null)
          foreach (var directory in item.Directories)
            nodes[directory.FullName] = new TreeNode(directory.Name, ImageConstants.DirectoryIcon, ImageConstants.DirectoryIcon);

        parent?.Nodes?.AddRange(fileNodes);
        output.BeginInvoke(updateOutput, parent, parentNodes, fileNodes);
      }
      output.BeginInvoke(new Action(() => Finished?.Invoke(this, EventArgs.Empty)));
    }

    public event EventHandler Finished;
  }
}
