namespace Backend.Dtos;

public class AddOrderDto
{
    [Required] public string CustomerName { get; set; } = null!;
    public string? AdditionalInformation { get; set; }
    [Required] public string CreatedBy { get; set; } = null!;
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    public int? ChecklistId { get; set; }
    public int? CsId { get; set; }
    public int? TlId { get; set; }
    public int? PpId { get; set; }
}