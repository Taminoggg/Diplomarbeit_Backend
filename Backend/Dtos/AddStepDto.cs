public class AddStepDto
{
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int StepNumber { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int ChecklistId { get; set; }
    [Required] public string StepDescription { get; set; } = null!;
    [Required] public string StepName { get; set; } = null!;
}