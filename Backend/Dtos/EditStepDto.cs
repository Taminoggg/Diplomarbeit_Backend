public class EditStepDto
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string StepDescription { get; set; } = null!;
    public string StepName { get; set; } = null!;
    public bool Checked { get; set; }
}