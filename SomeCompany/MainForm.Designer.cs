namespace SomeCompanyTest {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.tbScanPath = new System.Windows.Forms.TextBox();
      this.lbPath = new System.Windows.Forms.Label();
      this.tvResults = new System.Windows.Forms.TreeView();
      this.btProcess = new System.Windows.Forms.Button();
      this.tlResultPath = new System.Windows.Forms.Label();
      this.tbResultPath = new System.Windows.Forms.TextBox();
      this.tbOutput = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // tbScanPath
      // 
      this.tbScanPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbScanPath.Location = new System.Drawing.Point(133, 25);
      this.tbScanPath.Margin = new System.Windows.Forms.Padding(6);
      this.tbScanPath.Name = "tbScanPath";
      this.tbScanPath.Size = new System.Drawing.Size(921, 29);
      this.tbScanPath.TabIndex = 0;
      // 
      // lbPath
      // 
      this.lbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbPath.AutoSize = true;
      this.lbPath.Location = new System.Drawing.Point(22, 28);
      this.lbPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.lbPath.Name = "lbPath";
      this.lbPath.Size = new System.Drawing.Size(99, 24);
      this.lbPath.TabIndex = 1;
      this.lbPath.Text = "Scan path:";
      // 
      // tvResults
      // 
      this.tvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tvResults.Location = new System.Drawing.Point(26, 104);
      this.tvResults.Name = "tvResults";
      this.tvResults.Size = new System.Drawing.Size(1170, 601);
      this.tvResults.TabIndex = 2;
      // 
      // btProcess
      // 
      this.btProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btProcess.Location = new System.Drawing.Point(1063, 25);
      this.btProcess.Name = "btProcess";
      this.btProcess.Size = new System.Drawing.Size(133, 66);
      this.btProcess.TabIndex = 3;
      this.btProcess.Text = "&Process";
      this.btProcess.UseVisualStyleBackColor = true;
      this.btProcess.Click += new System.EventHandler(this.btProcess_Click);
      // 
      // tlResultPath
      // 
      this.tlResultPath.AutoSize = true;
      this.tlResultPath.Location = new System.Drawing.Point(12, 65);
      this.tlResultPath.Name = "tlResultPath";
      this.tlResultPath.Size = new System.Drawing.Size(108, 24);
      this.tlResultPath.TabIndex = 4;
      this.tlResultPath.Text = "Result path:";
      // 
      // tbResultPath
      // 
      this.tbResultPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbResultPath.Location = new System.Drawing.Point(133, 62);
      this.tbResultPath.Margin = new System.Windows.Forms.Padding(6);
      this.tbResultPath.Name = "tbResultPath";
      this.tbResultPath.Size = new System.Drawing.Size(921, 29);
      this.tbResultPath.TabIndex = 5;
      // 
      // tbOutput
      // 
      this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbOutput.Location = new System.Drawing.Point(26, 711);
      this.tbOutput.Multiline = true;
      this.tbOutput.Name = "tbOutput";
      this.tbOutput.ReadOnly = true;
      this.tbOutput.Size = new System.Drawing.Size(1170, 139);
      this.tbOutput.TabIndex = 6;
      this.tbOutput.Text = "Output:\r\n";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1211, 862);
      this.Controls.Add(this.tbOutput);
      this.Controls.Add(this.tbResultPath);
      this.Controls.Add(this.tlResultPath);
      this.Controls.Add(this.btProcess);
      this.Controls.Add(this.tvResults);
      this.Controls.Add(this.lbPath);
      this.Controls.Add(this.tbScanPath);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(6);
      this.Name = "MainForm";
      this.Text = "SomeCompany Test";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbScanPath;
    private System.Windows.Forms.Label lbPath;
    private System.Windows.Forms.TreeView tvResults;
    private System.Windows.Forms.Button btProcess;
    private System.Windows.Forms.Label tlResultPath;
    private System.Windows.Forms.TextBox tbResultPath;
    private System.Windows.Forms.TextBox tbOutput;
  }
}

