namespace TippsBackend.Services;

public class StepChecklistService
{
    private readonly ContainerToolDBContext _db;

    public StepChecklistService(ContainerToolDBContext db) => _db = db;

    public List<StepChecklist> GetAllStepChecklists()
    {
        return _db.StepChecklists
            .ToList();
    }
}
