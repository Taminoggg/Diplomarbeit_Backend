namespace Backend.Dtos
{
    public class AddMessageDto
    {
        public string? Content { get; set; }
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        public int? AttachmentId { get; set; }
    }
}
