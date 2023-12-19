public class EditOrderDto
{
    [Required] public int Id { get; set; }
    [Required] public int Status { get; set; }
    [Required] public string CustomerName { get; set; } = null!;
    [Required] public string CreatedBy { get; set; } = null!;
    [Required] public bool Approved { get; set; }
    [Required] public int Amount { get; set; }
    [Required] public int ChecklistId { get; set; }
}
