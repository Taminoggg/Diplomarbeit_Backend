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
        return _fileService.GetAllFiles().Select(x => new FileDto().CopyFrom(x)).ToList();
    }

    [HttpGet("{id}")]
    public FileByteDto? File(int id)
    {
        var file = _fileService.GetFile(id);
        if (file == null) return null;
        return file;
    }

    [HttpPost]
    public FileDto Files(IFormFile addFileDto)
    {
        var addedFile = _fileService.PostFile(addFileDto);
        return new FileDto()
        {
            Id = addedFile.Id,
            Path = addedFile.Path,
        };
    }
}
