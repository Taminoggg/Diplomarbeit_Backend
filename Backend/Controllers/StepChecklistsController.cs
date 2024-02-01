using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class StepChecklistsController : ControllerBase
{
    private readonly StepChecklistService _stepChecklistService;
    public StepChecklistsController(StepChecklistService stepChecklistService) => _stepChecklistService = stepChecklistService;

    [HttpGet]
    public List<StepChecklistDto> ChecklistWithId()
    {
        return _stepChecklistService.GetAllStepChecklists().Select(x => new StepChecklistDto().CopyFrom(x)).ToList();
    }
}
