namespace KP_WindowsFormsNET9;

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
        CloseThisFormButton = new Button();
        label1 = new Label();
        FirstNameTextBox = new TextBox();
        label2 = new Label();
        LastNameTextBox = new TextBox();
        SuspendLayout();
        // 
        // CloseThisFormButton
        // 
        CloseThisFormButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        CloseThisFormButton.DialogResult = DialogResult.OK;
        CloseThisFormButton.Image = Properties.Resources.Exit_16x;
        CloseThisFormButton.ImageAlign = ContentAlignment.MiddleLeft;
        CloseThisFormButton.Location = new Point(174, 184);
        CloseThisFormButton.Name = "CloseThisFormButton";
        CloseThisFormButton.Size = new Size(94, 29);
        CloseThisFormButton.TabIndex = 0;
        CloseThisFormButton.Text = "Accept";
        CloseThisFormButton.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(27, 24);
        label1.Name = "label1";
        label1.Size = new Size(77, 20);
        label1.TabIndex = 1;
        label1.Text = "First name";
        // 
        // FirstNameTextBox
        // 
        FirstNameTextBox.Location = new Point(27, 47);
        FirstNameTextBox.Name = "FirstNameTextBox";
        FirstNameTextBox.Size = new Size(241, 27);
        FirstNameTextBox.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(27, 86);
        label2.Name = "label2";
        label2.Size = new Size(76, 20);
        label2.TabIndex = 3;
        label2.Text = "Last name";
        // 
        // LastNameTextBox
        // 
        LastNameTextBox.Location = new Point(27, 109);
        LastNameTextBox.Name = "LastNameTextBox";
        LastNameTextBox.Size = new Size(241, 27);
        LastNameTextBox.TabIndex = 4;
        // 
        // ChildForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(295, 229);
        Controls.Add(LastNameTextBox);
        Controls.Add(label2);
        Controls.Add(FirstNameTextBox);
        Controls.Add(label1);
        Controls.Add(CloseThisFormButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "ChildForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "ChildForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button CloseThisFormButton;
    private Label label1;
    private TextBox FirstNameTextBox;
    private Label label2;
    private TextBox LastNameTextBox;
}