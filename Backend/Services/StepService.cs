using Backend.Dtos;
using ContainerToolDBDb;

namespace TippsBackend.Services;

public class StepService
{
    private readonly ContainerToolDBContext _db;

    public StepService(ContainerToolDBContext db) => _db = db;

    public List<StepChecklist> GetAllStepsForChecklist(int id)
    {
        return _db.StepChecklists
            .Include(x => x.Step)
            .Where(x => x.ChecklistId == id)
            .OrderBy(x => x.Step.StepNumber)
            .ToList();
    }

    public Step CheckStep(EditCheckStepDto editStepDto) 
    {
        var step = _db.Steps.Single(x => x.Id == editStepDto.Id);
        step.IsCompleted = editStepDto.IsCompleted;
        step.LastUpdated = DateTime.Now;

        _db.SaveChanges();

        return step;
    }

    public Step EditStep(EditStepDto editStepDto)
    {
        var step = _db.Steps.Single(x => x.Id == editStepDto.Id);
        step.StepDescription = editStepDto.StepDescription;
        step.StepName = editStepDto.StepName;
        step.StepNumber = editStepDto.StepNumber;
        step.LastUpdated = DateTime.Now;

        _db.SaveChanges();

        return step;
    }

    public Step CreateNewStepForChecklist(AddStepDto addStepDto)
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

        return step;
    }
}
