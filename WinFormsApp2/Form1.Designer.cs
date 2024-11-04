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
        button2 = new Button();
        menuStrip1 = new MenuStrip();
        mainToolStripMenuItem = new ToolStripMenuItem();
        M_Selecao = new ToolStripMenuItem();
        button3 = new Button();
        UUIDButton = new Button();
        menuStrip1.SuspendLayout();
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
        revealPasswordButton.Click += revealPasswordButton_Click;
        revealPasswordButton.MouseDown += revealPasswordButton_MouseDown;
        revealPasswordButton.MouseUp += revealPasswordButton_MouseUp;
        // 
        // button2
        // 
        button2.Location = new Point(266, 158);
        button2.Name = "button2";
        button2.Size = new Size(94, 29);
        button2.TabIndex = 3;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { mainToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(569, 28);
        menuStrip1.TabIndex = 4;
        menuStrip1.Text = "menuStrip1";
        // 
        // mainToolStripMenuItem
        // 
        mainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { M_Selecao });
        mainToolStripMenuItem.Name = "mainToolStripMenuItem";
        mainToolStripMenuItem.Size = new Size(56, 24);
        mainToolStripMenuItem.Text = "Main";
        // 
        // M_Selecao
        // 
        M_Selecao.Name = "M_Selecao";
        M_Selecao.Size = new Size(134, 26);
        M_Selecao.Text = "Item 1";
        // 
        // button3
        // 
        button3.Location = new Point(389, 158);
        button3.Name = "button3";
        button3.Size = new Size(94, 29);
        button3.TabIndex = 5;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // UUIDButton
        // 
        UUIDButton.Location = new Point(22, 264);
        UUIDButton.Name = "UUIDButton";
        UUIDButton.Size = new Size(94, 29);
        UUIDButton.TabIndex = 6;
        UUIDButton.Text = "UUID";
        UUIDButton.UseVisualStyleBackColor = true;
        UUIDButton.Click += UUIDButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(569, 443);
        Controls.Add(UUIDButton);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(revealPasswordButton);
        Controls.Add(passwordTextBox);
        Controls.Add(button1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        Load += MainForm_Load;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox passwordTextBox;
    private Button revealPasswordButton;
    private Button button2;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem mainToolStripMenuItem;
    private ToolStripMenuItem M_Selecao;
    private Button button3;
    private Button UUIDButton;
}
