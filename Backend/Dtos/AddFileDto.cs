namespace Backend.Dtos;

public class AddFileDto
{
    [Required] public IFormFile File { get; set; } = null!;
}
