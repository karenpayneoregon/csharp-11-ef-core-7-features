namespace RemoveExtraSpacesApp;

partial class Form1
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        ExecuteButton = new Button();
        SuspendLayout();
        // 
        // ExecuteButton
        // 
        ExecuteButton.Image = (Image)resources.GetObject("ExecuteButton.Image");
        ExecuteButton.ImageAlign = ContentAlignment.MiddleLeft;
        ExecuteButton.Location = new Point(81, 56);
        ExecuteButton.Name = "ExecuteButton";
        ExecuteButton.Padding = new Padding(4);
        ExecuteButton.Size = new Size(191, 42);
        ExecuteButton.TabIndex = 0;
        ExecuteButton.Text = "Just do it";
        ExecuteButton.UseVisualStyleBackColor = true;
        ExecuteButton.Click += ExecuteButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(352, 155);
        Controls.Add(ExecuteButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Remove extra spaces";
        ResumeLayout(false);
    }

    #endregion

    private Button ExecuteButton;
}
