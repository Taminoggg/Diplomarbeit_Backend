using ContainerToolDBDb;

namespace TippsBackend.Services;

public class CsinquiryService
{
    private readonly ContainerToolDBContext _db;

    public CsinquiryService(ContainerToolDBContext db) => _db = db;

    public List<CsinquiryDto> GetAllCsinquiries()
    {
        return _db.Csinquiries.Select(x => new CsinquiryDto().CopyFrom(x)).ToList();
    }

    public CsinquiryDto GetCsinquiryWithId(int id)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == id);

        return new CsinquiryDto().CopyFrom(csinquiry);
    }

    public CsinquiryDto AddCsinquiry(AddCsinquiryDto addCsinquiryDto)
    {
        var csinquiry = new Csinquiry
        {
            DirectLine = addCsinquiryDto.DirectLine,
            FreeDetention = addCsinquiryDto.FreeDetention,
            FastLine = addCsinquiryDto.FastLine,
            Abnumber = addCsinquiryDto.Abnumber,
            ArticleNumber = addCsinquiryDto.ArticleNumber,
            BruttoWeightInKg = addCsinquiryDto.BruttoWeightInKg,
            Container = addCsinquiryDto.Container,
            ContainersizeA = addCsinquiryDto.ContainersizeA,
            ContainersizeB = addCsinquiryDto.ContainersizeB,
            ContainersizeHc = addCsinquiryDto.ContainersizeHc,
            Customer = addCsinquiryDto.Customer,
            Incoterm = addCsinquiryDto.Incoterm,
            LoadingPlattform = addCsinquiryDto.LoadingPlattform,
            Palletamount = addCsinquiryDto.Palletamount,
            ReadyToLoad = DateTime.ParseExact(addCsinquiryDto.ReadyToLoad, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            Thctb = addCsinquiryDto.Thctb
        };

        _db.Csinquiries.Add(csinquiry);
        _db.SaveChanges();

        return new CsinquiryDto().CopyFrom(csinquiry);
    }

    public CsinquiryDto EditCsinquiry(CsinquiryDto editCsinquiryDto)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == editCsinquiryDto.Id);
        csinquiry.Thctb = editCsinquiryDto.Thctb;
        csinquiry.FastLine = editCsinquiryDto.FastLine;
        csinquiry.DirectLine = editCsinquiryDto.DirectLine;
        csinquiry.ContainersizeB = editCsinquiryDto.ContainersizeB;
        csinquiry.Container = editCsinquiryDto.Container;
        csinquiry.Abnumber = editCsinquiryDto.Abnumber;
        csinquiry.ArticleNumber = editCsinquiryDto.ArticleNumber;
        csinquiry.BruttoWeightInKg = editCsinquiryDto.BruttoWeightInKg;
        csinquiry.ContainersizeA = editCsinquiryDto.ContainersizeA;
        csinquiry.ContainersizeHc = editCsinquiryDto.ContainersizeHc;
        csinquiry.Customer = editCsinquiryDto.Customer;
        csinquiry.FreeDetention = editCsinquiryDto.FreeDetention;
        csinquiry.Incoterm = editCsinquiryDto.Incoterm;
        csinquiry.LoadingPlattform = editCsinquiryDto.LoadingPlattform;
        csinquiry.Palletamount = editCsinquiryDto.Palletamount;
        csinquiry.ReadyToLoad = editCsinquiryDto.ReadyToLoad;
        _db.SaveChanges();

        return new CsinquiryDto().CopyFrom(csinquiry);
    }

    public CsinquiryDto DeleteCsinquiry(int id)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == id);

        _db.Csinquiries.Remove(csinquiry);
        _db.SaveChanges();

        return new CsinquiryDto().CopyFrom(csinquiry);
    }
}
