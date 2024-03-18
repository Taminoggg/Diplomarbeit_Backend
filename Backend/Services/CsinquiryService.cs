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
        }
        catch (Exception ex)
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
            ContainersizeA = addCsinquiryDto.ContainersizeA,
            ContainersizeB = addCsinquiryDto.ContainersizeB,
            ContainersizeHc = addCsinquiryDto.ContainersizeHc,
            Incoterm = addCsinquiryDto.Incoterm,
            ReadyToLoad = DateTime.ParseExact(addCsinquiryDto.ReadyToLoad, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
            Thctb = addCsinquiryDto.Thctb,
            Thcc = addCsinquiryDto.Thcc,
            Country = addCsinquiryDto.Country,
            IsDirectLine = addCsinquiryDto.IsDirectLine,
            IsFastLine = addCsinquiryDto.IsFastLine,
            ApprovedByCrCsTime = null
        };

        _db.Csinquiries.Add(csinquiry);
        _db.SaveChanges();

        return csinquiry;
    }

    public Csinquiry? ApproveCrCs(EditStatusDto approveOrderDto)
    {
        try
        {
            var csinquiry = _db.Csinquiries
                .Single(x => x.Id == approveOrderDto.Id);
            csinquiry.ApprovedByCrCsTime = DateTime.Now;
            csinquiry.ApprovedByCrCs = approveOrderDto.Status;
            _db.SaveChanges();
            return csinquiry;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Csinquiry? EditCsinquiry(EditCsinquiryDto editCsinquiryDto)
    {
        try
        {
            var csinquiry = _db.Csinquiries.Single(x => x.Id == editCsinquiryDto.Id);
            csinquiry.Thctb = editCsinquiryDto.Thctb;
            csinquiry.ContainersizeB = editCsinquiryDto.ContainersizeB;
            csinquiry.Abnumber = editCsinquiryDto.Abnumber;
            csinquiry.GrossWeightInKg = editCsinquiryDto.GrossWeightInKg;
            csinquiry.Country = editCsinquiryDto.Country;
            csinquiry.ContainersizeA = editCsinquiryDto.ContainersizeA;
            csinquiry.ContainersizeHc = editCsinquiryDto.ContainersizeHc;
            csinquiry.FreeDetention = editCsinquiryDto.FreeDetention;
            csinquiry.Thcc = editCsinquiryDto.Thcc;
            csinquiry.Incoterm = editCsinquiryDto.Incoterm;
            csinquiry.ReadyToLoad = DateTime.ParseExact(editCsinquiryDto.ReadyToLoad, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            csinquiry.IsFastLine = editCsinquiryDto.IsFastLine;
            csinquiry.IsDirectLine = editCsinquiryDto.IsDirectLine;
            _db.SaveChanges();

            return csinquiry;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Csinquiry DeleteCsinquiry(int id)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == id);

        _db.Csinquiries.Remove(csinquiry);
        _db.SaveChanges();

        return csinquiry;
    }
}
