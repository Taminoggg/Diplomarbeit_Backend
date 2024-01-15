namespace Backend.Dtos
{
    public class MessageConversationDto
    {
        [Required] public int Id { get; set; }
        [Required] public int MessageId { get; set; }
        [Required] public int ConversationId { get; set; }
    }
}
