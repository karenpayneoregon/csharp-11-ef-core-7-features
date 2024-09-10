namespace WinFormsApp1;

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
        listBox1 = new ListBox();
        GetZonesButton = new Button();
        listBox2 = new ListBox();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        SuspendLayout();
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(43, 35);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(290, 164);
        listBox1.TabIndex = 0;
        // 
        // GetZonesButton
        // 
        GetZonesButton.Location = new Point(360, 35);
        GetZonesButton.Name = "GetZonesButton";
        GetZonesButton.Size = new Size(94, 29);
        GetZonesButton.TabIndex = 1;
        GetZonesButton.Text = "Test";
        GetZonesButton.UseVisualStyleBackColor = true;
        GetZonesButton.Click += GetZonesButton_Click;
        // 
        // listBox2
        // 
        listBox2.FormattingEnabled = true;
        listBox2.Location = new Point(45, 224);
        listBox2.Name = "listBox2";
        listBox2.Size = new Size(287, 104);
        listBox2.TabIndex = 3;
        // 
        // button1
        // 
        button1.Location = new Point(360, 80);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 4;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(360, 135);
        button2.Name = "button2";
        button2.Size = new Size(94, 29);
        button2.TabIndex = 5;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(360, 191);
        button3.Name = "button3";
        button3.Size = new Size(94, 29);
        button3.TabIndex = 6;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.Location = new Point(360, 226);
        button4.Name = "button4";
        button4.Size = new Size(94, 29);
        button4.TabIndex = 7;
        button4.Text = "button4";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(listBox2);
        Controls.Add(GetZonesButton);
        Controls.Add(listBox1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBox1;
    private Button GetZonesButton;
    private ListBox listBox2;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
}
