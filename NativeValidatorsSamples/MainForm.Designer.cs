namespace NativeValidatorsSamples;

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
        IntegerValidatorButton = new Button();
        TimeSpanValidateButton = new Button();
        SuspendLayout();
        // 
        // IntegerValidatorButton
        // 
        IntegerValidatorButton.Location = new Point(185, 134);
        IntegerValidatorButton.Name = "IntegerValidatorButton";
        IntegerValidatorButton.Size = new Size(154, 29);
        IntegerValidatorButton.TabIndex = 0;
        IntegerValidatorButton.Text = "Integer validator";
        IntegerValidatorButton.UseVisualStyleBackColor = true;
        IntegerValidatorButton.Click += IntegerValidatorButton_Click;
        // 
        // TimeSpanValidateButton
        // 
        TimeSpanValidateButton.Location = new Point(185, 179);
        TimeSpanValidateButton.Name = "TimeSpanValidateButton";
        TimeSpanValidateButton.Size = new Size(154, 29);
        TimeSpanValidateButton.TabIndex = 1;
        TimeSpanValidateButton.Text = "TimeSpan validator";
        TimeSpanValidateButton.UseVisualStyleBackColor = true;
        TimeSpanValidateButton.Click += TimeSpanValidatorButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(525, 342);
        Controls.Add(TimeSpanValidateButton);
        Controls.Add(IntegerValidatorButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = ".NET Validators";
        ResumeLayout(false);
    }

    #endregion

    private Button IntegerValidatorButton;
    private Button TimeSpanValidateButton;
}
