namespace WinFormsApp1;

partial class ChildForm
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
        numericUpDown1 = new NumericUpDown();
        AddCheckBox = new CheckBox();
        ExecuteButton = new Button();
        CurrentValueLabel = new Label();
        CancelButton = new Button();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new Point(25, 49);
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new Size(150, 27);
        numericUpDown1.TabIndex = 0;
        numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // AddCheckBox
        // 
        AddCheckBox.AutoSize = true;
        AddCheckBox.Location = new Point(181, 50);
        AddCheckBox.Name = "AddCheckBox";
        AddCheckBox.Size = new Size(101, 24);
        AddCheckBox.TabIndex = 1;
        AddCheckBox.Text = "checkBox1";
        AddCheckBox.UseVisualStyleBackColor = true;
        // 
        // ExecuteButton
        // 
        ExecuteButton.Location = new Point(288, 45);
        ExecuteButton.Name = "ExecuteButton";
        ExecuteButton.Size = new Size(94, 29);
        ExecuteButton.TabIndex = 2;
        ExecuteButton.Text = "Execute";
        ExecuteButton.UseVisualStyleBackColor = true;
        ExecuteButton.Click += ExecuteButton_Click;
        // 
        // CurrentValueLabel
        // 
        CurrentValueLabel.AutoSize = true;
        CurrentValueLabel.Location = new Point(25, 9);
        CurrentValueLabel.Name = "CurrentValueLabel";
        CurrentValueLabel.Size = new Size(50, 20);
        CurrentValueLabel.TabIndex = 3;
        CurrentValueLabel.Text = "label1";
        // 
        // CancelButton
        // 
        CancelButton.Location = new Point(288, 80);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(94, 29);
        CancelButton.TabIndex = 4;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        CancelButton.Click += CancelButton_Click;
        // 
        // ChildForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(426, 172);
        Controls.Add(CancelButton);
        Controls.Add(CurrentValueLabel);
        Controls.Add(ExecuteButton);
        Controls.Add(AddCheckBox);
        Controls.Add(numericUpDown1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "ChildForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "ChildForm";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private NumericUpDown numericUpDown1;
    private CheckBox AddCheckBox;
    private Button ExecuteButton;
    private Label CurrentValueLabel;
    private Button CancelButton;
}