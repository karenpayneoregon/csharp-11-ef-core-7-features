using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestionOfTheDay.Extensions;
public static class GenericExtensions
{

    public static string DataTableToJson(this DataTable dataTable)
    {
        if (dataTable == null)
        {
            return string.Empty;
        }

        var data = dataTable.Rows.OfType<DataRow>()
            .Select(row => dataTable.Columns.OfType<DataColumn>()
                .ToDictionary(col => col.ColumnName, c => row[c]));

        return System.Text.Json.JsonSerializer.Serialize(data);
    }
    public static DataTable? ToDataTable(string sender)
    {
        DataTable? dataTable = new();
        if (string.IsNullOrWhiteSpace(sender))
        {
            return dataTable;
        }

        JsonElement data = JsonSerializer.Deserialize<JsonElement>(sender);
        if (data.ValueKind != JsonValueKind.Array)
        {
            return dataTable;
        }

        var dataArray = data.EnumerateArray();
        JsonElement firstObject = dataArray.First();

        var firstObjectProperties = firstObject.EnumerateObject();
        foreach (var element in firstObjectProperties)
        {
            dataTable.Columns.Add(element.Name);
        }

        foreach (var obj in dataArray)
        {
            var objProperties = obj.EnumerateObject();
            DataRow newRow = dataTable.NewRow();
            foreach (var item in objProperties)
            {
                newRow[item.Name] = item.Value;
            }
            dataTable.Rows.Add(newRow);
        }

        return dataTable;
    }
}
