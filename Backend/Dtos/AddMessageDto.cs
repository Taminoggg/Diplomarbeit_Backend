namespace Backend.Dtos
{
    public class AddMessageDto
    {
        [Required] public string Content { get; set; } = null!;

        public int AttachmentId { get; set; }

    }
}
