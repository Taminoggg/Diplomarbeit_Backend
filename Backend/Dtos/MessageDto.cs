namespace Backend.Dtos;

public class MessageDto
{
    [Required] public int Id { get; set; }
    [Required] public string Content { get; set; } = null!;
    [Required] public int AttachmentId { get; set; }
    [Required] public string DateTime { get; set; } = null!;
    [Required] public string From { get; set; } = null!;
}
