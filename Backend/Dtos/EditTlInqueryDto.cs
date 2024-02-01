namespace ContainerToolDBDb;

public class EditTlInqueryDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Id { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int InquiryNumber { get; set; }
    [Required] public string Sped { get; set; } = null!;
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
    [Required] public string Ets { get; set; } = null!;
    [Required] public string Eta { get; set; } = null!;
    [Required] public string Boat { get; set; } = null!;
}
