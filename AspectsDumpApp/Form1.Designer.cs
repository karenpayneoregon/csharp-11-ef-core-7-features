namespace AspectsDumpApp;

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
        MaskedSsnButton = new Button();
        DumpDictionaryButton = new Button();
        DumpExpressionButton = new Button();
        SuspendLayout();
        // 
        // MaskedSsnButton
        // 
        MaskedSsnButton.Location = new Point(30, 28);
        MaskedSsnButton.Name = "MaskedSsnButton";
        MaskedSsnButton.Size = new Size(202, 29);
        MaskedSsnButton.TabIndex = 0;
        MaskedSsnButton.Text = "Dump masked SSN";
        MaskedSsnButton.UseVisualStyleBackColor = true;
        MaskedSsnButton.Click += MaskedSsnButton_Click;
        // 
        // DumpDictionaryButton
        // 
        DumpDictionaryButton.Location = new Point(30, 75);
        DumpDictionaryButton.Name = "DumpDictionaryButton";
        DumpDictionaryButton.Size = new Size(202, 29);
        DumpDictionaryButton.TabIndex = 1;
        DumpDictionaryButton.Text = "Dump Dictionary";
        DumpDictionaryButton.UseVisualStyleBackColor = true;
        DumpDictionaryButton.Click += DumpDictionaryButton_Click;
        // 
        // DumpExpressionButton
        // 
        DumpExpressionButton.Location = new Point(30, 124);
        DumpExpressionButton.Name = "DumpExpressionButton";
        DumpExpressionButton.Size = new Size(202, 29);
        DumpExpressionButton.TabIndex = 2;
        DumpExpressionButton.Text = "Dump Expression";
        DumpExpressionButton.UseVisualStyleBackColor = true;
        DumpExpressionButton.Click += DumpExpressionButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(264, 165);
        Controls.Add(DumpExpressionButton);
        Controls.Add(DumpDictionaryButton);
        Controls.Add(MaskedSsnButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button MaskedSsnButton;
    private Button DumpDictionaryButton;
    private Button DumpExpressionButton;
}
