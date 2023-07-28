using FileManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileManagement.API.Controllers;

[ApiController]
[Route("api/v1/file")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file.Length == 0) return BadRequest("Nenhum arquivo foi enviado.");

        try
        {
            await _fileService.ProcessFileAsync(file);
            return Ok("Arquivo processado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao processar o arquivo: {ex.Message}");
        }
    }
}