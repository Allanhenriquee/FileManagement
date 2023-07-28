using FileManagement.Domain.Headers.ProductsHeaders;

namespace FileManagement.Domain.Interfaces.Visitors;

public interface ISendQuotationVisitor
{
    void QuotationBikeVisitor(BikeHeader bike);
    void QuotationCarVisitor(CarHeader car);
}