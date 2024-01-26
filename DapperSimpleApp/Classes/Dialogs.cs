using System.Windows.Forms;

namespace DapperSimpleApp.Classes
{
    public static class Dialogs
    {
        public static bool Question(string text) =>
            (MessageBox.Show(
                text,
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes);
    }
}
