namespace GetBirthDateApp;

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
        ZonesComboBox = new ComboBox();
        NodaGetAgeButton = new Button();
        NodaDateTimePicker = new DateTimePicker();
        groupBox1 = new GroupBox();
        NodaAgeTextBox = new Controls.NumericTextBox();
        GetAgeRawButton = new Button();
        GetAgeRawTextBox1 = new Controls.NumericTextBox();
        GetAgeRawTextBox2 = new Controls.NumericTextBox();
        groupBox2 = new GroupBox();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // ZonesComboBox
        // 
        ZonesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ZonesComboBox.FormattingEnabled = true;
        ZonesComboBox.Location = new Point(18, 27);
        ZonesComboBox.Name = "ZonesComboBox";
        ZonesComboBox.Size = new Size(271, 28);
        ZonesComboBox.TabIndex = 0;
        // 
        // NodaGetAgeButton
        // 
        NodaGetAgeButton.Location = new Point(18, 94);
        NodaGetAgeButton.Name = "NodaGetAgeButton";
        NodaGetAgeButton.Size = new Size(271, 29);
        NodaGetAgeButton.TabIndex = 2;
        NodaGetAgeButton.Text = "Get age";
        NodaGetAgeButton.UseVisualStyleBackColor = true;
        NodaGetAgeButton.Click += NodaGetAgeButton_Click;
        // 
        // NodaDateTimePicker
        // 
        NodaDateTimePicker.Location = new Point(18, 61);
        NodaDateTimePicker.Name = "NodaDateTimePicker";
        NodaDateTimePicker.Size = new Size(271, 27);
        NodaDateTimePicker.TabIndex = 4;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(NodaAgeTextBox);
        groupBox1.Controls.Add(NodaDateTimePicker);
        groupBox1.Controls.Add(NodaGetAgeButton);
        groupBox1.Controls.Add(ZonesComboBox);
        groupBox1.Location = new Point(11, 11);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(321, 180);
        groupBox1.TabIndex = 5;
        groupBox1.TabStop = false;
        groupBox1.Text = "NodaTime get age";
        // 
        // NodaAgeTextBox
        // 
        NodaAgeTextBox.Location = new Point(222, 129);
        NodaAgeTextBox.Name = "NodaAgeTextBox";
        NodaAgeTextBox.Size = new Size(67, 27);
        NodaAgeTextBox.TabIndex = 5;
        NodaAgeTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // GetAgeRawButton
        // 
        GetAgeRawButton.Location = new Point(6, 27);
        GetAgeRawButton.Name = "GetAgeRawButton";
        GetAgeRawButton.Size = new Size(271, 29);
        GetAgeRawButton.TabIndex = 6;
        GetAgeRawButton.Text = "Get age";
        GetAgeRawButton.UseVisualStyleBackColor = true;
        GetAgeRawButton.Click += GetAgeRawButton_Click;
        // 
        // GetAgeRawTextBox1
        // 
        GetAgeRawTextBox1.Location = new Point(308, 26);
        GetAgeRawTextBox1.Name = "GetAgeRawTextBox1";
        GetAgeRawTextBox1.Size = new Size(67, 27);
        GetAgeRawTextBox1.TabIndex = 6;
        GetAgeRawTextBox1.TextAlign = HorizontalAlignment.Right;
        // 
        // GetAgeRawTextBox2
        // 
        GetAgeRawTextBox2.Location = new Point(308, 59);
        GetAgeRawTextBox2.Name = "GetAgeRawTextBox2";
        GetAgeRawTextBox2.Size = new Size(67, 27);
        GetAgeRawTextBox2.TabIndex = 7;
        GetAgeRawTextBox2.TextAlign = HorizontalAlignment.Right;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(GetAgeRawTextBox2);
        groupBox2.Controls.Add(GetAgeRawTextBox1);
        groupBox2.Controls.Add(GetAgeRawButton);
        groupBox2.Location = new Point(355, 11);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(415, 180);
        groupBox2.TabIndex = 8;
        groupBox2.TabStop = false;
        groupBox2.Text = "Interesting get age";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(789, 212);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Get Age";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ComboBox ZonesComboBox;
    private Button NodaGetAgeButton;
    private DateTimePicker NodaDateTimePicker;
    private GroupBox groupBox1;
    private Controls.NumericTextBox NodaAgeTextBox;
    private Button GetAgeRawButton;
    private Controls.NumericTextBox GetAgeRawTextBox1;
    private Controls.NumericTextBox GetAgeRawTextBox2;
    private GroupBox groupBox2;
}
