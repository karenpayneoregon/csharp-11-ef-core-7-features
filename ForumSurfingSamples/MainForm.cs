#nullable disable
using ConsoleConfigurationLibrary.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ForumSurfingSamples;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        Debug.WriteLine(AppConnections.Instance.MainConnection);
        Debug.WriteLine(EntitySettings.Instance.CreateNew);


    }

}


