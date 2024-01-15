namespace Backend.Dtos
{
    public class AddMessageConversationDto
    {
        [Required] public int ConversationId { get; set; }
        [Required] public int MessageId { get; set; }
    }
}
