using Backend.Dtos;
using Backend.Services;
using ContainerToolDB;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class ArticlesCRController : ControllerBase
{
    private readonly ArticleCRService _articleService;
    public ArticlesCRController(ArticleCRService articleService) => _articleService = articleService;

    [HttpGet]
    public List<ArticleCRDto> AllArticles()
    {
        return _articleService.GetArticles()
            .Select(x => ToArticleDto(x))
            .ToList(); ;
    }
    
    [HttpGet("CsInquiry/{id}")]
    public List<ArticleCRDto> Articles(int id)
    {
        return _articleService.ArticlesForCsInquiryId(id)
            .Select(x => ToArticleDto(x))
            .ToList(); ;
    }
    
    [HttpDelete("CsId")]
    public List<ArticleCRDto> ArticlesForCsId(int id)
    {
        return _articleService.RemoveArticlesForCsId(id).Select(x => ToArticleDto(x)).ToList();
    }
    
    [HttpDelete]
    public ArticleCRDto? Article(int id)
    {
        var article = _articleService.RemoveArticle(id);
        if (article == null) return null;
        return ToArticleDto(article);
    }
    
    [HttpPost]
    public ArticleCRDto? Article(AddArticleCRDto addArticleDto)
    {
        var article = _articleService.PostArticle(addArticleDto);
        if (article == null) return null;
        return ToArticleDto(article);
    }
    
    private static ArticleCRDto ToArticleDto(ArticleCR article)
    {
        return new ArticleCRDto
        {
            Id = article.Id,
            ArticleNumber = article.ArticleNumber,
            CsinquiryId = article.CsinquiryId,
            Pallets = article.Pallets
        };
    }
}
