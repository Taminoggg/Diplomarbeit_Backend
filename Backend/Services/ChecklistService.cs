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
            Checklistname = x.Checklistname,
            Id = x.Id
        })
        .ToList();
    }

    public Checklist? GetChecklistWithId(int id)
    {
        try
        {
            Checklist checklist = _db.Checklists
            .Single(x => x.Id == id);

            return checklist;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Checklist AddNewChecklist(AddChecklistDto addChecklistDto)
    {
        try
        {
            var checklist = new Checklist { Checklistname = addChecklistDto.Checklistname };
            _db.Checklists.Add(checklist);
            _db.SaveChanges();

            return checklist;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new Checklist();
        }
    }

    public Checklist EditChecklist(ChecklistDto editChecklist)
    {
        var checklist = _db.Checklists.Single(x => x.Id == editChecklist.Id);
        checklist.Checklistname = editChecklist.Checklistname;
        _db.SaveChanges();

        return checklist;
    }

    public Checklist DeleteChecklist(int id)
    {
        var checklist = _db.Checklists.Single(x => x.Id == id);

        _db.Checklists.Remove(checklist);
        _db.SaveChanges();

        return checklist;
    }
}
