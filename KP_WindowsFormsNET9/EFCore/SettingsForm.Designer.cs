namespace KP_WindowsFormsNET9.EFCore;

partial class SettingsForm
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
        ModeComboBox = new ComboBox();
        ChangeButton = new Button();
        CloseFormButton = new Button();
        SuspendLayout();
        // 
        // ModeComboBox
        // 
        ModeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ModeComboBox.FormattingEnabled = true;
        ModeComboBox.Location = new Point(12, 31);
        ModeComboBox.Name = "ModeComboBox";
        ModeComboBox.Size = new Size(273, 28);
        ModeComboBox.TabIndex = 0;
        // 
        // ChangeButton
        // 
        ChangeButton.Location = new Point(12, 97);
        ChangeButton.Name = "ChangeButton";
        ChangeButton.Size = new Size(94, 29);
        ChangeButton.TabIndex = 1;
        ChangeButton.Text = "Change";
        ChangeButton.UseVisualStyleBackColor = true;
        ChangeButton.Click += ChangeButton_Click;
        // 
        // CloseFormButton
        // 
        CloseFormButton.DialogResult = DialogResult.Cancel;
        CloseFormButton.Location = new Point(191, 97);
        CloseFormButton.Name = "CloseFormButton";
        CloseFormButton.Size = new Size(94, 29);
        CloseFormButton.TabIndex = 2;
        CloseFormButton.Text = "Cancel";
        CloseFormButton.UseVisualStyleBackColor = true;
        // 
        // SettingsForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(297, 149);
        Controls.Add(CloseFormButton);
        Controls.Add(ChangeButton);
        Controls.Add(ModeComboBox);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "SettingsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Settings";
        ResumeLayout(false);
    }

    #endregion

    private ComboBox ModeComboBox;
    private Button ChangeButton;
    private Button CloseFormButton;
}