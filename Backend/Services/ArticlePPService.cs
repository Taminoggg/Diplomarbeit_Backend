using Backend.Dtos;
using ContainerToolDB;
using System.Globalization;

namespace Backend.Services;

public class ArticlePPService
{
    private readonly ContainerToolDBContext _db;

    public ArticlePPService(ContainerToolDBContext db) => _db = db;

    public List<ArticlePP> GetArticles()
    {
        return _db.ArticlesPP
            .ToList();
    }

    public List<ArticlePP> ArticlesForProductionPlanningId(int id)
    {
        return _db.ArticlesPP.Where(x => x.ProductionPlanningId == id).ToList();
    }

    public List<ArticlePP> RemoveArticlesForProductionPlanningId(int id)
    {
        try
        {
            List<ArticlePP> removedArticles = new();
            foreach (ArticlePP currArticle in _db.ArticlesPP.Where(x => x.ProductionPlanningId == id).ToList())
            {
                removedArticles.Add(currArticle);
                _db.ArticlesPP.Remove(currArticle);
            }
            _db.SaveChanges();
            return removedArticles;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<ArticlePP>();
        }

    }

    public ArticlePP? RemoveArticle(int id)
    {
        try
        {
            var article = _db.ArticlesPP.Include(x => x.ProductionPlanning).Single(x => x.Id == id);
            _db.ArticlesPP.Remove(article);
            _db.SaveChanges();
            return article;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public ArticlePP? EditPpCrArticle(EditPpCrArticleDto editArticleDto)
    {
        try
        {
            var article = _db.ArticlesPP.Single(x => x.Id == editArticleDto.Id);

            article.MinHeigthRequired = editArticleDto.MinHeigthRequired;
            article.DesiredDeliveryDate = DateTime.ParseExact(editArticleDto.DesiredDeliveryDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            article.InquiryForFixedOrder = editArticleDto.InquiryForFixedOrder;
            article.InquiryForQuotation = editArticleDto.InquiryForQuotation;
            article.ArticleNumber = editArticleDto.ArticleNumber;

            _db.SaveChanges();
            return article;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

    }

    public ArticlePP? EditPPArticle(EditPpPpArticleDto editPPArticleDto)
    {
        try
        {
            var article = _db.ArticlesPP.Single(x => x.Id == editPPArticleDto.Id);

            article.DeliveryDate = DateTime.ParseExact(editPPArticleDto.DeliveryDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            article.Factory = editPPArticleDto.Factory;
            article.ShortText = editPPArticleDto.ShortText;
            article.Nozzle = editPPArticleDto.Nozzle;
            article.PlannedOrder = editPPArticleDto.PlannedOrder;
            article.ProductionOrder = editPPArticleDto.ProductionOrder;
            article.Plant = editPPArticleDto.Plant;

            _db.SaveChanges();
            return article;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public ArticlePP? PostArticle(AddArticlePPDto articleDto)
    {
        try
        {
            var productionPlanning = _db.ProductionPlannings.Single(x => x.Id == articleDto.ProductionPlanningId);

            var article = new ArticlePP
            {
                ArticleNumber = articleDto.ArticleNumber,
                ProductionPlanningId = articleDto.ProductionPlanningId,
                Pallets = articleDto.Pallets,
                DeliveryDate = null,
                DesiredDeliveryDate = null,
                Factory = "",
                InquiryForFixedOrder = false,
                InquiryForQuotation = false,
                MinHeigthRequired = 0,
                Nozzle = "",
                PlannedOrder = "",
                ProductionOrder = "",
                ShortText = "",
                Plant = "",
                ProductionPlanning = productionPlanning
            };

            _db.ArticlesPP.Add(article);
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
