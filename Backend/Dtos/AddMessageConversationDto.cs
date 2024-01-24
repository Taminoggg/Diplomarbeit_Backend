namespace Backend.Dtos
{
    public class AddMessageConversationDto
    {
        [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
        [Required] public int ConversationId { get; set; }
        [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
        [Required] public int MessageId { get; set; }
    }
}
