using Backend.Dtos;

namespace Backend.Services;

public class FileService
{
    private readonly ContainerToolDBContext _db;

    public FileService(ContainerToolDBContext db) => _db = db;

    public List<FileDto> GetAllFiles()
    {
        return _db.Files.Select(x => new FileDto().CopyFrom(x)).ToList();
    }

    public FileDto PostFile(AddFileDto addFileDto)
    {
        var file = new ContainerToolDBDb.File
        {
            Path = addFileDto.Path,
        };

        _db.Files.Add(file);
        _db.SaveChanges();

        return new FileDto().CopyFrom(file);
    }
}
