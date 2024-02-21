namespace Backend.Dtos
{
    public class EditStepDto
    {
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int Id { get; set; }
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int StepNumber { get; set; }
        [Required] public string StepDescription { get; set; } = null!;
        [Required] public string StepName { get; set; } = null!;
    }
}