using CsvHelper.Configuration;
using FileManagement.Domain.Headers.ProductsHeaders;

namespace FileManagement.Domain.MappingCsv;

public class BikeMapping : ClassMap<BikeHeader>
{
    public BikeMapping()
    {
        Map(p => p.Product).Name("product");
        Map(p => p.Customer).Name("customer");
        Map(p => p.IsNew).Name("is_new");
    }
}