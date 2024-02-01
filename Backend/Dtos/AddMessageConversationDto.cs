namespace Backend.Dtos
{
    public class AddMessageConversationDto
    {
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int OrderId { get; set; }
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int MessageId { get; set; }
    }
}
