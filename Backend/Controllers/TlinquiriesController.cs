using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class TlinquiriesController : ControllerBase
{
    private readonly TlinquiryService _tlinquiryService;
    public TlinquiriesController(TlinquiryService tlinquiryService) => _tlinquiryService = tlinquiryService;

    [HttpGet]
    public List<TlinquiryDto> AllCsinquiries()
    {
        return _tlinquiryService.GetAllTlinquirys();
    }

    [HttpGet("{id}")]
    public TlinquiryDto TlinquiryWithId(int id)
    {
        return _tlinquiryService.GetTlinquiryWithId(id);
    }

    [HttpPost]
    public TlinquiryDto Tlinquiry(AddTlinquiryDto addTlinquiryDto)
    {
        return _tlinquiryService.AddTlinquiry(addTlinquiryDto);
    }

    [HttpPut]
    public TlinquiryDto Tlinquiry(EditTlInqueryDto editTlinquiry)
    {
        return _tlinquiryService.EditTlinquiry(editTlinquiry);
    }

    [HttpDelete]
    public TlinquiryDto Tlinquiry(int id)
    {
        return _tlinquiryService.DeleteTlinquiry(id);
    }
}
