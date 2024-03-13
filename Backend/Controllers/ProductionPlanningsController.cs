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

    [HttpGet("{id}")]
    public ProductionPlanningDto? OrderWithId(int id)
    {
        var productionPlanning = _productionPlanningService.GetProdcutionPlanningsForId(id);
        if (productionPlanning == null) return null;
        return ToProductionPlanningDto(productionPlanning);
    }

    [HttpPut("ApprovePpCs")]
    public ProductionPlanningDto? ApprovePpCs(EditStatusDto editApproveDto)
    {
        var prodctionPlanning = _productionPlanningService.ApprovePpCs(editApproveDto);
        if (prodctionPlanning == null) return null;
        return ToProductionPlanningDto(prodctionPlanning);
    }

    [HttpPut("ApprovePpPp")]
    public ProductionPlanningDto? ApprovePpPp(EditStatusDto editApproveDto)
    {
        var prodctionPlanning = _productionPlanningService.ApprovePpPp(editApproveDto);
        if (prodctionPlanning == null) return null;
        return ToProductionPlanningDto(prodctionPlanning);
    }

    [HttpPut]
    public ProductionPlanningDto? Put(EditProductionPlanningDto editProductionPlanningDto)
    {
        var prodctionPlanning = _productionPlanningService.Put(editProductionPlanningDto);
        if (prodctionPlanning == null) return null;
        return ToProductionPlanningDto(prodctionPlanning);
    }

    [HttpPost]
    public ProductionPlanningDto? Post(AddProductionPlanningDto addProductionPlanningDto)
    {
        var prodctionPlanning = _productionPlanningService.Post(addProductionPlanningDto);
        if (prodctionPlanning == null) return null;
        return ToProductionPlanningDto(prodctionPlanning);
    }

    private static ProductionPlanningDto ToProductionPlanningDto(ProductionPlanning productionPlanning)
    {
        return new ProductionPlanningDto
        {
            ApprovedByPpCs = productionPlanning.ApprovedByPpCs,
            ApprovedByPpPp = productionPlanning.ApprovedByPpPp,
            Id = productionPlanning.Id,
            ApprovedByPpCsTime = productionPlanning.ApprovedByPpCsTime?.ToString("yyyy-MM-dd") ?? "",
            ApprovedByPpPpTime = productionPlanning.ApprovedByPpPpTime?.ToString("yyyy-MM-dd") ?? "",
            RecievingCountry = productionPlanning.RecievingCountry,
            CustomerPriority = productionPlanning.CustomerPriority
        };
    }
}
