namespace Backend.Dtos;

public class AddFileDto
{
    [Required] public string Path { get; set; } = null!;
}
