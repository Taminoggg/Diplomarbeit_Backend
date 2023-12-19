using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class CsinquiriesController : ControllerBase
{
    private readonly CsinquiryService _csinquiryService;
    public CsinquiriesController(CsinquiryService csinquiryService) => _csinquiryService = csinquiryService;

    [HttpGet]
    public List<CsinquiryDto> AllCsinquiries()
    {
        return _csinquiryService.GetAllCsinquiries();
    }

    [HttpGet("{id}")]
    public CsinquiryDto CsinquiryWithId(int id)
    {
        return _csinquiryService.GetCsinquiryWithId(id);
    }

    [HttpPost]
    public CsinquiryDto Csinquiry(AddCsinquiryDto addCsinquiryDto)
    {
        return _csinquiryService.AddCsinquiry(addCsinquiryDto);
    }

    [HttpPut]
    public CsinquiryDto Csinquiry(EditCsinquiryDto editCsinquiry)
    {
        return _csinquiryService.EditCsinquiry(editCsinquiry);
    }

    [HttpDelete]
    public CsinquiryDto Csinquiry(int id)
    {
        return _csinquiryService.DeleteCsinquiry(id);
    }
}
