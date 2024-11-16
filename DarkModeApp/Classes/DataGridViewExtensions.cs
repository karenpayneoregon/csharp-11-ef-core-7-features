namespace DarkModeApp.Classes;

public static partial class DataGridViewExtensions
{
    /// <summary>
    /// Expands the columns of the specified <see cref="DataGridView"/> to fit their content.
    /// </summary>
    /// <param name="source">The <see cref="DataGridView"/> whose columns will be expanded.</param>
    /// <param name="sizable">Indicates whether the columns should be resizable after being expanded. Default is <c>true</c>.</param>
    public static void ExpandColumns(this DataGridView source, bool sizable = true)
    {

        source.FixHeaders();

        foreach (DataGridViewColumn col in source.Columns)
        {
            // no need for this with NET8, something change in NET9   
            if (col.DataPropertyName == "Email")
            {
                col.Width = 300;
            }
            else
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
    /// Applies custom dark mode styling to the headers of the specified <see cref="DataGridView"/>.
    /// </summary>
    /// <param name="source">The <see cref="DataGridView"/> whose headers will be colorized for dark mode.</param>
    /// <remarks>Feel free to change the colors</remarks>
    public static void ColorizeDarkModeHeaders(this DataGridView source)
    {
        source.EnableHeadersVisualStyles = false;
        source.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;

    }

    /// <summary>
    /// Adjusts the headers of the specified <see cref="DataGridView"/> by splitting camel case words into separate words.
    /// </summary>
    /// <param name="source">The <see cref="DataGridView"/> whose headers will be adjusted.</param>
    public static void FixHeaders(this DataGridView source)
    {
        string SplitCamelCase(string sender) => string.Join(" ", SplitCamelCaseRegex().Matches(sender).Select(m => m.Value));

        for (var index = 0; index < source.Columns.Count; index++)
        {
            source.Columns[index].HeaderText = SplitCamelCase(source.Columns[index].HeaderText);
        }
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial System.Text.RegularExpressions.Regex SplitCamelCaseRegex();
}