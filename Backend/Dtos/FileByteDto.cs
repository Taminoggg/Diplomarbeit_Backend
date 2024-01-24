namespace Backend.Dtos;

public class FileByteDto
{
    [Required] public string FileName { get; set; } = null!;
    [Required] public byte[] FileContent { get; set; } = null!;
    [Required] public string FileType { get; set; } = null!;
}

