using System.Diagnostics.CodeAnalysis;

namespace KP_WindowsFormsNET9;

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
        ShowFormButton = new Button();
        PersonPartialButton = new Button();
        FieldKeywordButton = new Button();
        SuspendLayout();
        // 
        // ShowFormButton
        // 
        ShowFormButton.Location = new Point(38, 23);
        ShowFormButton.Name = "ShowFormButton";
        ShowFormButton.Size = new Size(157, 29);
        ShowFormButton.TabIndex = 0;
        ShowFormButton.Text = "Show child form";
        ShowFormButton.UseVisualStyleBackColor = true;
        ShowFormButton.Click += ShowFormButton_Click;
        // 
        // PersonPartialButton
        // 
        PersonPartialButton.Location = new Point(38, 80);
        PersonPartialButton.Name = "PersonPartialButton";
        PersonPartialButton.Size = new Size(157, 29);
        PersonPartialButton.TabIndex = 1;
        PersonPartialButton.Text = "Person partial";
        PersonPartialButton.UseVisualStyleBackColor = true;
        PersonPartialButton.Click += PersonPartialButton_Click;
        // 
        // FieldKeywordButton
        // 
        FieldKeywordButton.Location = new Point(38, 127);
        FieldKeywordButton.Name = "FieldKeywordButton";
        FieldKeywordButton.Size = new Size(157, 29);
        FieldKeywordButton.TabIndex = 2;
        FieldKeywordButton.Text = "Field Keyword";
        FieldKeywordButton.UseVisualStyleBackColor = true;
        FieldKeywordButton.Click += FieldKeywordButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(FieldKeywordButton);
        Controls.Add(PersonPartialButton);
        Controls.Add(ShowFormButton);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button ShowFormButton;
    private Button PersonPartialButton;
    private Button FieldKeywordButton;
}
