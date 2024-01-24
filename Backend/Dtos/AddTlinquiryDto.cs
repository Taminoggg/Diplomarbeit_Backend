namespace ContainerToolDBDb;

public class AddTlinquiryDto
{
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int InquiryNumber { get; set; }
    [Required] public string Sped { get; set; } = null!;
    [RegularExpression(@"[ÄÜÖA-Z][äöüßa-z]{2,}", ErrorMessage = "Land in the format Xxxx allowed")]
    [Required] public string Country { get; set; } = null!;
    [Required] public string AcceptingPort { get; set; } = null!;
    [Required] public string ExpectedRetrieveWeek { get; set; } = null!;
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int WeightInKg { get; set; }
    [Required] public string InvoiceOn { get; set; } = null!;
    [Required] public string RetrieveDate { get; set; } = null!;
    [Required] public bool IsContainer40 { get; set; }
    [Required] public bool IsContainerHc { get; set; }
    [Required] public string RetrieveLocation { get; set; } = null!;
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int DebtCapitalGeneralForerunEur { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int DebtCapitalMainDol { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int DebtCapitalTrailingDol { get; set; }
    [Required] public string PortOfDeparture { get; set; } = null!;
    [RegularExpression(@"(0[1-9]|[12]\d|3[01])\.(0[1-9]|1[0-2])\.\d{4}", ErrorMessage = "Datestring in the format dd.MM.yyyy allowed")]
    [Required] public string Ets { get; set; } = null!;
    [RegularExpression(@"(0[1-9]|[12]\d|3[01])\.(0[1-9]|1[0-2])\.\d{4}", ErrorMessage = "Datestring in the format dd.MM.yyyy allowed")]
    [Required] public string Eta { get; set; } = null!;
    [Required] public string Boat { get; set; } = null!;
}
