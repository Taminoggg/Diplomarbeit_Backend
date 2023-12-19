using ContainerToolDBDb;

namespace TippsBackend.Services;

public class CsinquiryService
{
    private readonly ContainerToolDBContext _db;

    public CsinquiryService(ContainerToolDBContext db) => _db = db;

    public List<CsinquiryDto> GetAllCsinquiries()
    {
        return _db.Csinquiries.Select(x => new CsinquiryDto 
        {
            DirectLine = x.DirectLine,
            FreeDetention = x.FreeDetention,
            Abnumber = x.Abnumber,
            ArticleNumber = x.ArticleNumber,
            BruttoWeightInKg = x.BruttoWeightInKg,
            Container = x.Container,
            ContainersizeA = x.ContainersizeA,
            ContainersizeB = x.ContainersizeB,
            ContainersizeHc = x.ContainersizeHc,
            Customer = x.Customer,
            FastLine = x.FastLine,
            Id = x.Id,
            Incoterm = x.Incoterm,
            LoadingPlattform = x.LoadingPlattform,
            Palletamount = x.Palletamount,
            ReadyToLoad = x.ReadyToLoad.ToString("dd.MM.yyyy"),
            Thctb = x.Thctb
        }).ToList();
    }

    public CsinquiryDto GetCsinquiryWithId(int id)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == id);

        return new CsinquiryDto 
        {
            DirectLine = csinquiry.DirectLine,
            FreeDetention = csinquiry.FreeDetention,
            Abnumber = csinquiry.Abnumber,
            ArticleNumber = csinquiry.ArticleNumber,
            BruttoWeightInKg = csinquiry.BruttoWeightInKg,
            Container = csinquiry.Container,
            ContainersizeA = csinquiry.ContainersizeA,
            ContainersizeB = csinquiry.ContainersizeB,
            ContainersizeHc = csinquiry.ContainersizeHc,
            Customer = csinquiry.Customer,
            FastLine = csinquiry.FastLine,
            Id = csinquiry.Id,
            Incoterm = csinquiry.Incoterm,
            LoadingPlattform = csinquiry.LoadingPlattform,
            Palletamount = csinquiry.Palletamount,
            ReadyToLoad = csinquiry.ReadyToLoad.ToString("dd.MM.yyyy"),
            Thctb = csinquiry.Thctb
        };
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

        return new CsinquiryDto
        {
            DirectLine = csinquiry.DirectLine,
            FreeDetention = csinquiry.FreeDetention,
            Abnumber = csinquiry.Abnumber,
            ArticleNumber = csinquiry.ArticleNumber,
            BruttoWeightInKg = csinquiry.BruttoWeightInKg,
            Container = csinquiry.Container,
            ContainersizeA = csinquiry.ContainersizeA,
            ContainersizeB = csinquiry.ContainersizeB,
            ContainersizeHc = csinquiry.ContainersizeHc,
            Customer = csinquiry.Customer,
            FastLine = csinquiry.FastLine,
            Id = csinquiry.Id,
            Incoterm = csinquiry.Incoterm,
            LoadingPlattform = csinquiry.LoadingPlattform,
            Palletamount = csinquiry.Palletamount,
            ReadyToLoad = csinquiry.ReadyToLoad.ToString("dd.MM.yyyy"),
            Thctb = csinquiry.Thctb
        };
    }

    public CsinquiryDto EditCsinquiry(EditCsinquiryDto editCsinquiryDto)
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
        csinquiry.ReadyToLoad = DateTime.ParseExact(editCsinquiryDto.ReadyToLoad, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        _db.SaveChanges();

        return new CsinquiryDto
        {
            DirectLine = csinquiry.DirectLine,
            FreeDetention = csinquiry.FreeDetention,
            Abnumber = csinquiry.Abnumber,
            ArticleNumber = csinquiry.ArticleNumber,
            BruttoWeightInKg = csinquiry.BruttoWeightInKg,
            Container = csinquiry.Container,
            ContainersizeA = csinquiry.ContainersizeA,
            ContainersizeB = csinquiry.ContainersizeB,
            ContainersizeHc = csinquiry.ContainersizeHc,
            Customer = csinquiry.Customer,
            FastLine = csinquiry.FastLine,
            Id = csinquiry.Id,
            Incoterm = csinquiry.Incoterm,
            LoadingPlattform = csinquiry.LoadingPlattform,
            Palletamount = csinquiry.Palletamount,
            ReadyToLoad = csinquiry.ReadyToLoad.ToString("dd.MM.yyyy"),
            Thctb = csinquiry.Thctb
        };
    }

    public CsinquiryDto DeleteCsinquiry(int id)
    {
        var csinquiry = _db.Csinquiries.Single(x => x.Id == id);

        _db.Csinquiries.Remove(csinquiry);
        _db.SaveChanges();

        return new CsinquiryDto
        {
            DirectLine = csinquiry.DirectLine,
            FreeDetention = csinquiry.FreeDetention,
            Abnumber = csinquiry.Abnumber,
            ArticleNumber = csinquiry.ArticleNumber,
            BruttoWeightInKg = csinquiry.BruttoWeightInKg,
            Container = csinquiry.Container,
            ContainersizeA = csinquiry.ContainersizeA,
            ContainersizeB = csinquiry.ContainersizeB,
            ContainersizeHc = csinquiry.ContainersizeHc,
            Customer = csinquiry.Customer,
            FastLine = csinquiry.FastLine,
            Id = csinquiry.Id,
            Incoterm = csinquiry.Incoterm,
            LoadingPlattform = csinquiry.LoadingPlattform,
            Palletamount = csinquiry.Palletamount,
            ReadyToLoad = csinquiry.ReadyToLoad.ToString("dd.MM.yyyy"),
            Thctb = csinquiry.Thctb
        };
    }
}
