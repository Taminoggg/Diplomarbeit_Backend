public class AddOrderDto
{
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int Status { get; set; }
    [Required] public string CustomerName { get; set; } = null!;
    [Required] public string CreatedBy { get; set; } = null!;
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int Amount { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int ChecklistId { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int Csid { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int Tlid { get; set; }
}
