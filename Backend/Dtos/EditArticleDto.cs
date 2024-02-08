namespace Backend.Dtos;

public class EditArticleDto
{
    [Required] public int Id { get; set; }
    [Required] public int MinHeigthRequired { get; set; }
    [Required] public DateTime DesiredDeliveryDate { get; set; }
    [Required] public bool InquiryForFixedOrder { get; set; }
    [Required] public bool InquiryForQuotation { get; set; }
    [Required] public string? AdditionalInformation { get; set; }
}