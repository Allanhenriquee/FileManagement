using CsvHelper.Configuration.Attributes;
using FileManagement.Domain.Interfaces.Visitors;

namespace FileManagement.Domain.Headers.ProductsHeaders;

public class BikeHeader : BaseFileHeader, IBaseVisitor
{
    [Name("is_new")]
    public bool IsNew { get; set; }

    public void Accept(ISendQuotationVisitor visitor)
    {
        visitor.QuotationBikeVisitor(this);
    }
}