namespace TippsBackend.Services;

public class ChecklistService
{
    private readonly ContainerToolDBContext _db;

    public ChecklistService(ContainerToolDBContext db) => _db = db;

    public List<ChecklistDto> GetAllChecklists()
    {
        return _db.Checklists
        .Select(x => new ChecklistDto
        {
            CustomerName = x.CustomerName,
            Id = x.Id,
            Steps = _db.StepChecklists.Where(sc => sc.ChecklistId == x.Id).Select(sc => sc.Step).ToList()
        })
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
        try
        {
            var checklist = new Checklist { CustomerName = addChecklistDto.CustomerName };
            _db.Checklists.Add(checklist);
            _db.SaveChanges();

            return new ChecklistDto().CopyFrom(checklist);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new ChecklistDto();
        }
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
