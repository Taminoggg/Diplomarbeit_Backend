public class EditStepDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    public int Id { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    public int StepNumber { get; set; }
    public string StepDescription { get; set; } = null!;
    public string StepName { get; set; } = null!;
    public bool Checked { get; set; }
}