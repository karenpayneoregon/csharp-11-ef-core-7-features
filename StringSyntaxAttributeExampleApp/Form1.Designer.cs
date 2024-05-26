namespace StringSyntaxAttributeExampleApp;

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
        DateFormatButton = new Button();
        NumberFormatButton = new Button();
        CompositeFormatButton = new Button();
        button1 = new Button();
        SuspendLayout();
        // 
        // DateFormatButton
        // 
        DateFormatButton.Location = new Point(30, 22);
        DateFormatButton.Name = "DateFormatButton";
        DateFormatButton.Size = new Size(215, 29);
        DateFormatButton.TabIndex = 0;
        DateFormatButton.Text = "Date format";
        DateFormatButton.UseVisualStyleBackColor = true;
        DateFormatButton.Click += DateFormatButton_Click;
        // 
        // NumberFormatButton
        // 
        NumberFormatButton.Location = new Point(264, 22);
        NumberFormatButton.Name = "NumberFormatButton";
        NumberFormatButton.Size = new Size(215, 29);
        NumberFormatButton.TabIndex = 1;
        NumberFormatButton.Text = "Number format";
        NumberFormatButton.UseVisualStyleBackColor = true;
        NumberFormatButton.Click += NumberFormatButton_Click;
        // 
        // CompositeFormatButton
        // 
        CompositeFormatButton.Location = new Point(30, 57);
        CompositeFormatButton.Name = "CompositeFormatButton";
        CompositeFormatButton.Size = new Size(215, 29);
        CompositeFormatButton.TabIndex = 2;
        CompositeFormatButton.Text = "Composite format";
        CompositeFormatButton.UseVisualStyleBackColor = true;
        CompositeFormatButton.Click += CompositeFormatButton_Click;
        // 
        // button1
        // 
        button1.Location = new Point(30, 92);
        button1.Name = "button1";
        button1.Size = new Size(215, 29);
        button1.TabIndex = 3;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button1);
        Controls.Add(CompositeFormatButton);
        Controls.Add(NumberFormatButton);
        Controls.Add(DateFormatButton);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button DateFormatButton;
    private Button NumberFormatButton;
    private Button CompositeFormatButton;
    private Button button1;
}
