namespace KP_WindowsFormsNET9;

partial class ChildForm
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
        CloseThisFormButton = new Button();
        SuspendLayout();
        // 
        // CloseThisFormButton
        // 
        CloseThisFormButton.DialogResult = DialogResult.OK;
        CloseThisFormButton.Location = new Point(283, 227);
        CloseThisFormButton.Name = "CloseThisFormButton";
        CloseThisFormButton.Size = new Size(94, 29);
        CloseThisFormButton.TabIndex = 0;
        CloseThisFormButton.Text = "Close";
        CloseThisFormButton.UseVisualStyleBackColor = true;
        // 
        // ChildForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(389, 280);
        Controls.Add(CloseThisFormButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "ChildForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "ChildForm";
        ResumeLayout(false);
    }

    #endregion

    private Button CloseThisFormButton;
}