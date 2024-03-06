using Backend.Dtos;
using Backend.Services;
using ContainerToolDB;
using ContainerToolDBDb;
using TippsBackend.Services;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductionPlanningsController : ControllerBase
{
    private readonly ProductionPlanningService _productionPlanningService;
    public ProductionPlanningsController(ProductionPlanningService productionPlanningService) => _productionPlanningService = productionPlanningService;

    [HttpGet]
    public List<ProductionPlanningDto> ProductionPlannings()
    {
        return _productionPlanningService.GetAllProdcutionPlannings().Select(x => ToProductionPlanningDto(x)).ToList();
    }

    [HttpPut("PpCs")]
    public ProductionPlanningDto? ApprovePpCs(EditApproveDto editApproveDto)
    {
        var prodctionPlanning = _productionPlanningService.ApprovePpCs(editApproveDto);
        if (prodctionPlanning == null) return null;
        return ToProductionPlanningDto(prodctionPlanning);
    }

    [HttpPut("PpPp")]
    public ProductionPlanningDto? ApprovePpPp(EditApproveDto editApproveDto)
    {
        var prodctionPlanning = _productionPlanningService.ApprovePpPp(editApproveDto);
        if (prodctionPlanning == null) return null;
        return ToProductionPlanningDto(prodctionPlanning);
    }

    [HttpPost]
    public ProductionPlanningDto? Post()
    {
        var prodctionPlanning = _productionPlanningService.Post();
        if (prodctionPlanning == null) return null;
        return ToProductionPlanningDto(prodctionPlanning);
    }

    private ProductionPlanningDto ToProductionPlanningDto(ProductionPlanning productionPlanning)
    {
        return new ProductionPlanningDto
        {
            ApprovedByPpCs = productionPlanning.ApprovedByPpCs,
            ApprovedByPpPp = productionPlanning.ApprovedByPpPp,
            Id = productionPlanning.Id,
            ApprovedByPpCsTime = productionPlanning.ApprovedByPpCsTime?.ToString("dd.MM.yyyy") ?? "",
            ApprovedByPpPpTime = productionPlanning.ApprovedByPpPpTime?.ToString("dd.MM.yyyy") ?? ""
        };
    }
}
