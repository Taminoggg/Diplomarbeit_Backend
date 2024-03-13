namespace Backend.Dtos;

public class EditOrderSDDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Id { get; set; }
    public string? AdditionalInformation { get; set; }
    [Required] public string CreatedBy { get; set; } = null!;
}
