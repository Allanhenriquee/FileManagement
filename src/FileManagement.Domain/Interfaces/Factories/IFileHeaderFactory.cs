using FileManagement.Domain.Headers;

namespace FileManagement.Domain.Interfaces.Factories;

public interface IFileHeaderFactory
{
    BaseFileHeader? CreateFileHeader(string fileName);
}