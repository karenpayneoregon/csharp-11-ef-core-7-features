using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NewStuffApp.Classes;
public static partial class DataGridViewExtensions
{
    /// <summary>
    /// Expand all column widths 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="sizable"></param>
    public static void ExpandColumns(this DataGridView source, bool sizable = false)
    {
        foreach (DataGridViewColumn col in source.Columns)
        {
            if (col.ValueType!.Name != "ICollection`1")
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        if (!sizable) return;

        for (int index = 0; index <= source.Columns.Count - 1; index++)
        {
            int columnWidth = source.Columns[index].Width;

            source.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            source.Columns[index].Width = columnWidth;
        }

    }

    /// <summary>
    /// Convert column names like FirstName to First Name
    /// </summary>
    /// <param name="source"></param>
    public static void FixHeaders(this DataGridView source)
    {


        for (int index = 0; index < source.Columns.Count; index++)
        {
            source.Columns[index].HeaderText = SplitCase(source.Columns[index].HeaderText);
        }
    }

    [DebuggerStepThrough]
    public static string SplitCase(this string sender) =>
        string.Join(" ", CaseRegEx().Matches(sender)
            .Select(m => m.Value));

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CaseRegEx();
}
