using ContainerToolDBDb;
using System.ComponentModel.DataAnnotations;

namespace ContainerToolDB;

public class Article
{
    public int Id { get; set; }
    public int ArticleNumber { get; set; }
    public bool IsDirectLine { get; set; }
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
    public string? AdditionalInformation { get; set; }
    public bool IsFastLine { get; set; }
    public int Pallets { get; set; }
    public int CsinquiryId { get; set; }
    public string Plant { get; set; } = null!;
    public virtual Csinquiry Csinquiry { get; set; } = null!;
}
