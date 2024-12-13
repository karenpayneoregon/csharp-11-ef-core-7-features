namespace GlobbingMyDocs;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        listBox1 = new ListBox();
        ExecuteButton = new Button();
        SuspendLayout();
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(122, 21);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(655, 424);
        listBox1.TabIndex = 0;
        // 
        // ExecuteButton
        // 
        ExecuteButton.Location = new Point(12, 21);
        ExecuteButton.Name = "ExecuteButton";
        ExecuteButton.Size = new Size(94, 29);
        ExecuteButton.TabIndex = 1;
        ExecuteButton.Text = "Execute";
        ExecuteButton.UseVisualStyleBackColor = true;
        ExecuteButton.Click += ExecuteButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(ExecuteButton);
        Controls.Add(listBox1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBox1;
    private Button ExecuteButton;
}
