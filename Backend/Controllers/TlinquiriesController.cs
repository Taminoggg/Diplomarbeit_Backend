using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class TlinquiriesController : ControllerBase
{
    private readonly TlinquiryService _tlinquiryService;
    public TlinquiriesController(TlinquiryService tlinquiryService) => _tlinquiryService = tlinquiryService;

    [HttpGet]
    public List<TlinquiryDto> GetAllCsinquiries()
    {
        return _tlinquiryService.GetAllTlinquirys();
    }

    [HttpGet("GetTlinquiryWithId/{id}")]
    public TlinquiryDto GetTlinquiryWithId(int id)
    {
        return _tlinquiryService.GetTlinquiryWithId(id);
    }

    [HttpPost("AddNewTlinquiry")]
    public TlinquiryDto AddNewTlinquiry(AddTlinquiryDto addTlinquiryDto)
    {
        return _tlinquiryService.AddTlinquiry(addTlinquiryDto);
    }

    [HttpPut("EditTlinquiry")]
    public TlinquiryDto EditTlinquiry(EditTlInqueryDto editTlinquiry)
    {
        return _tlinquiryService.EditTlinquiry(editTlinquiry);
    }

    [HttpDelete("DeleteTlinquiry")]
    public TlinquiryDto DeleteTlinquiry(int id)
    {
        return _tlinquiryService.DeleteTlinquiry(id);
    }
}
