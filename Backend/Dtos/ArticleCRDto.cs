namespace Backend.Dtos;

public class ArticleCRDto
{
    [Required] public int Id { get; set; }
    [Required] public int ArticleNumber { get; set; }
    [Required] public int Pallets { get; set; }
    [Required] public int CsinquiryId { get; set; }
}
