namespace ContainerToolDBDb;

public class EditTlInqueryDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Id { get; set; }
    [Required] public string Sped { get; set; } = null!;
    [Required] public string AcceptingPort { get; set; } = null!;
    [Required] public string InvoiceOn { get; set; } = null!;
    [Required] public string RetrieveDate { get; set; } = null!;
    [Required] public string RetrieveLocation { get; set; } = null!;
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int SCGeneral { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int SCMain { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int SCTrail { get; set; }
    [Required] public string PortOfDeparture { get; set; } = null!;
    [Required] public string Ets { get; set; } = null!;
    [Required] public string Eta { get; set; } = null!;
    [Required] public string Boat { get; set; } = null!;
}
