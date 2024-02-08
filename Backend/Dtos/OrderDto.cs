public class OrderDto
{
    [Required] public int Id { get; set; }
    [Required] public string Status { get; set; } = null!;
    [Required] public string CustomerName { get; set; } = null!;
    [Required] public string CreatedBy { get; set; } = null!;
    [Required] public bool ApprovedByCs { get; set; }
    [Required] public bool ApprovedByTl { get; set; }
    [Required] public int Amount { get; set; }
    [Required] public string? AdditionalInformation { get; set; }
    [Required] public string LastUpdated { get; set; } = null!;
    [Required] public int ChecklistId { get; set; }
    [Required] public string Sped { get; set; } = null!;
    [Required] public string Country { get; set; } = null!;
    [Required] public string ReadyToLoad { get; set; } = null!;
    [Required] public int AbNumber { get; set; }
    [Required] public int Csid { get; set; }
    [Required] public int Tlid { get; set; }
}
