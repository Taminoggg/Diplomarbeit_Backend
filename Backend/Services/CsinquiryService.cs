using ContainerToolDBDb;

namespace TippsBackend.Services;

public class CsinquiryService
{
    private readonly ContainerToolDBContext _db;

    public CsinquiryService(ContainerToolDBContext db) => _db = db;

    public List<Csinquiry> GetAllCsinquiries()
    {
        return _db.Csinquiries.ToList();
    }

    public Csinquiry? GetCsinquiryWithId(int id)
    {
        try
        {
            var csinquiry = _db.Csinquiries.Single(x => x.Id == id);

            return csinquiry;
        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Csinquiry AddCsinquiry(AddCsinquiryDto addCsinquiryDto)
    {
        var csinquiry = new Csinquiry
        {
            FreeDetention = addCsinquiryDto.FreeDetention,
            Abnumber = addCsinquiryDto.Abnumber,
            GrossWeightInKg = addCsinquiryDto.BruttoWeightInKg,
            Container = addCsinquiryDto.Container,
            ContainersizeA = addCsinquiryDto.ContainersizeA,
            ContainersizeB = addCsinquiryDto.ContainersizeB,
            ContainersizeHc = addCsinquiryDto.ContainersizeHc,
            Incoterm = addCsinquiryDto.Incoterm,
            LoadingPlattform = addCsinquiryDto.LoadingPlattform,
            ReadyToLoad = DateTime.ParseExact(addCsinquiryDto.ReadyToLoad, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            Thctb = addCsinquiryDto.Thctb
        };

        _db.Csinquiries.Add(csinquiry);
        _db.SaveChanges();

        return csinquiry;
    }

    public Csinquiry EditCsinquiry(EditCsinquiryDto editCsinquiryDto)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == editCsinquiryDto.Id);
        csinquiry.Thctb = editCsinquiryDto.Thctb;
        csinquiry.ContainersizeB = editCsinquiryDto.ContainersizeB;
        csinquiry.Container = editCsinquiryDto.Container;
        csinquiry.Abnumber = editCsinquiryDto.Abnumber;
        csinquiry.GrossWeightInKg = editCsinquiryDto.GrossWeightInKg;
        csinquiry.ContainersizeA = editCsinquiryDto.ContainersizeA;
        csinquiry.ContainersizeHc = editCsinquiryDto.ContainersizeHc;
        csinquiry.FreeDetention = editCsinquiryDto.FreeDetention;
        csinquiry.Incoterm = editCsinquiryDto.Incoterm;
        csinquiry.LoadingPlattform = editCsinquiryDto.LoadingPlattform;
        csinquiry.ReadyToLoad = DateTime.ParseExact(editCsinquiryDto.ReadyToLoad, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        _db.SaveChanges();

        return csinquiry;
    }

    public Csinquiry DeleteCsinquiry(int id)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == id);

        _db.Csinquiries.Remove(csinquiry);
        _db.SaveChanges();

        return csinquiry;
    }
}
