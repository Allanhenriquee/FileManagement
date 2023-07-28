using Microsoft.AspNetCore.Http;

namespace FileManagement.Domain.Interfaces.Services;

public interface IFileService
{
    Task ProcessFileAsync(IFormFile file);
}