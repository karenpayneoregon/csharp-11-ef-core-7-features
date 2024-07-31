namespace WinFormsApp1;

partial class StackoverflowForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        comboBox1 = new ComboBox();
        SelectedItemButton = new Button();
        YearsOldButton = new Button();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(45, 37);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(151, 28);
        comboBox1.TabIndex = 0;
        // 
        // SelectedItemButton
        // 
        SelectedItemButton.Location = new Point(223, 37);
        SelectedItemButton.Name = "SelectedItemButton";
        SelectedItemButton.Size = new Size(94, 29);
        SelectedItemButton.TabIndex = 1;
        SelectedItemButton.Text = "button1";
        SelectedItemButton.UseVisualStyleBackColor = true;
        SelectedItemButton.Click += SelectedItemButton_Click;
        // 
        // YearsOldButton
        // 
        YearsOldButton.Location = new Point(45, 106);
        YearsOldButton.Name = "YearsOldButton";
        YearsOldButton.Size = new Size(272, 29);
        YearsOldButton.TabIndex = 2;
        YearsOldButton.Text = "Years old";
        YearsOldButton.UseVisualStyleBackColor = true;
        YearsOldButton.Click += YearsOldButton_Click;
        // 
        // StackoverflowForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(YearsOldButton);
        Controls.Add(SelectedItemButton);
        Controls.Add(comboBox1);
        Name = "StackoverflowForm";
        Text = "StackoverflowForm";
        ResumeLayout(false);
    }

    #endregion

    private ComboBox comboBox1;
    private Button SelectedItemButton;
    private Button YearsOldButton;
}