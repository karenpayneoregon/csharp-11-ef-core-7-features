using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2;
public partial class Form3 : Form
{
    public delegate void OnMenuEnable(bool sender);
    public event OnMenuEnable? MenuEnable;
    public Form3()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        MenuEnable?.Invoke(true);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        MenuEnable?.Invoke(false);
    }
}
