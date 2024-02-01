namespace ContainerToolDBDb;

public class AddTlinquiryDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int InquiryNumber { get; set; }
    [Required] public string Sped { get; set; } = null!;
    [RegularExpression(@"[ÄÜÖA-Z][äöüßa-z]{2,}", ErrorMessage = "Land in the format Xxxx allowed")]
    [Required] public string Country { get; set; } = null!;
    [Required] public string AcceptingPort { get; set; } = null!;
    [Required] public string ExpectedRetrieveWeek { get; set; } = null!;
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int WeightInKg { get; set; }
    [Required] public string InvoiceOn { get; set; } = null!;
    [Required] public string RetrieveDate { get; set; } = null!;
    [Required] public bool IsContainer40 { get; set; }
    [Required] public bool IsContainerHc { get; set; }
    [Required] public string RetrieveLocation { get; set; } = null!;
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int DebtCapitalGeneralForerunEur { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int DebtCapitalMainDol { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int DebtCapitalTrailingDol { get; set; }
    [Required] public string PortOfDeparture { get; set; } = null!;
    [RegularExpression(@"^(?<day>[0-2]\d|3[0-1])\.(?<month>0\d|1[0-2])\.(?<year>\d{4})$", ErrorMessage = "Only date in the format dd.MM.yyyy allowed!")]
    [Required] public string Ets { get; set; } = null!;
    [RegularExpression(@"^(?<day>[0-2]\d|3[0-1])\.(?<month>0\d|1[0-2])\.(?<year>\d{4})$", ErrorMessage = "Only date in the format dd.MM.yyyy allowed!")]
    [Required] public string Eta { get; set; } = null!;
    [Required] public string Boat { get; set; } = null!;
}
