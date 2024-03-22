using Backend.Dtos;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Web;

namespace Backend.Services;

public class FileService
{
    private readonly ContainerToolDBContext _db;

    public FileService(ContainerToolDBContext db) => _db = db;
    private string baseFilePath = "C:\\Users\\gutja\\Tamino\\Diplomarbeit\\";

    public List<ContainerToolDBDb.File> GetAllFiles()
    {
        return _db.Files.ToList();
    }

    public FileByteDto? GetFile(int id)
    {
        try
        {
            var file = _db.Files.Single(x => x.Id == id);

            byte[] fileBytes = System.IO.File.ReadAllBytes(file.Path);

            return new FileByteDto
            {
                FileName = Path.GetFileName(file.Path),
                FileContent = fileBytes,
                FileType = Path.GetExtension(file.Path)
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public ContainerToolDBDb.File PostFile([FromForm] IFormFile file)
    {
        var filePath = Path.Combine(baseFilePath, file.FileName);

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

        return addedFile;
    }
}
