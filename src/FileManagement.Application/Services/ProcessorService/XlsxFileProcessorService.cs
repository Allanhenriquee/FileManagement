using FileManagement.Domain.Headers;
using FileManagement.Domain.Interfaces.Factories;
using MiniExcelLibs;

namespace FileManagement.Application.Services.ProcessorService;

public class XlsxFileProcessorService : IFileProcessor
{
    public Task ProcessFileAsync(byte[] fileData, BaseFileHeader header)
    {
        using var memoryStream = new MemoryStream(fileData);
        var rows = memoryStream.Query(true).ToList();
        var visitor = new QuotationServiceVisitor();

        foreach (var record in rows)
        {
            var recordObject = Activator.CreateInstance(header.GetType());
            
            foreach (var prop in header.GetType().GetProperties())
            {
                if (record is IDictionary<string, object> recordDictionary)
                {
                    if (recordDictionary.TryGetValue(prop.Name, out var propertyValue))
                    {
                        var convertedValue = ConvertToPropertyType(propertyValue, prop.PropertyType);
                        prop.SetValue(recordObject, convertedValue);
                    }
                }
            }
            
            var acceptMethod = recordObject.GetType().GetMethod("Accept");
            acceptMethod?.Invoke(recordObject, new object[] { visitor });
        }

        return Task.CompletedTask;
    }
    
    private object ConvertToPropertyType(object value, Type propertyType)
    {
        return Convert.ChangeType(value, propertyType);
    }
}