using Backend.Dtos;
using Backend.Services;
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
            .Select(x => new ArticleDto().CopyFrom(x))
            .ToList(); ;
    }

    [HttpGet("CsInquiry/{id}")]
    public List<ArticleDto> Articles(int id)
    {
        return _articleService.ArticlesForCsInquiryId(id)
            .Select(x => new ArticleDto().CopyFrom(x))
            .ToList(); ;
    }

    [HttpPut]
    public ArticleDto Article(ArticleDto articleDto)
    {
        var article = _articleService.PutArticle(articleDto);
        return new ArticleDto().CopyFrom(article);
    }

    [HttpDelete("CsId")]
    public List<ArticleDto> ArticlesForCsId(int id)
    {
        return _articleService.RemoveArticlesForCsId(id).Select(x => new ArticleDto().CopyFrom(x)).ToList();
    }

    [HttpDelete]
    public ArticleDto Article(int id)
    {
        var article = _articleService.RemoveArticle(id);
        return new ArticleDto().CopyFrom(article);
    }

    [HttpPost]
    public ArticleDto Article(AddArticleDto addArticleDto)
    {
        var article = _articleService.PostArticle(addArticleDto);
        return new ArticleDto().CopyFrom(article);
    }
}
