namespace TippsBackend.Services;

public class StepService
{
    private readonly ContainerToolDBContext _db;

    public StepService(ContainerToolDBContext db) => _db = db;

    public List<StepDto> GetAllStepsForChecklist(int id)
    {
        return _db.StepChecklists
            .Include(x => x.Step)
            .Where(x => x.ChecklistId == id)
            .Select(x => new StepDto().CopyFrom(x.Step))
            .ToList();
    }

    public StepDto CreateNewStepForChecklist(AddStepDto addStepDto)
    {
        var step = new Step {
            StepDescription = addStepDto.StepDescription, 
            StepNumber = addStepDto.StepNumber, 
            StepName = addStepDto.StepName 
        };

        _db.Steps.Add(step);
        _db.SaveChanges();

        var checklist = _db.Checklists.Single(x => x.Id == addStepDto.ChecklistId);
        var stepChecklist = new StepChecklist { ChecklistId = addStepDto.ChecklistId, StepId = step.Id, Step = step, Checklist = checklist };
        _db.StepChecklists.Add(stepChecklist);
        _db.SaveChanges();

        return new StepDto().CopyFrom(step);
    }
}
