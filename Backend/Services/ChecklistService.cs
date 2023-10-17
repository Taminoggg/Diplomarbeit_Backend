namespace TippsBackend.Services;

public class ChecklistService
{
    private readonly ContainerToolDBContext _db;

    public ChecklistService(ContainerToolDBContext db) => _db = db;

    public List<ChecklistDto> GetAllChecklists()
    {
        return _db.Checklists
            .Select(x => new ChecklistDto().CopyFrom(x))
            .ToList();
    }

    public ChecklistDto GetChecklistWithId(int id)
    {
        Checklist checklist = _db.Checklists
            .Single(x => x.Id == id);

        return new ChecklistDto().CopyFrom(checklist);
    }

    public ChecklistDto AddNewChecklist(AddChecklistDto addChecklistDto)
    {
        var checklist = new Checklist().CopyFrom(addChecklistDto);

        _db.Checklists.Add(checklist);
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
