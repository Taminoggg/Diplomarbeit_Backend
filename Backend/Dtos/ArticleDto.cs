namespace Backend.Dtos;

public class ArticleDto
{
    [Required] public int Id { get; set; }
    [Required] public int ArticleNumber { get; set; }
    [Required] public bool IsDirectLine { get; set; }
    [Required] public bool IsFastLine { get; set; }
    [Required] public int Pallets { get; set; }
    [Required] public int CsinquiryId { get; set; }
}
