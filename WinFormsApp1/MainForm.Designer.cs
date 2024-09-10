namespace WinFormsApp1;

partial class MainForm
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
        CurrentValueLabel = new Label();
        button1 = new Button();
        OperationTypeLabel = new Label();
        SuspendLayout();
        // 
        // CurrentValueLabel
        // 
        CurrentValueLabel.AutoSize = true;
        CurrentValueLabel.Location = new Point(21, 30);
        CurrentValueLabel.Name = "CurrentValueLabel";
        CurrentValueLabel.Size = new Size(50, 20);
        CurrentValueLabel.TabIndex = 0;
        CurrentValueLabel.Text = "label1";
        // 
        // button1
        // 
        button1.Location = new Point(21, 84);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 1;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += ShowChildForm1_Click;
        // 
        // OperationTypeLabel
        // 
        OperationTypeLabel.AutoSize = true;
        OperationTypeLabel.Location = new Point(21, 50);
        OperationTypeLabel.Name = "OperationTypeLabel";
        OperationTypeLabel.Size = new Size(109, 20);
        OperationTypeLabel.TabIndex = 2;
        OperationTypeLabel.Text = "Operation type";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(486, 273);
        Controls.Add(OperationTypeLabel);
        Controls.Add(button1);
        Controls.Add(CurrentValueLabel);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "MainForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label CurrentValueLabel;
    private Button button1;
    private Label OperationTypeLabel;
}