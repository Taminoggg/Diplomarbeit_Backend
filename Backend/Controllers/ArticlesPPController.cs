using Backend.Dtos;
using Backend.Services;
using ContainerToolDB;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class ArticlesPPController : ControllerBase
{
    private readonly ArticlePPService _articleService;
    public ArticlesPPController(ArticlePPService articleService) => _articleService = articleService;

    [HttpGet]
    public List<ArticlePPDto> AllArticles()
    {
        return _articleService.GetArticles()
            .Select(x => ToArticleDto(x))
            .ToList(); ;
    }
    
    [HttpGet("ProductionPlanning/{id}")]
    public List<ArticlePPDto> Articles(int id)
    {
        return _articleService.ArticlesForProductionPlanningId(id)
            .Select(x => ToArticleDto(x))
            .ToList(); ;
    }
    
    [HttpDelete]
    public ArticlePPDto? Article(int id)
    {
        var article = _articleService.RemoveArticle(id);
        if (article == null) return null;
        return ToArticleDto(article);
    }

    [HttpDelete("ProductionPlanningId")]
    public List<ArticlePPDto> ArticlesForCsId(int id)
    {
        return _articleService.RemoveArticlesForProductionPlanningId(id).Select(x => ToArticleDto(x)).ToList();
    }

    [HttpPut]
    public ArticlePPDto? EditPpPpArticle(EditPpPpArticleDto addArticleDto)
    {
        var article = _articleService.EditPPArticle(addArticleDto);
        if (article == null) return null;
        return ToArticleDto(article);
    }

    [HttpPost]
    public ArticlePPDto? Article(AddArticlePPDto addArticleDto)
    {
        var article = _articleService.PostArticle(addArticleDto);
        if (article == null) return null;
        return ToArticleDto(article);
    }
    
    private static ArticlePPDto ToArticleDto(ArticlePP article)
    {
        return new ArticlePPDto
        {
            Id = article.Id,
            DesiredDeliveryDate = article.DesiredDeliveryDate,
            ArticleNumber = article.ArticleNumber,
            InquiryForFixedOrder = article.InquiryForFixedOrder,
            InquiryForNonFixedOrder = article.InquiryForNonFixedOrder,
            InquiryForQuotation = article.InquiryForQuotation,
            MinHeigthRequired = article.MinHeigthRequired,
            Pallets = article.Pallets,
            DeliveryDate = article.DeliveryDate,
            Factory = article.Factory ?? "",
            Nozzle = article.Nozzle ?? "",
            PlannedOrder = article.PlannedOrder ?? "",
            ProductionOrder = article.ProductionOrder ?? "",
            ShortText = article.ShortText ?? "",
            Plant = article.Plant ?? "",
            ProductionPlanningId = article.ProductionPlanningId
        };
    }
}
