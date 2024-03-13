namespace Backend.Dtos;

public class EditProductionPlanningDto
{
    [Required] public int Id { get; set; }
    [Required] public string RecievingCountry { get; set; } = null!;
    [Required] public char CustomerPriority { get; set; }
}
