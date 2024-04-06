namespace PeriodicTimerApp;

partial class PeriodicTimerForm
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
        StartButton = new Button();
        StopButton = new Button();
        ShowTimeLabel = new Label();
        ContactNameLabel = new Label();
        SuspendLayout();
        // 
        // StartButton
        // 
        StartButton.Location = new Point(12, 29);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(163, 29);
        StartButton.TabIndex = 0;
        StartButton.Text = "Start";
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += StartButton_Click;
        // 
        // StopButton
        // 
        StopButton.Location = new Point(12, 64);
        StopButton.Name = "StopButton";
        StopButton.Size = new Size(163, 29);
        StopButton.TabIndex = 1;
        StopButton.Text = "Stop";
        StopButton.UseVisualStyleBackColor = true;
        StopButton.Click += StopButton_Click;
        // 
        // ShowTimeLabel
        // 
        ShowTimeLabel.AutoSize = true;
        ShowTimeLabel.Location = new Point(215, 33);
        ShowTimeLabel.Name = "ShowTimeLabel";
        ShowTimeLabel.Size = new Size(103, 20);
        ShowTimeLabel.TabIndex = 2;
        ShowTimeLabel.Text = "Time: 00:00:00";
        // 
        // ContactNameLabel
        // 
        ContactNameLabel.AutoSize = true;
        ContactNameLabel.Location = new Point(215, 64);
        ContactNameLabel.Name = "ContactNameLabel";
        ContactNameLabel.Size = new Size(101, 20);
        ContactNameLabel.TabIndex = 3;
        ContactNameLabel.Text = "Contact name";
        // 
        // PeriodicTimerForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(584, 166);
        Controls.Add(ContactNameLabel);
        Controls.Add(ShowTimeLabel);
        Controls.Add(StopButton);
        Controls.Add(StartButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "PeriodicTimerForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Periodic Timer";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button StartButton;
    private Button StopButton;
    private Label ShowTimeLabel;
    private Label ContactNameLabel;
}