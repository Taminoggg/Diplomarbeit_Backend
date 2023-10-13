using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class ChecklistController : ControllerBase
{
    private readonly ChecklistController _checklistController;
    public ChecklistController(ChecklistController checklistController) => _checklistController = checklistController;

    [HttpGet("GetAllChecklists")]
    public List<ChecklistDto> GetAllChecklists()
    {
        return _checklistController.GetAllChecklists();
    }

    [HttpGet("GetChecklistWithId/{id}")]
    public ChecklistDto GetChecklistWithId(int id)
    {
        return _checklistController.GetChecklistWithId(id);
    }

    [HttpPost("AddNewChecklist")]
    public ChecklistDto AddNewChecklist(AddChecklistDto addChecklistDto)
    {
        return _checklistController.AddNewChecklist(addChecklistDto);
    }

    [HttpPut("EditChecklist")]
    public ChecklistDto EditChecklist(ChecklistDto checklistDto)
    {
        return _checklistController.EditChecklist(checklistDto);
    }

    [HttpDelete("DeleteChecklist")]
    public ChecklistDto DeleteChecklist(int id)
    {
        return _checklistController.DeleteChecklist(id);
    }
}
