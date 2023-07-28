namespace FileManagement.Domain.Interfaces.Visitors;

public interface IBaseVisitor
{
    void Accept(ISendQuotationVisitor visitor);
}