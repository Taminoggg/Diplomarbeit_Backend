using Backend.Dtos;
using Backend.Services;
using TippsBackend.Services;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly FileService _fileService;
    public FilesController(FileService fileService) => _fileService = fileService;

    [HttpGet]
    public List<FileDto> Files()
    {
        return _fileService.GetAllFiles();
    }

    [HttpGet("{id}")]
    public FileByteDto File(int id)
    {
        return _fileService.GetFile(id);
    }

    [HttpPost]
    public FileDto Files(IFormFile addFileDto)
    {
        return _fileService.PostFile(addFileDto);
    }
}
