namespace Backend.Dtos
{
    public class MessageConversationDto
    {
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int Id { get; set; }
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int MessageId { get; set; }
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int ConversationId { get; set; }
    }
}
