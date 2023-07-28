using FileManagement.Application.Services.ProcessorService;
using FileManagement.Application.Utils;
using FileManagement.Domain.Interfaces.Factories;

namespace FileManagement.Application.Factories;

public class FileProcessorFactory : IFileProcessorFactory
{
    public IFileProcessor? CreateFileProcessor(string fileExtension)
    {
        return fileExtension.ToLower() switch
        {
            FileExtensionUtils.Csv =>   new CsvFileProcessorService(),
            FileExtensionUtils.Xlsx => new XlsxFileProcessorService(),
            _ => null
        };
    }
}