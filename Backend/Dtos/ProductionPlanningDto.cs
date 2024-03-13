namespace Backend.Dtos;

public class ProductionPlanningDto
{
    [Required] public int Id { get; set; }
    [Required] public bool ApprovedByPpCs { get; set; }
    [Required] public bool ApprovedByPpPp { get; set; }
    [Required] public string ApprovedByPpCsTime { get; set; } = null!;
    [Required] public string ApprovedByPpPpTime { get; set; } = null!;
    [Required] public string RecievingCountry { get; set; } = null!;
    [Required] public char CustomerPriority { get; set; }
}
