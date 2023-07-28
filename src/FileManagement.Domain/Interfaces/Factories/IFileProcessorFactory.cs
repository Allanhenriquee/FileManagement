namespace FileManagement.Domain.Interfaces.Factories;

public interface IFileProcessorFactory
{
    IFileProcessor? CreateFileProcessor(string fileExtension);
}