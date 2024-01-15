using Backend.Dtos;
using Backend.Services;
using TippsBackend.Services;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class FilesController
{
    private readonly FileService _fileService;
    public FilesController(FileService fileService) => _fileService = fileService;

    [HttpGet]
    public List<FileDto> Files()
    {
        return _fileService.GetAllFiles();
    }

    [HttpPost]
    public FileDto Files(AddFileDto addFileDto)
    {
        return _fileService.PostFile(addFileDto);
    }
}
