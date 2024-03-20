namespace ContainerToolDBDb;

public class TlinquiryDto
{
    [Required] public int Id { get; set; }
    [Required] public string Sped { get; set; } = null!;
    [Required] public string AcceptingPort { get; set; } = null!;
    [Required] public string InvoiceOn { get; set; } = null!;
    [Required] public string RetrieveDate { get; set; } = null!;
    [Required] public string RetrieveLocation { get; set; } = null!;
    [Required] public double SCGeneral { get; set; }
    [Required] public double SCMain { get; set; }
    [Required] public double SCTrail { get; set; }
    [Required] public string PortOfDeparture { get; set; } = null!;
    [Required] public string Ets { get; set; } = null!;
    [Required] public string Eta { get; set; } = null!;
    [Required] public string Boat { get; set; } = null!;
    [Required] public bool ApprovedByCrTl { get; set; }
    [Required] public string ApprovedByCrTlTime { get; set; } = null!;
}
