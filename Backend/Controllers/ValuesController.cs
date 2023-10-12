namespace Backend.Controllers;

public record struct OkStatus(bool IsOk, int Nr, string? Error = null);

[Route("[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{	
  private readonly ContainerToolDBContext _db;
  public ValuesController(ContainerToolDBContext db) => _db = db;
  
  [HttpGet("Categories")]
  public OkStatus GetCategories()
  {
    this.Log();
    try
    {
  	  int nr = _db.Categories.Count();
  	  return new OkStatus(true, nr);
    }
    catch (Exception exc)
    {
  	  return new OkStatus(false, -1, exc.Message);
    }
  }
}
