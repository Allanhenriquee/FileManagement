using CsvHelper.Configuration.Attributes;
using FileManagement.Domain.Interfaces.Visitors;

namespace FileManagement.Domain.Headers.ProductsHeaders;

public class CarHeader : BaseFileHeader, IBaseVisitor
{
    [Name("brand")]
    public string? Brand { get; set; }
    
    [Name("value")]
    public string? Value { get; set; }

    public void Accept(ISendQuotationVisitor visitor)
    {
        visitor.QuotationCarVisitor(this);
    }
}