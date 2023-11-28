public class StepDto
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public int ChecklistId { get; set; }
    public string StepDescription { get; set; } = null!;
    public string StepName { get; set; } = null!;
}