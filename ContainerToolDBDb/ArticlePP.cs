namespace ContainerToolDB;

public partial class ArticlePP
{
    public int Id { get; set; }
    public int ArticleNumber { get; set; }
    public int MinHeigthRequired { get; set; }
    public int DesiredDeliveryDate { get; set; }
    public int DeliveryDate { get; set; }
    public string? ShortText { get; set; }
    public string? Factory { get; set; }
    public string? Nozzle { get; set; }
    public string? ProductionOrder { get; set; }
    public string? PlannedOrder { get; set; } = null!;
    public string? Plant { get; set; }
    public bool InquiryForFixedOrder { get; set; }
    public bool InquiryForNonFixedOrder { get; set; }
    public bool InquiryForQuotation { get; set; }
    public int Pallets { get; set; }
    public int ProductionPlanningId { get; set; }
    public virtual ProductionPlanning ProductionPlanning { get; set; } = null!;
}