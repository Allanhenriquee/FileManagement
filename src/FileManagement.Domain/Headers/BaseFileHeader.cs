using CsvHelper.Configuration.Attributes;
using FileManagement.Domain.Interfaces.Visitors;

namespace FileManagement.Domain.Headers;

public class BaseFileHeader
{
    [Name("product")]
    public string? Product { get; set; }
    
    [Name("customer")]
    public string? Customer { get; set; }
    
}