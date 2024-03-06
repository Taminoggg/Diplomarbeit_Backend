using ContainerToolDB;

public partial class ArticlePP
{
    public int Id { get; set; }
    public int ArticleNumber { get; set; }
    public int MinHeigthRequired { get; set; }
    public DateTime? DesiredDeliveryDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public string ShortText { get; set; } = null!;
    public string Factory { get; set; } = null!;
    public string Nozzle { get; set; } = null!;
    public string ProductionOrder { get; set; } = null!;
    public string PlannedOrder { get; set; } = null!;
    public bool InquiryForFixedOrder { get; set; }
    public bool InquiryForQuotation { get; set; }
    public int Pallets { get; set; }
    public int ProductionPlanningId { get; set; }
    public string Plant { get; set; } = null!;
    public virtual ProductionPlanning ProductionPlanning { get; set; } = null!;
}
