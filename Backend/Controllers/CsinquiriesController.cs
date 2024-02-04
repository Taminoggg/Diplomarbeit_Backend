using ContainerToolDBDb;
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
        return _csinquiryService.GetAllCsinquiries().Select(x => ToCsinquiryDto(x)).ToList();
    }

    [HttpGet("{id}")]
    public CsinquiryDto CsinquiryWithId(int id)
    {
        return ToCsinquiryDto(_csinquiryService.GetCsinquiryWithId(id));
    }

    [HttpPost]
    public CsinquiryDto Csinquiry(AddCsinquiryDto addCsinquiryDto)
    {
        return ToCsinquiryDto(_csinquiryService.AddCsinquiry(addCsinquiryDto));
    }

    [HttpPut]
    public CsinquiryDto Csinquiry(EditCsinquiryDto editCsinquiry)
    {
        return ToCsinquiryDto(_csinquiryService.EditCsinquiry(editCsinquiry));
    }

    [HttpDelete]
    public CsinquiryDto Csinquiry(int id)
    {
        return ToCsinquiryDto(_csinquiryService.DeleteCsinquiry(id));
    }

    private static CsinquiryDto ToCsinquiryDto(Csinquiry csinquiry)
    {
        return new CsinquiryDto
        {
            FreeDetention = csinquiry.FreeDetention,
            Abnumber = csinquiry.Abnumber,
            GrossWeightInKg = csinquiry.BruttoWeightInKg,
            Container = csinquiry.Container,
            ContainersizeA = csinquiry.ContainersizeA,
            ContainersizeB = csinquiry.ContainersizeB,
            ContainersizeHc = csinquiry.ContainersizeHc,
            Id = csinquiry.Id,
            Incoterm = csinquiry.Incoterm,
            LoadingPlattform = csinquiry.LoadingPlattform,
            ReadyToLoad = csinquiry.ReadyToLoad.ToString("dd.MM.yyyy"),
            Thctb = csinquiry.Thctb
        };
    }
}
