using FileManagement.Application.Utils;
using FileManagement.Domain.Headers;
using FileManagement.Domain.Headers.ProductsHeaders;
using FileManagement.Domain.Interfaces.Factories;

namespace FileManagement.Application.Factories;

public class FileHeaderFactory : IFileHeaderFactory
{
    public BaseFileHeader? CreateFileHeader(string fileName)
    {
        return fileName switch
        {
            not null when fileName.Contains(HeaderUtils.Car, StringComparison.OrdinalIgnoreCase) =>
                new CarHeader(),
            not null when fileName.Contains(HeaderUtils.Bike, StringComparison.OrdinalIgnoreCase) =>
                new BikeHeader(),
            _ => null
        };
    }

}