using ContainerToolDBDb;

namespace TippsBackend.Services;

public class TlinquiryService
{
    private readonly ContainerToolDBContext _db;

    public TlinquiryService(ContainerToolDBContext db) => _db = db;

    public List<TlinquiryDto> GetAllTlinquirys()
    {
        return _db.Tlinquiries.Select(x=> new TlinquiryDto().CopyFrom(x)).ToList();
    }

    public TlinquiryDto GetTlinquiryWithId(int id)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == id);

        return new TlinquiryDto().CopyFrom(tlinquiry);
    }

    public TlinquiryDto AddTlinquiry(AddTlinquiryDto addTlinquiryDto)
    {
        var tlinquiry = new Tlinquiry 
        {
            AcceptingPort = addTlinquiryDto.AcceptingPort,
            Boat = addTlinquiryDto.Boat,
            DebtCapitalGeneralForerunEur = addTlinquiryDto.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = addTlinquiryDto.DebtCapitalMainDol,
            DebtCapitalTrailingDol = addTlinquiryDto.DebtCapitalTrailingDol,
            PortOfDeparture = addTlinquiryDto.PortOfDeparture,
            RetrieveDate = DateTime.ParseExact(addTlinquiryDto.RetrieveDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            Country = addTlinquiryDto.Country,
            Eta = DateTime.ParseExact(addTlinquiryDto.Eta, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            Ets = DateTime.ParseExact(addTlinquiryDto.Ets, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            ExpectedRetrieveWeek = DateTime.ParseExact(addTlinquiryDto.ExpectedRetrieveWeek, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            InquiryNumber = addTlinquiryDto.InquiryNumber,
            InvoiceOn = DateTime.ParseExact(addTlinquiryDto.InvoiceOn, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            IsContainer40 = addTlinquiryDto.IsContainer40,
            IsContainerHc = addTlinquiryDto.IsContainerHc,
            RetrieveLocation = addTlinquiryDto.RetrieveLocation,
            Sped = addTlinquiryDto.Sped,
            WeightInKg = addTlinquiryDto.WeightInKg
        };

        _db.Tlinquiries.Add(tlinquiry);
        _db.SaveChanges();

        return new TlinquiryDto().CopyFrom(tlinquiry);
    }

    public TlinquiryDto EditTlinquiry(TlinquiryDto editTlinquiryDto)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == editTlinquiryDto.Id);
        tlinquiry.InquiryNumber = editTlinquiryDto.InquiryNumber;
        tlinquiry.Boat = editTlinquiryDto.Boat;
        tlinquiry.RetrieveDate = editTlinquiryDto.RetrieveDate;
        tlinquiry.RetrieveLocation = editTlinquiryDto.RetrieveLocation;
        tlinquiry.ExpectedRetrieveWeek = editTlinquiryDto.ExpectedRetrieveWeek;
        tlinquiry.AcceptingPort = editTlinquiryDto.AcceptingPort;
        tlinquiry.Country = editTlinquiryDto.Country;
        tlinquiry.DebtCapitalGeneralForerunEur = editTlinquiryDto.DebtCapitalGeneralForerunEur;
        tlinquiry.DebtCapitalMainDol = editTlinquiryDto.DebtCapitalMainDol;
        tlinquiry.DebtCapitalTrailingDol = editTlinquiryDto.DebtCapitalTrailingDol;
        tlinquiry.Eta = editTlinquiryDto.Eta;
        tlinquiry.Ets = editTlinquiryDto.Ets;
        tlinquiry.InvoiceOn = editTlinquiryDto.InvoiceOn;
        tlinquiry.IsContainer40 = editTlinquiryDto.IsContainer40;
        tlinquiry.IsContainerHc = editTlinquiryDto.IsContainerHc;
        tlinquiry.PortOfDeparture = editTlinquiryDto.PortOfDeparture;
        tlinquiry.Sped = editTlinquiryDto.Sped;
        tlinquiry.WeightInKg = editTlinquiryDto.WeightInKg;
        _db.SaveChanges();

        return new TlinquiryDto().CopyFrom(tlinquiry);
    }

    public TlinquiryDto DeleteTlinquiry(int id)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == id);

        _db.Tlinquiries.Remove(tlinquiry);
        _db.SaveChanges();

        return new TlinquiryDto().CopyFrom(tlinquiry);
    }
}
