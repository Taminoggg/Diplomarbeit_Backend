using ContainerToolDBDb;

namespace ContainerToolDB;

public class ArticleCR
{
    public int Id { get; set; }
    public int ArticleNumber { get; set; }
    public int Pallets { get; set; }
    public int CsinquiryId { get; set; }
    public virtual Csinquiry Csinquiry { get; set; } = null!;
}
