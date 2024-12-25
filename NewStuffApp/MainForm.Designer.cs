namespace NewStuffApp;

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
        dataGridView1 = new DataGridView();
        FirstNameColumn = new DataGridViewTextBoxColumn();
        LastNameColumn = new DataGridViewTextBoxColumn();
        GenderColumn = new DataGridViewTextBoxColumn();
        BirthDateColumn = new DataGridViewTextBoxColumn();
        panel1 = new Panel();
        CurrentButton = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { FirstNameColumn, LastNameColumn, GenderColumn, BirthDateColumn });
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(570, 378);
        dataGridView1.TabIndex = 0;
        // 
        // FirstNameColumn
        // 
        FirstNameColumn.DataPropertyName = "FirstName";
        FirstNameColumn.HeaderText = "First";
        FirstNameColumn.MinimumWidth = 6;
        FirstNameColumn.Name = "FirstNameColumn";
        FirstNameColumn.Width = 125;
        // 
        // LastNameColumn
        // 
        LastNameColumn.DataPropertyName = "LastName";
        LastNameColumn.HeaderText = "Last";
        LastNameColumn.MinimumWidth = 6;
        LastNameColumn.Name = "LastNameColumn";
        LastNameColumn.Width = 125;
        // 
        // GenderColumn
        // 
        GenderColumn.DataPropertyName = "Gender";
        GenderColumn.HeaderText = "Gender";
        GenderColumn.MinimumWidth = 6;
        GenderColumn.Name = "GenderColumn";
        GenderColumn.Width = 125;
        // 
        // BirthDateColumn
        // 
        BirthDateColumn.DataPropertyName = "BirthDate";
        BirthDateColumn.HeaderText = "Birth";
        BirthDateColumn.MinimumWidth = 6;
        BirthDateColumn.Name = "BirthDateColumn";
        BirthDateColumn.Width = 125;
        // 
        // panel1
        // 
        panel1.Controls.Add(CurrentButton);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 378);
        panel1.Name = "panel1";
        panel1.Size = new Size(570, 72);
        panel1.TabIndex = 1;
        // 
        // CurrentButton
        // 
        CurrentButton.Location = new Point(12, 21);
        CurrentButton.Name = "CurrentButton";
        CurrentButton.Size = new Size(94, 29);
        CurrentButton.TabIndex = 0;
        CurrentButton.Text = "Current";
        CurrentButton.UseVisualStyleBackColor = true;
        CurrentButton.Click += CurrentButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(570, 450);
        Controls.Add(dataGridView1);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "C# 13 - fields partial class example";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private Panel panel1;
    private DataGridViewTextBoxColumn FirstNameColumn;
    private DataGridViewTextBoxColumn LastNameColumn;
    private DataGridViewTextBoxColumn GenderColumn;
    private DataGridViewTextBoxColumn BirthDateColumn;
    private Button CurrentButton;
}
