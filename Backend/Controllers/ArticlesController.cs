using Backend.Dtos;
using Backend.Services;
using ContainerToolDB;
using ContainerToolDBDb;
using TippsBackend.Services;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class ArticlesController
{
    private readonly ArticleService _articleService;
    public ArticlesController(ArticleService articleService) => _articleService = articleService;

    [HttpGet]
    public List<ArticleDto> AllArticles()
    {
        return _articleService.GetArticles()
            .Select(x => ToArticleDto(x))
            .ToList(); ;
    }

    [HttpGet("CsInquiry/{id}")]
    public List<ArticleDto> Articles(int id)
    {
        return _articleService.ArticlesForCsInquiryId(id)
            .Select(x => ToArticleDto(x))
            .ToList(); ;
    }

    [HttpPut]
    public ArticleDto Article(EditArticleDto editArticleDto)
    {
        return ToArticleDto(_articleService.EditArticle(editArticleDto));
    }

    [HttpDelete("CsId")]
    public List<ArticleDto> ArticlesForCsId(int id)
    {
        return _articleService.RemoveArticlesForCsId(id).Select(x => ToArticleDto(x)).ToList();
    }

    [HttpDelete]
    public ArticleDto Article(int id)
    {
        return ToArticleDto(_articleService.RemoveArticle(id));
    }

    [HttpPost]
    public ArticleDto Article(AddArticleDto addArticleDto)
    {
        return ToArticleDto(_articleService.PostArticle(addArticleDto));
    }

    private static ArticleDto ToArticleDto(Article article)
    {
        return new ArticleDto
        {
            Id = article.Id,
            DesiredDeliveryDate = article.DesiredDeliveryDate != null ? article.DesiredDeliveryDate.Value.ToString("dd.MM.yyyy") : null,
            IsDirectLine = article.IsDirectLine,
            ArticleNumber = article.ArticleNumber,
            CsinquiryId = article.CsinquiryId,
            InquiryForFixedOrder = article.InquiryForFixedOrder,
            InquiryForQuotation = article.InquiryForQuotation,
            IsFastLine = article.IsFastLine,
            MinHeigthRequired = article.MinHeigthRequired,
            Pallets = article.Pallets
        };
    }
}
