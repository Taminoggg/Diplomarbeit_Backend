public class AddStepDto
{
    [Required] public int StepNumber { get; set; }
    [Required] public int ChecklistId { get; set; }
    [Required] public string StepDescription { get; set; } = null!;
    [Required] public string StepName { get; set; } = null!;
}