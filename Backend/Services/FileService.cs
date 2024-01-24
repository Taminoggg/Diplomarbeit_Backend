using Backend.Dtos;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Web;

namespace Backend.Services;

public class FileService
{
    private readonly ContainerToolDBContext _db;

    public FileService(ContainerToolDBContext db) => _db = db;

    public List<FileDto> GetAllFiles()
    {
        return _db.Files.Select(x => new FileDto().CopyFrom(x)).ToList();
    }

    public FileByteDto GetFile(int id)
    {
        var file = _db.Files.Single(x => x.Id == id);

        byte[] fileBytes = System.IO.File.ReadAllBytes(file.Path);

        Console.WriteLine("------------------------------" + Path.GetExtension(file.Path));

        return new FileByteDto
        {
            FileName = Path.GetFileName(file.Path),
            FileContent = fileBytes,
            FileType = Path.GetExtension(file.Path)
        };
    }

    public FileDto PostFile([FromForm] IFormFile file)
    {
        var filePath = Path.Combine("C:\\Users\\gutja\\Tamino\\Diplomarbeit\\", file.FileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        var addedFile = new ContainerToolDBDb.File
        {
            Path = filePath,
        };

        _db.Files.Add(addedFile);
        _db.SaveChanges();

        return new FileDto() 
        {
            Id = addedFile.Id,
            Path = addedFile.Path,
        };
    }

}
