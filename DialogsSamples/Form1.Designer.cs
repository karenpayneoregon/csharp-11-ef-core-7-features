namespace DialogsSamples;

partial class Form1
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
        QuestionButton1 = new Button();
        QuestionButton2 = new Button();
        SuspendLayout();
        // 
        // QuestionButton1
        // 
        QuestionButton1.Location = new Point(12, 12);
        QuestionButton1.Name = "QuestionButton1";
        QuestionButton1.Size = new Size(94, 29);
        QuestionButton1.TabIndex = 0;
        QuestionButton1.Text = "Question 1";
        QuestionButton1.UseVisualStyleBackColor = true;
        QuestionButton1.Click += QuestionButton1_Click;
        // 
        // QuestionButton2
        // 
        QuestionButton2.Location = new Point(542, 248);
        QuestionButton2.Name = "QuestionButton2";
        QuestionButton2.Size = new Size(94, 29);
        QuestionButton2.TabIndex = 1;
        QuestionButton2.Text = "Question 2";
        QuestionButton2.UseVisualStyleBackColor = true;
        QuestionButton2.Click += QuestionButton2_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(722, 358);
        Controls.Add(QuestionButton2);
        Controls.Add(QuestionButton1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dialogs sample";
        ResumeLayout(false);
    }

    #endregion

    private Button QuestionButton1;
    private Button QuestionButton2;
}
