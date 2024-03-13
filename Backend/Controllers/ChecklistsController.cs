using Backend;
using ContainerToolDBDb;
using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class ChecklistsController : ControllerBase
{
    private readonly ChecklistService _checklistService;
    public ChecklistsController(ChecklistService checklistService) => _checklistService = checklistService;

    [HttpGet]
    public List<ChecklistDto> Checklist()
    {
        return _checklistService.GetAllChecklists();
    }

    [HttpGet("GeneratedByAdmin")]
    public List<ChecklistDto> ChecklistByAdmin()
    {
        return _checklistService.GetAllChecklistsGeneratedByAdmin();
    }

    [HttpGet("{id}")]
    public ChecklistDto? ChecklistWithId(int id)
    {
        var checklistWithId = _checklistService.GetChecklistWithId(id);
        if (checklistWithId == null) return null;
        return new ChecklistDto().CopyFrom(checklistWithId);
    }

    [HttpPost]
    public ChecklistDto? Checklist(AddChecklistDto addChecklistDto)
    {
        var checklistWithId = _checklistService.AddNewChecklist(addChecklistDto);
        if (checklistWithId == null) return null;
        return new ChecklistDto().CopyFrom(checklistWithId);
    }

    [HttpPut]
    public ChecklistDto Checklist(ChecklistDto checklistDto)
    {
        return new ChecklistDto().CopyFrom(_checklistService.EditChecklist(checklistDto));
    }

    [HttpDelete]
    public ChecklistDto Checklist(int id)
    {
        return new ChecklistDto().CopyFrom(_checklistService.DeleteChecklist(id));
    }
}
