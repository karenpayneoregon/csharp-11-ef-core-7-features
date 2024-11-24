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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        ShowFormButton = new Button();
        PersonPartialButton = new Button();
        FieldKeywordButton = new Button();
        FuncMethodGroupButton = new Button();
        ParamCollectionButton = new Button();
        SearchValuesButton = new Button();
        SearchValuesButton1 = new Button();
        ComplexTypeButton = new Button();
        groupBox1 = new GroupBox();
        CountByButton = new Button();
        AggregateByButton = new Button();
        AppSettingsButton = new Button();
        SearchValuesActivityLogButton = new Button();
        OverloadResolutionPriorityButton = new Button();
        GetJsonSchemaAsNodeButton = new Button();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // ShowFormButton
        // 
        ShowFormButton.Location = new Point(38, 23);
        ShowFormButton.Name = "ShowFormButton";
        ShowFormButton.Size = new Size(226, 29);
        ShowFormButton.TabIndex = 0;
        ShowFormButton.Text = "Show child form";
        ShowFormButton.UseVisualStyleBackColor = true;
        ShowFormButton.Click += ShowFormButton_Click;
        // 
        // PersonPartialButton
        // 
        PersonPartialButton.Location = new Point(38, 74);
        PersonPartialButton.Name = "PersonPartialButton";
        PersonPartialButton.Size = new Size(226, 29);
        PersonPartialButton.TabIndex = 1;
        PersonPartialButton.Text = "Person partial";
        PersonPartialButton.UseVisualStyleBackColor = true;
        PersonPartialButton.Click += PersonPartialButton_Click;
        // 
        // FieldKeywordButton
        // 
        FieldKeywordButton.Location = new Point(38, 125);
        FieldKeywordButton.Name = "FieldKeywordButton";
        FieldKeywordButton.Size = new Size(226, 29);
        FieldKeywordButton.TabIndex = 2;
        FieldKeywordButton.Text = "Field Keyword";
        FieldKeywordButton.UseVisualStyleBackColor = true;
        FieldKeywordButton.Click += FieldKeywordButton_Click;
        // 
        // FuncMethodGroupButton
        // 
        FuncMethodGroupButton.Location = new Point(38, 176);
        FuncMethodGroupButton.Name = "FuncMethodGroupButton";
        FuncMethodGroupButton.Size = new Size(226, 29);
        FuncMethodGroupButton.TabIndex = 3;
        FuncMethodGroupButton.Text = "Func Method Group";
        FuncMethodGroupButton.UseVisualStyleBackColor = true;
        FuncMethodGroupButton.Click += FuncMethodGroupButton_Click;
        // 
        // ParamCollectionButton
        // 
        ParamCollectionButton.Location = new Point(38, 227);
        ParamCollectionButton.Name = "ParamCollectionButton";
        ParamCollectionButton.Size = new Size(226, 29);
        ParamCollectionButton.TabIndex = 4;
        ParamCollectionButton.Text = "Param Collection";
        ParamCollectionButton.UseVisualStyleBackColor = true;
        ParamCollectionButton.Click += ParamCollectionButton_Click;
        // 
        // SearchValuesButton
        // 
        SearchValuesButton.Location = new Point(294, 23);
        SearchValuesButton.Name = "SearchValuesButton";
        SearchValuesButton.Size = new Size(226, 29);
        SearchValuesButton.TabIndex = 5;
        SearchValuesButton.Text = "SearchValues (spam)";
        SearchValuesButton.UseVisualStyleBackColor = true;
        SearchValuesButton.Click += SearchValuesButton_Click;
        // 
        // SearchValuesButton1
        // 
        SearchValuesButton1.Location = new Point(294, 72);
        SearchValuesButton1.Name = "SearchValuesButton1";
        SearchValuesButton1.Size = new Size(226, 29);
        SearchValuesButton1.TabIndex = 6;
        SearchValuesButton1.Text = "SearchValues (Log) 1";
        SearchValuesButton1.UseVisualStyleBackColor = true;
        SearchValuesButton1.Click += SearchValuesButton1_Click;
        // 
        // ComplexTypeButton
        // 
        ComplexTypeButton.Location = new Point(21, 29);
        ComplexTypeButton.Name = "ComplexTypeButton";
        ComplexTypeButton.Size = new Size(338, 29);
        ComplexTypeButton.TabIndex = 7;
        ComplexTypeButton.Text = "Complex Type";
        ComplexTypeButton.UseVisualStyleBackColor = true;
        ComplexTypeButton.Click += ComplexTypeButton_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(ComplexTypeButton);
        groupBox1.Location = new Point(23, 376);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(376, 117);
        groupBox1.TabIndex = 8;
        groupBox1.TabStop = false;
        groupBox1.Text = "EF Core 9";
        // 
        // CountByButton
        // 
        CountByButton.Location = new Point(294, 176);
        CountByButton.Name = "CountByButton";
        CountByButton.Size = new Size(226, 29);
        CountByButton.TabIndex = 9;
        CountByButton.Text = "CountBy";
        CountByButton.UseVisualStyleBackColor = true;
        CountByButton.Click += CountByButton_Click;
        // 
        // AggregateByButton
        // 
        AggregateByButton.Location = new Point(294, 227);
        AggregateByButton.Name = "AggregateByButton";
        AggregateByButton.Size = new Size(226, 29);
        AggregateByButton.TabIndex = 10;
        AggregateByButton.Text = "AggregateBy";
        AggregateByButton.UseVisualStyleBackColor = true;
        AggregateByButton.Click += AggregateByButton_Click;
        // 
        // AppSettingsButton
        // 
        AppSettingsButton.Location = new Point(38, 278);
        AppSettingsButton.Name = "AppSettingsButton";
        AppSettingsButton.Size = new Size(226, 29);
        AppSettingsButton.TabIndex = 11;
        AppSettingsButton.Text = "App settings";
        AppSettingsButton.UseVisualStyleBackColor = true;
        AppSettingsButton.Click += AppSettingsButton_Click;
        // 
        // SearchValuesActivityLogButton
        // 
        SearchValuesActivityLogButton.Location = new Point(294, 125);
        SearchValuesActivityLogButton.Name = "SearchValuesActivityLogButton";
        SearchValuesActivityLogButton.Size = new Size(226, 29);
        SearchValuesActivityLogButton.TabIndex = 13;
        SearchValuesActivityLogButton.Text = "SearchValues (Log) 2";
        SearchValuesActivityLogButton.UseVisualStyleBackColor = true;
        SearchValuesActivityLogButton.Click += SearchValuesActivityLogButton_Click;
        // 
        // OverloadResolutionPriorityButton
        // 
        OverloadResolutionPriorityButton.Location = new Point(294, 278);
        OverloadResolutionPriorityButton.Name = "OverloadResolutionPriorityButton";
        OverloadResolutionPriorityButton.Size = new Size(226, 29);
        OverloadResolutionPriorityButton.TabIndex = 14;
        OverloadResolutionPriorityButton.Text = "OverloadResolutionPriority";
        OverloadResolutionPriorityButton.UseVisualStyleBackColor = true;
        OverloadResolutionPriorityButton.Click += OverloadResolutionPriorityButton_Click;
        // 
        // GetJsonSchemaAsNodeButton
        // 
        GetJsonSchemaAsNodeButton.Location = new Point(38, 325);
        GetJsonSchemaAsNodeButton.Name = "GetJsonSchemaAsNodeButton";
        GetJsonSchemaAsNodeButton.Size = new Size(226, 29);
        GetJsonSchemaAsNodeButton.TabIndex = 15;
        GetJsonSchemaAsNodeButton.Text = "GetJsonSchemaAsNode";
        GetJsonSchemaAsNodeButton.TextAlign = ContentAlignment.BottomCenter;
        GetJsonSchemaAsNodeButton.UseVisualStyleBackColor = true;
        GetJsonSchemaAsNodeButton.Click += GetJsonSchemaAsNodeButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(548, 524);
        Controls.Add(GetJsonSchemaAsNodeButton);
        Controls.Add(OverloadResolutionPriorityButton);
        Controls.Add(SearchValuesActivityLogButton);
        Controls.Add(AppSettingsButton);
        Controls.Add(AggregateByButton);
        Controls.Add(CountByButton);
        Controls.Add(groupBox1);
        Controls.Add(SearchValuesButton1);
        Controls.Add(SearchValuesButton);
        Controls.Add(ParamCollectionButton);
        Controls.Add(FuncMethodGroupButton);
        Controls.Add(FieldKeywordButton);
        Controls.Add(PersonPartialButton);
        Controls.Add(ShowFormButton);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "C# 13 - in dark mode";
        groupBox1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Button ShowFormButton;
    private Button PersonPartialButton;
    private Button FieldKeywordButton;
    private Button FuncMethodGroupButton;
    private Button ParamCollectionButton;
    private Button SearchValuesButton;
    private Button SearchValuesButton1;
    private Button ComplexTypeButton;
    private GroupBox groupBox1;
    private Button CountByButton;
    private Button AggregateByButton;
    private Button AppSettingsButton;
    private Button button1;
    private Button SearchValuesActivityLogButton;
    private Button OverloadResolutionPriorityButton;
    private Button GetJsonSchemaAsNodeButton;
}
