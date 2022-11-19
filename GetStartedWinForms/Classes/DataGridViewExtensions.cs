using System.Text.RegularExpressions;

namespace GetStartedWinForms.Classes;

public static class DataGridViewExtensions
{
    public static void ExpandColumns(this DataGridView source, bool sizable = false)
    {
        foreach (DataGridViewColumn col in source.Columns)
        {
            if (col.ValueType.Name != "ICollection`1")
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        if (!sizable) return;

        for (int index = 0; index <= source.Columns.Count - 1; index++)
        {
            int columnWidth = source.Columns[index].Width;

            source.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Set Width to calculated AutoSize value:
            source.Columns[index].Width = columnWidth;
        }


    }
    /// <summary>
    /// Convert column Header text to a delimited string
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string DelimitedHeaders(this DataGridView sender) =>
        string.Join(",", sender.Columns.OfType<DataGridViewColumn>()
            .Select(column => column.HeaderText).ToArray());

    /// <summary>
    /// Create a string array of data in the DataGridView, does not include header
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="delimiter">Delimiter which defaults to a comma</param>
    /// <returns>array comprised of rows/cell data without header</returns>
    public static string[] ToDelimited(this DataGridView sender, string delimiter = ",") =>
        (sender.Rows.Cast<DataGridViewRow>()
            .Where(row => !row.IsNewRow)
            .Select(row => new
            {
                row,
                rowItem = string.Join(delimiter,
                    Array.ConvertAll(row.Cells.Cast<DataGridViewCell>().ToArray(), c =>
                        ((c.Value == null) ? "" : c.Value.ToString())))
            })
            .Select(@t => @t.rowItem)).ToArray();

    /// <summary>
    ///  Create a string array of data in the DataGridView, includes header
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="delimiter">Delimiter which defaults to a comma</param>
    /// <returns>array comprised of rows/cell data with header</returns>
    public static string[] ToDelimitedWithHeaders(this DataGridView sender, string delimiter = ",")
    {
        var headers = sender.DelimitedHeaders();
        var data = sender.ToDelimited().ToList();
        data.Insert(0, headers);
        return data.ToArray();

    }
    /// <summary>
    /// Copy DataGridView contents to Windows Clipboard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="includeHeader">include header or exclude header</param>
    public static void ExportToClipboard(this DataGridView sender, bool includeHeader = false)
    {
        var sbHeader = new System.Text.StringBuilder();
        var headers = sender.Columns.Cast<DataGridViewColumn>();

        if (includeHeader)
        {
            sbHeader.Append(string.Join(",", headers.Select((column) => column.HeaderText)));
        }

        var lines = sender.ToDelimited().ToList();

        if (includeHeader)
        {
            lines.Insert(0, sbHeader.ToString());
        }


        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (var item in lines)
        {
            sb.AppendLine(item);
        }


        Clipboard.SetText(sb.ToString());

    }
    public static bool IsComboBoxCell(this DataGridViewCell sender)
    {
        var result = false;
        if (sender.EditType == null) return false;
        if (sender.EditType == typeof(DataGridViewComboBoxEditingControl))
        {
            result = true;
        }

        return result;
    }

    public static void FixHeaders(this DataGridView source)
    {
        string SplitCamelCase(string sender)
            => string.Join(" ", Regex.Matches(sender, 
                @"([A-Z][a-z]+)").Select(m => m.Value));

        for (int index = 0; index < source.Columns.Count; index++)
        {
            source.Columns[index].HeaderText = SplitCamelCase(source.Columns[index].HeaderText);
        }
    }
}