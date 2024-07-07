namespace StringSyntaxWithEntityFrameworkCore;

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
        button1 = new Button();
        ChoiceButton = new Button();
        FromSettingsButton = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(25, 25);
        button1.Name = "button1";
        button1.Size = new Size(218, 29);
        button1.TabIndex = 0;
        button1.Text = "Conventional";
        button1.UseVisualStyleBackColor = true;
        button1.Click += ConventionalButton_Click;
        // 
        // ChoiceButton
        // 
        ChoiceButton.Location = new Point(25, 60);
        ChoiceButton.Name = "ChoiceButton";
        ChoiceButton.Size = new Size(218, 29);
        ChoiceButton.TabIndex = 1;
        ChoiceButton.Text = "Users Choice";
        ChoiceButton.UseVisualStyleBackColor = true;
        ChoiceButton.Click += ChoiceButton_Click;
        // 
        // FromSettingsButton
        // 
        FromSettingsButton.Location = new Point(25, 95);
        FromSettingsButton.Name = "FromSettingsButton";
        FromSettingsButton.Size = new Size(218, 29);
        FromSettingsButton.TabIndex = 2;
        FromSettingsButton.Text = "From settings";
        FromSettingsButton.UseVisualStyleBackColor = true;
        FromSettingsButton.Click += FromSettingsButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(288, 166);
        Controls.Add(FromSettingsButton);
        Controls.Add(ChoiceButton);
        Controls.Add(button1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Formatting";
        ResumeLayout(false);
    }

    #endregion

    private Button button1;
    private Button ChoiceButton;
    private Button FromSettingsButton;
}
