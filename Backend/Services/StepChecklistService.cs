namespace TippsBackend.Services;

public class StepChecklistService
{
    private readonly ContainerToolDBContext _db;

    public StepChecklistService(ContainerToolDBContext db) => _db = db;

    public List<StepChecklistDto> GetAllStepChecklists()
    {
        return _db.StepChecklists
            .Select(x => new StepChecklistDto { Checklist = x.Checklist, ChecklistId = x.ChecklistId, Step = x.Step, StepId = x.StepId })
            .ToList();
    }
}
