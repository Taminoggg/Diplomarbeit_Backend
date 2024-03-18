namespace Backend.Dtos;

public class EditPpCrArticleDto
{
    [Required] public int Id { get; set; }
    [Required] public int MinHeigthRequired { get; set; }
    [Required] public string DesiredDeliveryDate { get; set; } = null!;
    [Required] public bool InquiryForFixedOrder { get; set; }
    [Required] public bool InquiryForNonFixedOrder { get; set; }
    [Required] public bool InquiryForQuotation { get; set; }
    [Required] public int ArticleNumber { get; set; }
}