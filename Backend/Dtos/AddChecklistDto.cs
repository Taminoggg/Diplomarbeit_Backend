namespace ContainerToolDBDb;

public class AddChecklistDto
{
    [Required] public string CustomerName { get; set; } = null!;
    [Required] public int OrderId { get; set; }
    [Required] public List<int> StepIds { get; set; } = null!;
}