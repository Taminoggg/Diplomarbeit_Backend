namespace Backend.Dtos;

public class AddArticlePPDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int ArticleNumber { get; set; } 
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Pallets { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int ProductionPlanningId { get; set; }
    [Required] public int MinHeigthRequired { get; set; }
    [Required] public int DesiredDeliveryDate { get; set; }
    [Required] public bool InquiryForFixedOrder { get; set; }
    [Required] public bool InquiryForNonFixedOrder { get; set; }
    [Required] public bool InquiryForQuotation { get; set; }
}
