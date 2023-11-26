namespace TippsBackend.Services;

public class ChecklistService
{
    private readonly ContainerToolDBContext _db;

    public ChecklistService(ContainerToolDBContext db) => _db = db;

    public List<ChecklistDto> GetAllChecklists()
    {
        return _db.Checklists
            .Select(x => new ChecklistDto { CustomerName = x.CustomerName, Id = x.Id, Steps = GetStepsForChecklistId(x.Id) })
            .ToList();
    }

    public List<Step> GetStepsForChecklistId(int id)
    {
        return _db.StepChecklists.Where(x => x.ChecklistId == id).Select(x => x.Step).ToList();
    }

    public ChecklistDto GetChecklistWithId(int id)
    {
        Checklist checklist = _db.Checklists
            .Single(x => x.Id == id);

        return new ChecklistDto().CopyFrom(checklist);
    }

    public ChecklistDto AddNewChecklist(AddChecklistDto addChecklistDto)
    {
        var checklist = new Checklist { CustomerName = addChecklistDto.CustomerName};
        _db.Checklists.Add(checklist);
        _db.SaveChanges();

        foreach (var currStepId in addChecklistDto.StepIds)
        {
            var step = _db.Steps.Single(x => x.Id == currStepId);
            var stepChecklist = new StepChecklist { Checklist = checklist, ChecklistId = checklist.Id, Step = step, StepId = currStepId }; 
            _db.StepChecklists.Add(stepChecklist);
        }
        _db.SaveChanges();

        return new ChecklistDto().CopyFrom(checklist);
    }

    public ChecklistDto EditChecklist(ChecklistDto editChecklist)
    {
        var checklist = _db.Checklists.Single(x => x.Id == editChecklist.Id);
        checklist.CustomerName = editChecklist.CustomerName;
        _db.SaveChanges();

        return new ChecklistDto().CopyFrom(checklist);
    }

    public ChecklistDto DeleteChecklist(int id)
    {
        var checklist = _db.Checklists.Single(x => x.Id == id);

        _db.Checklists.Remove(checklist);
        _db.SaveChanges();

        return new ChecklistDto().CopyFrom(checklist);
    }
}
