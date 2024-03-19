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
    public List<CsinquiryDto> Csinquiries()
    {
        var csinquiry = _csinquiryService.GetAllCsinquiries();
        if (csinquiry == null) return new List<CsinquiryDto>();
        return csinquiry.Select(x => ToCsinquiryDto(x)).ToList();
    }

    [HttpGet("{id}")]
    public CsinquiryDto? GetCsinquiryWithId(int id)
    {
        var csinquiry = _csinquiryService.GetCsinquiryWithId(id);
        if (csinquiry == null) return null;
        return ToCsinquiryDto(csinquiry);
    }

    [HttpPost]
    public CsinquiryDto? Csinquiry(AddCsinquiryDto addCsinquiryDto)
    {
        var csinquiry = _csinquiryService.AddCsinquiry(addCsinquiryDto);
        if (csinquiry == null) return null;
        return ToCsinquiryDto(csinquiry);
    }

    [HttpPut]
    public CsinquiryDto? Csinquiry(EditCsinquiryDto editCsinquiry)
    {
        var csinquiry = _csinquiryService.EditCsinquiry(editCsinquiry);
        if (csinquiry == null) return null;
        return ToCsinquiryDto(csinquiry);
    }

    [HttpPut("ApproveCrCs")]
    public CsinquiryDto? ApproveCrCs(EditStatusDto editApproveDto)
    {
        var csinquiry = _csinquiryService.ApproveCrCs(editApproveDto);
        if (csinquiry == null) return null;
        return ToCsinquiryDto(csinquiry);
    }

    [HttpDelete]
    public CsinquiryDto? Csinquiry(int id)
    {
        var csinquiry = _csinquiryService.DeleteCsinquiry(id);
        if (csinquiry == null) return null;
        return ToCsinquiryDto(csinquiry);
    }

    private static CsinquiryDto ToCsinquiryDto(Csinquiry csinquiry)
    {
        return new CsinquiryDto
        {
            FreeDetention = csinquiry.FreeDetention,
            Country = csinquiry.Country,
            IsDirectLine = csinquiry.IsDirectLine,
            Abnumber = csinquiry.Abnumber,
            ContainersizeA = csinquiry.ContainersizeA,
            ContainersizeB = csinquiry.ContainersizeB,
            ContainersizeHc = csinquiry.ContainersizeHc,
            GrossWeightInKg = csinquiry.GrossWeightInKg,
            Incoterm = csinquiry.Incoterm,
            IsFastLine = csinquiry.IsFastLine,
            ReadyToLoad = csinquiry.ReadyToLoad.ToString("yyyy-MM-dd"),
            Thctb = csinquiry.Thctb,
            Thcc = csinquiry.Thcc,
            Id = csinquiry.Id,
            ApprovedByCrCs = csinquiry.ApprovedByCrCs,
            ApprovedByCrCsTime = csinquiry.ApprovedByCrCsTime?.ToString("yyyy-MM-dd") ?? ""
        };
    }
}
