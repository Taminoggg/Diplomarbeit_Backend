namespace Backend.Dtos;

public class OrderDto
{
    [Required] public int Id { get; set; }
    [Required] public string Status { get; set; } = null!;
    [Required] public string CustomerName { get; set; } = null!;
    [Required] public string CreatedBySD { get; set; } = null!;
    [Required] public string CreatedByCS { get; set; } = null!;
    [Required] public bool Canceled { get; set; }
    [Required] public bool SuccessfullyFinished { get; set; }
    [Required] public string? AdditionalInformation { get; set; }
    [Required] public string LastUpdated { get; set; } = null!;
    [Required] public string CreatedOn { get; set; } = null!;
    [Required] public string FinishedOn { get; set; } = null!;
    [Required] public int ChecklistId { get; set; }
    [Required] public int Csid { get; set; }
    [Required] public int Tlid { get; set; }
    [Required] public int PpId { get; set; }
}