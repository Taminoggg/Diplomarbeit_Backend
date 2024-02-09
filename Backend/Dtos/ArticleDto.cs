namespace Backend.Dtos;

public class ArticleDto
{
    [Required] public int Id { get; set; }
    [Required] public int ArticleNumber { get; set; }
    [Required] public bool IsDirectLine { get; set; }
    [Required] public bool IsFastLine { get; set; }
    [Required] public int Pallets { get; set; }
    [Required] public int CsinquiryId { get; set; }
    public int? MinHeigthRequired { get; set; }
    public string? DesiredDeliveryDate { get; set; }
    public bool? InquiryForFixedOrder { get; set; }
    public bool? InquiryForQuotation { get; set; }
}
