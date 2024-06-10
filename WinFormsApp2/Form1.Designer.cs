namespace WinFormsApp2;

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
        passwordTextBox = new TextBox();
        revealPasswordButton = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(22, 158);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += selectCustomerButton_Click;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Location = new Point(65, 53);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.Size = new Size(181, 27);
        passwordTextBox.TabIndex = 1;
        passwordTextBox.Text = "pass";
        // 
        // revealPasswordButton
        // 
        revealPasswordButton.Location = new Point(266, 53);
        revealPasswordButton.Name = "revealPasswordButton";
        revealPasswordButton.Size = new Size(94, 29);
        revealPasswordButton.TabIndex = 2;
        revealPasswordButton.Text = "button2";
        revealPasswordButton.UseVisualStyleBackColor = true;
        revealPasswordButton.MouseDown += revealPasswordButton_MouseDown;
        revealPasswordButton.MouseUp += revealPasswordButton_MouseUp;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(569, 227);
        Controls.Add(revealPasswordButton);
        Controls.Add(passwordTextBox);
        Controls.Add(button1);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        Load += MainForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox passwordTextBox;
    private Button revealPasswordButton;
}
