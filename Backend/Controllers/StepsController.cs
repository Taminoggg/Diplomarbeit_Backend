using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class StepsController : ControllerBase
{
    private readonly StepService _stepsService;
    public StepsController(StepService stepsService) => _stepsService = stepsService;

    [HttpGet("GetStepsForChecklist/{id}")]
    public List<StepDto> GetChecklistWithId(int id)
    {
        return _stepsService.GetAllStepsForChecklist(id);
    }

    [HttpPost("AddNewStep")]
    public StepDto AddNewChecklist(AddStepDto addStepDto)
    {
        return _stepsService.CreateNewStepForChecklist(addStepDto);
    }
}
