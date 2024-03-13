namespace Backend.Dtos;

public class AddProductionPlanningDto
{
    [Required] public string RecievingCountry { get; set; } = null!;
    [Required] public char CustomerPriority { get; set; }
}
