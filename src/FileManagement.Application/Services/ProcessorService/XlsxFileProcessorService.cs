using System.Reflection;
using ClosedXML.Excel;
using FileManagement.Domain.Headers;
using FileManagement.Domain.Interfaces.Factories;

namespace FileManagement.Application.Services.ProcessorService;

public class XlsxFileProcessorService : IFileProcessor
{
    public Task ProcessFileAsync(byte[] fileData, BaseFileHeader header)
    {
        using (var stream = new MemoryStream(fileData))
        {
            using (var workbook = new XLWorkbook(stream))
            {
                var worksheet = workbook.Worksheet(1);
                var visitor = new QuotationServiceVisitor();

                var columnIndexMap = CreateColumnIndexMap(worksheet.FirstRow());

                var headerRowIndex = worksheet.FirstRow().RowNumber();

                var headerType = header.GetType();
                var acceptMethod = headerType.GetMethod("Accept");

                for (var row = headerRowIndex + 1; row <= worksheet.LastRowUsed().RowNumber(); row++)
                {
                    var record = CreateInstance(headerType);

                    foreach (var property in headerType.GetProperties())
                    {
                        var columnName = property.Name;
                        if (columnIndexMap.TryGetValue(columnName, out var columnIndex))
                        {
                            var cell = worksheet.Cell(row, columnIndex);
                            var cellValue = cell.Value.ToString();

                            property.SetValue(record, ConvertValue(cellValue, property.PropertyType));
                        }
                    }

                    if (acceptMethod != null) InvokeAcceptMethod(record, acceptMethod, visitor);
                }
            }
        }
        
        return Task.CompletedTask;
    }

    private static Dictionary<string, int> CreateColumnIndexMap(IXLRangeBase headerRow)
    {
        var columnIndexMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var cell in headerRow.CellsUsed())
        {
            var headerValue = cell.Value.ToString();
            columnIndexMap[headerValue] = cell.Address.ColumnNumber;
        }

        return columnIndexMap;
    }

    private static object? CreateInstance(Type type)
    {
        return Activator.CreateInstance(type);
    }

    private static object ConvertValue(string value, Type targetType)
    {
        return Convert.ChangeType(value, targetType);
    }

    private static void InvokeAcceptMethod(object? record, MethodBase acceptMethod, QuotationServiceVisitor visitor)
    {
        acceptMethod.Invoke(record, new object[] {visitor});
    }
}