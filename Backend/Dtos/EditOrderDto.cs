public class EditOrderDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Id { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Status { get; set; }
    [Required] public string CustomerName { get; set; } = null!;
    [Required] public string CreatedBy { get; set; } = null!;
    [Required] public bool Approved { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Amount { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int ChecklistId { get; set; }
}
