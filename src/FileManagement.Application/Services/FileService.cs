using System.ComponentModel.DataAnnotations;
using FileManagement.Domain.Interfaces.Factories;
using FileManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Application.Services;

public class FileService : IFileService
{
    private readonly IFileProcessorFactory _fileProcessorFactory;
    private readonly IFileHeaderFactory _fileHeaderFactory;

    public FileService(IFileProcessorFactory fileProcessorFactory, IFileHeaderFactory fileHeaderFactory)
    {
        _fileProcessorFactory = fileProcessorFactory;
        _fileHeaderFactory = fileHeaderFactory;
    }

    public async Task ProcessFileAsync(IFormFile file)
    {
        var fileExtension = Path.GetExtension(file.FileName);

        var fileProcessor = _fileProcessorFactory.CreateFileProcessor(fileExtension);
        
        if (fileProcessor == null) 
            throw new NotSupportedException("Formato de arquivo não suportado");
        
        var header = _fileHeaderFactory.CreateFileHeader(file.FileName);

        if (header == null)
            throw new ValidationException("Nome do arquivo não corresponde com nenhum header cadastrado");
        
        var fileData = ReadFileData(file).Result;
        await fileProcessor.ProcessFileAsync(fileData, header);
    }

    private static async Task<byte[]> ReadFileData(IFormFile file)
    {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        return ms.ToArray();
    }
}