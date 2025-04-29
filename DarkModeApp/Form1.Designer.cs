namespace DarkModeApp;

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
        dataGridView1 = new DataGridView();
        MonthComboBox = new ComboBox();
        label1 = new Label();
        UserNameTextBox = new TextBox();
        ActiveCheckBox = new CheckBox();
        groupBox1 = new GroupBox();
        CloseAppButton = new Button();
        DialogQuestionButton = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(1009, 290);
        dataGridView1.TabIndex = 0;
        // 
        // MonthComboBox
        // 
        MonthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        MonthComboBox.FormattingEnabled = true;
        MonthComboBox.Location = new Point(24, 27);
        MonthComboBox.Name = "MonthComboBox";
        MonthComboBox.Size = new Size(179, 28);
        MonthComboBox.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(224, 31);
        label1.Name = "label1";
        label1.Size = new Size(79, 20);
        label1.TabIndex = 2;
        label1.Text = "User name";
        // 
        // UserNameTextBox
        // 
        UserNameTextBox.Location = new Point(309, 28);
        UserNameTextBox.Name = "UserNameTextBox";
        UserNameTextBox.Size = new Size(125, 27);
        UserNameTextBox.TabIndex = 3;
        UserNameTextBox.Text = "KarenPayne";
        // 
        // ActiveCheckBox
        // 
        ActiveCheckBox.AutoSize = true;
        ActiveCheckBox.Checked = true;
        ActiveCheckBox.CheckState = CheckState.Checked;
        ActiveCheckBox.Location = new Point(466, 27);
        ActiveCheckBox.Name = "ActiveCheckBox";
        ActiveCheckBox.Size = new Size(72, 24);
        ActiveCheckBox.TabIndex = 4;
        ActiveCheckBox.Text = "Active";
        ActiveCheckBox.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(ActiveCheckBox);
        groupBox1.Controls.Add(UserNameTextBox);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(MonthComboBox);
        groupBox1.Location = new Point(18, 324);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(560, 77);
        groupBox1.TabIndex = 5;
        groupBox1.TabStop = false;
        groupBox1.Text = "groupBox1";
        // 
        // CloseAppButton
        // 
        CloseAppButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        CloseAppButton.Location = new Point(891, 349);
        CloseAppButton.Name = "CloseAppButton";
        CloseAppButton.Size = new Size(94, 29);
        CloseAppButton.TabIndex = 6;
        CloseAppButton.Text = "Exit";
        CloseAppButton.UseVisualStyleBackColor = true;
        CloseAppButton.Click += CloseAppButton_Click;
        // 
        // DialogQuestionButton
        // 
        DialogQuestionButton.Location = new Point(600, 351);
        DialogQuestionButton.Name = "DialogQuestionButton";
        DialogQuestionButton.Size = new Size(94, 29);
        DialogQuestionButton.TabIndex = 7;
        DialogQuestionButton.Text = "Question";
        DialogQuestionButton.UseVisualStyleBackColor = true;
        DialogQuestionButton.Click += DialogQuestionButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1009, 411);
        Controls.Add(DialogQuestionButton);
        Controls.Add(CloseAppButton);
        Controls.Add(groupBox1);
        Controls.Add(dataGridView1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Code sample";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private ComboBox MonthComboBox;
    private Label label1;
    private TextBox UserNameTextBox;
    private CheckBox ActiveCheckBox;
    private GroupBox groupBox1;
    private Button CloseAppButton;
    private Button DialogQuestionButton;
}
