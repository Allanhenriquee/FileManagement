using FileManagement.Domain.Headers;

namespace FileManagement.Domain.Interfaces.Factories;

public interface IFileProcessor
{
    Task ProcessFileAsync(byte[] fileData, BaseFileHeader header);
}