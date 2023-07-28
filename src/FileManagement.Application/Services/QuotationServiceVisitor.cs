using FileManagement.Domain.Headers.ProductsHeaders;
using FileManagement.Domain.Interfaces.Visitors;

namespace FileManagement.Application.Services;

public class QuotationServiceVisitor : ISendQuotationVisitor
{
    public void QuotationBikeVisitor(BikeHeader bike)
    {
        Console.WriteLine($"Produto: {bike.Product} - Cliente: {bike.Customer} - É nova? {bike.IsNew}");
        
        //REALIZA O MAPEAMENTO DO OBJETO BIKE
        
        //ENVIA PARA UMA API EXTERNA
    }

    public void QuotationCarVisitor(CarHeader car)
    {
        Console.WriteLine($"Produto: {car.Product} - Cliente: {car.Customer} - Marca {car.Brand} - Valor: {car.Value}");
        
        //REALIZA O MAPEAMENTO DO OBJETO CAR
        
        //ENVIA PARA UMA API EXTERNA
    }
}