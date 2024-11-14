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
        FuncMethodGroupButton = new Button();
        ParamCollectionButton = new Button();
        SearchValuesButton = new Button();
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
        PersonPartialButton.Location = new Point(38, 72);
        PersonPartialButton.Name = "PersonPartialButton";
        PersonPartialButton.Size = new Size(157, 29);
        PersonPartialButton.TabIndex = 1;
        PersonPartialButton.Text = "Person partial";
        PersonPartialButton.UseVisualStyleBackColor = true;
        PersonPartialButton.Click += PersonPartialButton_Click;
        // 
        // FieldKeywordButton
        // 
        FieldKeywordButton.Location = new Point(38, 121);
        FieldKeywordButton.Name = "FieldKeywordButton";
        FieldKeywordButton.Size = new Size(157, 29);
        FieldKeywordButton.TabIndex = 2;
        FieldKeywordButton.Text = "Field Keyword";
        FieldKeywordButton.UseVisualStyleBackColor = true;
        FieldKeywordButton.Click += FieldKeywordButton_Click;
        // 
        // FuncMethodGroupButton
        // 
        FuncMethodGroupButton.Location = new Point(38, 170);
        FuncMethodGroupButton.Name = "FuncMethodGroupButton";
        FuncMethodGroupButton.Size = new Size(157, 29);
        FuncMethodGroupButton.TabIndex = 3;
        FuncMethodGroupButton.Text = "Func Method Group";
        FuncMethodGroupButton.UseVisualStyleBackColor = true;
        FuncMethodGroupButton.Click += FuncMethodGroupButton_Click;
        // 
        // ParamCollectionButton
        // 
        ParamCollectionButton.Location = new Point(38, 215);
        ParamCollectionButton.Name = "ParamCollectionButton";
        ParamCollectionButton.Size = new Size(157, 29);
        ParamCollectionButton.TabIndex = 4;
        ParamCollectionButton.Text = "Param Collection";
        ParamCollectionButton.UseVisualStyleBackColor = true;
        ParamCollectionButton.Click += ParamCollectionButton_Click;
        // 
        // SearchValuesButton
        // 
        SearchValuesButton.Location = new Point(230, 23);
        SearchValuesButton.Name = "SearchValuesButton";
        SearchValuesButton.Size = new Size(157, 29);
        SearchValuesButton.TabIndex = 5;
        SearchValuesButton.Text = "SearchValues";
        SearchValuesButton.UseVisualStyleBackColor = true;
        SearchValuesButton.Click += SearchValuesButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(412, 308);
        Controls.Add(SearchValuesButton);
        Controls.Add(ParamCollectionButton);
        Controls.Add(FuncMethodGroupButton);
        Controls.Add(FieldKeywordButton);
        Controls.Add(PersonPartialButton);
        Controls.Add(ShowFormButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "C# 13 - in dark mode";
        ResumeLayout(false);
    }

    #endregion

    private Button ShowFormButton;
    private Button PersonPartialButton;
    private Button FieldKeywordButton;
    private Button FuncMethodGroupButton;
    private Button ParamCollectionButton;
    private Button SearchValuesButton;
}
