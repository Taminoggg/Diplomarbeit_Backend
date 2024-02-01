using ContainerToolDBDb;
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
        return _tlinquiryService.GetAllTlinquirys().Select(x => ToTlinquiryDto(x)).ToList();
    }

    [HttpGet("{id}")]
    public TlinquiryDto TlinquiryWithId(int id)
    {
        return ToTlinquiryDto(_tlinquiryService.GetTlinquiryWithId(id));
    }

    [HttpPost]
    public TlinquiryDto Tlinquiry(AddTlinquiryDto addTlinquiryDto)
    {
        return ToTlinquiryDto(_tlinquiryService.AddTlinquiry(addTlinquiryDto));
    }

    [HttpPut]
    public TlinquiryDto Tlinquiry(EditTlInqueryDto editTlinquiry)
    {
        return ToTlinquiryDto(_tlinquiryService.EditTlinquiry(editTlinquiry));
    }

    [HttpDelete]
    public TlinquiryDto Tlinquiry(int id)
    {
        return ToTlinquiryDto(_tlinquiryService.DeleteTlinquiry(id));
    }

    private static TlinquiryDto ToTlinquiryDto(Tlinquiry tlinquiry)
    {
        return new TlinquiryDto
        {
            DebtCapitalGeneralForerunEur = tlinquiry.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = tlinquiry.DebtCapitalMainDol,
            DebtCapitalTrailingDol = tlinquiry.DebtCapitalTrailingDol,
            PortOfDeparture = tlinquiry.PortOfDeparture,
            RetrieveDate = tlinquiry.RetrieveDate.ToString("dd.MM.yyyy"),
            AcceptingPort = tlinquiry.AcceptingPort,
            Boat = tlinquiry.Boat,
            Country = tlinquiry.Country,
            Eta = tlinquiry.Eta.ToString("dd.MM.yyyy"),
            Ets = tlinquiry.Ets.ToString("dd.MM.yyyy"),
            ExpectedRetrieveWeek = tlinquiry.ExpectedRetrieveWeek.ToString("dd.MM.yyyy"),
            InquiryNumber = tlinquiry.InquiryNumber,
            InvoiceOn = tlinquiry.InvoiceOn.ToString("dd.MM.yyyy"),
            Id = tlinquiry.Id,
            IsContainer40 = tlinquiry.IsContainer40,
            IsContainerHc = tlinquiry.IsContainerHc,
            RetrieveLocation = tlinquiry.RetrieveLocation,
            Sped = tlinquiry.Sped,
            WeightInKg = tlinquiry.WeightInKg
        };
    }
}
