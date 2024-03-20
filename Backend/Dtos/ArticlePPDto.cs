namespace Backend.Dtos;

public class ArticlePPDto
{
    [Required] public int Id { get; set; }
    [Required] public int ArticleNumber { get; set; }
    [Required] public int Pallets { get; set; }
    [Required] public int ProductionPlanningId { get; set; }
    [Required] public int? MinHeigthRequired { get; set; }
    [Required] public int DesiredDeliveryDate { get; set; } 
    [Required] public bool InquiryForFixedOrder { get; set; }
    [Required] public bool InquiryForNonFixedOrder { get; set; }
    [Required] public bool InquiryForQuotation { get; set; }
    [Required] public int DeliveryDate { get; set; } 
    [Required] public string ShortText { get; set; } = null!;
    [Required] public string Factory { get; set; } = null!;
    [Required] public string Nozzle { get; set; } = null!;
    [Required] public string ProductionOrder { get; set; } = null!;
    [Required] public string PlannedOrder { get; set; } = null!;
    [Required] public string Plant { get; set; } = null!;
}
