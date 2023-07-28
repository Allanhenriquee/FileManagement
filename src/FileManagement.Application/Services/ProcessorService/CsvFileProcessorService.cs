using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using FileManagement.Domain.Headers;
using FileManagement.Domain.Interfaces.Factories;

namespace FileManagement.Application.Services.ProcessorService;

public class CsvFileProcessorService : IFileProcessor
{
    public Task ProcessFileAsync(byte[] fileData, BaseFileHeader header)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ",",
        };

        using var memoryStream = new MemoryStream(fileData);
        using var streamReader = new StreamReader(memoryStream, Encoding.UTF8);
        using (var csv = new CsvReader(streamReader, config))
        {
            var headerType = header.GetType();
            var listRecords = csv.GetRecords(headerType).ToList();
            var visitor = new QuotationServiceVisitor();
            
            foreach (var record in listRecords)
            {
                var recordType = record?.GetType();
                var acceptMethod = recordType?.GetMethod("Accept");
                acceptMethod?.Invoke(record, new object[] { visitor });
            }
        }

        return Task.CompletedTask;
    }
}