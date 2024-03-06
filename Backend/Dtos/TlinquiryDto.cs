namespace ContainerToolDBDb;

public class TlinquiryDto
{
    [Required] public int Id { get; set; }
    [Required] public int InquiryNumber { get; set; }
    [Required] public string Sped { get; set; } = null!;
    [Required] public string Country { get; set; } = null!;
    [Required] public string AcceptingPort { get; set; } = null!;
    [Required] public string ExpectedRetrieveWeek { get; set; } = null!;
    [Required] public int WeightInKg { get; set; }
    [Required] public string InvoiceOn { get; set; } = null!;
    [Required] public string RetrieveDate { get; set; } = null!;
    [Required] public bool IsContainer40 { get; set; }
    [Required] public bool IsContainerHc { get; set; }
    [Required] public string RetrieveLocation { get; set; } = null!;
    [Required] public int DebtCapitalGeneralForerunEur { get; set; }
    [Required] public int DebtCapitalMainDol { get; set; }
    [Required] public int DebtCapitalTrailingDol { get; set; }
    [Required] public string PortOfDeparture { get; set; } = null!;
    [Required] public string Ets { get; set; } = null!;
    [Required] public string Eta { get; set; } = null!;
    [Required] public string Boat { get; set; } = null!;
    [Required] public bool ApprovedByCrTl { get; set; }
    [Required] public string ApprovedByCrTlTime { get; set; } = null!;
}
