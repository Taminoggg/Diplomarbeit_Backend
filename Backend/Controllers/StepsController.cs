using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class StepsController : ControllerBase
{
    private readonly StepService _stepsService;
    public StepsController(StepService stepsService) => _stepsService = stepsService;

    [HttpGet("{id}")]
    public List<StepDto> ChecklistWithId(int id)
    {
        return _stepsService.GetAllStepsForChecklist(id);
    }

    [HttpPost]
    public StepDto Checklist(AddStepDto addStepDto)
    {
        return _stepsService.CreateNewStepForChecklist(addStepDto);
    }
}
