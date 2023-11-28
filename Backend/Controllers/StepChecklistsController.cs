using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class StepChecklistsController : ControllerBase
{
    private readonly StepChecklistService _stepChecklistService;
    public StepChecklistsController(StepChecklistService stepChecklistService) => _stepChecklistService = stepChecklistService;

    [HttpGet]
    public List<StepChecklistDto> GetChecklistWithId()
    {
        return _stepChecklistService.GetAllStepChecklists();
    }
}
