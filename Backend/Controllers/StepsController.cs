using Backend.Dtos;
using ContainerToolDBDb;
using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class StepsController : ControllerBase
{
    private readonly StepService _stepsService;
    public StepsController(StepService stepsService) => _stepsService = stepsService;

    [HttpGet("{id}")]
    public List<StepDto> AllStepsWithChecklistId(int id)
    {
        return _stepsService.GetAllStepsForChecklist(id).Select(x => new StepDto().CopyFrom(x.Step)).ToList();
    }

    [HttpPut("CompleteStep")]
    public StepDto CheckStep(EditCheckStepDto editStepDto)
    {
        return new StepDto().CopyFrom(_stepsService.CheckStep(editStepDto));
    }

    [HttpPut]
    public StepDto EditStep(EditStepDto editStepDto)
    {
        return new StepDto().CopyFrom(_stepsService.EditStep(editStepDto));
    }

    [HttpPost]
    public StepDto Checklist(AddStepDto addStepDto)
    {
        return new StepDto().CopyFrom(_stepsService.CreateNewStepForChecklist(addStepDto));
    }
}
