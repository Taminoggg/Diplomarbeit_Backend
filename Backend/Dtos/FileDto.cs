namespace Backend.Dtos
{
    public class FileDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Path { get; set; } = null!;
    }
}
