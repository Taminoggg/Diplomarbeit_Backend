namespace Backend.Dtos
{
    public class AddMessageDto
    {
        [Required] public string Content { get; set; } = null!;
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        public int AttachmentId { get; set; }

    }
}
