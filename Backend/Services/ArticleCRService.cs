using Backend.Dtos;
using ContainerToolDB;

namespace Backend.Services;

public class ArticleCRService
{
    private readonly ContainerToolDBContext _db;

    public ArticleCRService(ContainerToolDBContext db) => _db = db;

    public List<ArticleCR> GetArticles()
    {
        return _db.ArticlesCR
            .ToList();
    }

    public List<ArticleCR> ArticlesForCsInquiryId(int id)
    {
        return _db.ArticlesCR.Where(x => x.CsinquiryId == id).ToList();
    }

    public List<ArticleCR> RemoveArticlesForCsId(int id)
    {
        List<ArticleCR> removedArticles = new();
        foreach (ArticleCR currArticle in _db.ArticlesCR.Where(x => x.CsinquiryId == id).ToList())
        {
            removedArticles.Add(currArticle);
            _db.ArticlesCR.Remove(currArticle);
        }
        _db.SaveChanges();
        return removedArticles;
    }

    public ArticleCR? RemoveArticle(int id)
    {
        try
        {
            var article = _db.ArticlesCR.Include(x => x.Csinquiry).Single(x => x.Id == id);
            _db.ArticlesCR.Remove(article);
            _db.SaveChanges();
            return article;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public ArticleCR? PostArticle(AddArticleCRDto articleDto)
    {
        try
        {
            var csinquiry = _db.Csinquiries.Single(x => x.Id == articleDto.CsInquiryId);

            var article = new ArticleCR
            {
                ArticleNumber = articleDto.ArticleNumber,
                Pallets = articleDto.Pallets,
                Csinquiry = csinquiry,
                CsinquiryId = articleDto.CsInquiryId
            };

            _db.ArticlesCR.Add(article);
            _db.SaveChanges();

            return article;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
