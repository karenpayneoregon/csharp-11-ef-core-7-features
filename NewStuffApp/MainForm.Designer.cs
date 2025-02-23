﻿namespace NewStuffApp;

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
        IsActiveColumn = new DataGridViewCheckBoxColumn();
        FirstNameColumn = new DataGridViewTextBoxColumn();
        LastNameColumn = new DataGridViewTextBoxColumn();
        GenderColumn = new DataGridViewTextBoxColumn();
        BirthDateColumn = new DataGridViewTextBoxColumn();
        panel1 = new Panel();
        ParamsButton = new Button();
        RemarksLabel = new Label();
        CurrentButton = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IsActiveColumn, FirstNameColumn, LastNameColumn, GenderColumn, BirthDateColumn });
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(706, 378);
        dataGridView1.TabIndex = 0;
        // 
        // IsActiveColumn
        // 
        IsActiveColumn.DataPropertyName = "IsActive";
        IsActiveColumn.HeaderText = "Active";
        IsActiveColumn.MinimumWidth = 6;
        IsActiveColumn.Name = "IsActiveColumn";
        IsActiveColumn.Resizable = DataGridViewTriState.True;
        IsActiveColumn.SortMode = DataGridViewColumnSortMode.Automatic;
        IsActiveColumn.Width = 125;
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
        panel1.Controls.Add(ParamsButton);
        panel1.Controls.Add(RemarksLabel);
        panel1.Controls.Add(CurrentButton);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 378);
        panel1.Name = "panel1";
        panel1.Size = new Size(706, 72);
        panel1.TabIndex = 1;
        // 
        // ParamsButton
        // 
        ParamsButton.Location = new Point(600, 25);
        ParamsButton.Name = "ParamsButton";
        ParamsButton.Size = new Size(94, 29);
        ParamsButton.TabIndex = 2;
        ParamsButton.Text = "Params";
        ParamsButton.UseVisualStyleBackColor = true;
        ParamsButton.Click += ParamsButton_Click;
        // 
        // RemarksLabel
        // 
        RemarksLabel.AutoSize = true;
        RemarksLabel.Location = new Point(129, 25);
        RemarksLabel.Name = "RemarksLabel";
        RemarksLabel.Size = new Size(50, 20);
        RemarksLabel.TabIndex = 1;
        RemarksLabel.Text = "label1";
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
        ClientSize = new Size(706, 450);
        Controls.Add(dataGridView1);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "C# 13 - fields partial class example";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private Panel panel1;
    private Button CurrentButton;
    private DataGridViewCheckBoxColumn IsActiveColumn;
    private DataGridViewTextBoxColumn FirstNameColumn;
    private DataGridViewTextBoxColumn LastNameColumn;
    private DataGridViewTextBoxColumn GenderColumn;
    private DataGridViewTextBoxColumn BirthDateColumn;
    private Label RemarksLabel;
    private Button ParamsButton;
}
