namespace Backend.Dtos
{
    public class AddMessageDto
    {
        [Required] public string Content { get; set; } = null!;

        [Required] public int AttachmentId { get; set; }

        [Required] public string DateTime { get; set; } = null!;
    }
}
