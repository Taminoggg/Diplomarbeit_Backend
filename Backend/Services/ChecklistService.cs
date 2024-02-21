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
            Id = x.Id,
            GeneratedByAdmin = x.GeneratedByAdmin
        })
        .ToList();
    }

    public List<ChecklistDto> GetAllChecklistsGeneratedByAdmin()
    {
        return _db.Checklists
        .Where(x => x.GeneratedByAdmin == true)
        .Select(x => new ChecklistDto
        {
            Checklistname = x.Checklistname,
            Id = x.Id,
            GeneratedByAdmin = x.GeneratedByAdmin
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

    public Checklist? AddNewChecklist(AddChecklistDto addChecklistDto)
    {
        try
        {
            Checklist? checklist = null;
            if (addChecklistDto.Id == null)
            {
                checklist = new Checklist { Checklistname = addChecklistDto.Checklistname, GeneratedByAdmin = addChecklistDto.GeneratedByAdmin };
            }
            else
            {
                var checklistToClone = _db.Checklists.Single(x => x.Id == addChecklistDto.Id);
                var newChecklist = new Checklist
                {
                    Checklistname = checklistToClone.Checklistname,
                    GeneratedByAdmin = addChecklistDto.GeneratedByAdmin
                };
                checklist = newChecklist;
            }

            _db.Checklists.Add(checklist);
            _db.SaveChanges();

            return checklist;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
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
