using ContainerToolDBDb;

namespace TippsBackend.Services;

public class TlinquiryService
{
    private readonly ContainerToolDBContext _db;

    public TlinquiryService(ContainerToolDBContext db) => _db = db;

    public List<TlinquiryDto> GetAllTlinquirys()
    {
        return _db.Tlinquiries.Select(x=> new TlinquiryDto
        {
            DebtCapitalGeneralForerunEur = x.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = x.DebtCapitalMainDol,
            DebtCapitalTrailingDol = x.DebtCapitalTrailingDol,
            PortOfDeparture = x.PortOfDeparture,
            RetrieveDate = x.RetrieveDate.ToString("dd.MM.yyyy"),
            AcceptingPort = x.AcceptingPort,
            Boat = x.Boat,
            Country = x.Country,
            Eta = x.Eta.ToString("dd.MM.yyyy"),
            Ets = x.Ets.ToString("dd.MM.yyyy"),
            ExpectedRetrieveWeek = x.ExpectedRetrieveWeek.ToString("dd.MM.yyyy"),
            InquiryNumber = x.InquiryNumber,
            InvoiceOn = x.InvoiceOn.ToString("dd.MM.yyyy"),
            Id = x.Id,
            IsContainer40 = x.IsContainer40,
            IsContainerHc = x.IsContainerHc,
            RetrieveLocation = x.RetrieveLocation,
            Sped = x.Sped,
            WeightInKg = x.WeightInKg
        }).ToList();
    }

    public TlinquiryDto GetTlinquiryWithId(int id)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == id);

        return new TlinquiryDto
        {
            DebtCapitalGeneralForerunEur = tlinquiry.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = tlinquiry.DebtCapitalMainDol,
            DebtCapitalTrailingDol = tlinquiry.DebtCapitalTrailingDol,
            PortOfDeparture = tlinquiry.PortOfDeparture,
            RetrieveDate = tlinquiry.RetrieveDate.ToString("dd.MM.yyyy"),
            AcceptingPort = tlinquiry.AcceptingPort,
            Boat = tlinquiry.Boat,
            Country = tlinquiry.Country,
            Eta = tlinquiry.Eta.ToString("dd.MM.yyyy"),
            Ets = tlinquiry.Ets.ToString("dd.MM.yyyy"),
            ExpectedRetrieveWeek = tlinquiry.ExpectedRetrieveWeek.ToString("dd.MM.yyyy"),
            InquiryNumber = tlinquiry.InquiryNumber,
            InvoiceOn = tlinquiry.InvoiceOn.ToString("dd.MM.yyyy"),
            Id = tlinquiry.Id,
            IsContainer40 = tlinquiry.IsContainer40,
            IsContainerHc = tlinquiry.IsContainerHc,
            RetrieveLocation = tlinquiry.RetrieveLocation,
            Sped = tlinquiry.Sped,
            WeightInKg = tlinquiry.WeightInKg
        };
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

        return new TlinquiryDto
        {
            DebtCapitalGeneralForerunEur = tlinquiry.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = tlinquiry.DebtCapitalMainDol,
            DebtCapitalTrailingDol = tlinquiry.DebtCapitalTrailingDol,
            PortOfDeparture = tlinquiry.PortOfDeparture,
            RetrieveDate = tlinquiry.RetrieveDate.ToString("dd.MM.yyyy"),
            AcceptingPort = tlinquiry.AcceptingPort,
            Boat = tlinquiry.Boat,
            Country = tlinquiry.Country,
            Eta = tlinquiry.Eta.ToString("dd.MM.yyyy"),
            Ets = tlinquiry.Ets.ToString("dd.MM.yyyy"),
            ExpectedRetrieveWeek = tlinquiry.ExpectedRetrieveWeek.ToString("dd.MM.yyyy"),
            InquiryNumber = tlinquiry.InquiryNumber,
            InvoiceOn = tlinquiry.InvoiceOn.ToString("dd.MM.yyyy"),
            Id = tlinquiry.Id,
            IsContainer40 = tlinquiry.IsContainer40,
            IsContainerHc = tlinquiry.IsContainerHc,
            RetrieveLocation = tlinquiry.RetrieveLocation,
            Sped = tlinquiry.Sped,
            WeightInKg = tlinquiry.WeightInKg
        };
    }

    public TlinquiryDto EditTlinquiry(EditTlInqueryDto editTlinquiryDto)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == editTlinquiryDto.Id);
        tlinquiry.InquiryNumber = editTlinquiryDto.InquiryNumber;
        tlinquiry.Boat = editTlinquiryDto.Boat;
        tlinquiry.RetrieveDate = DateTime.ParseExact(editTlinquiryDto.RetrieveDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.RetrieveLocation = editTlinquiryDto.RetrieveLocation;
        tlinquiry.ExpectedRetrieveWeek = DateTime.ParseExact(editTlinquiryDto.ExpectedRetrieveWeek, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.AcceptingPort = editTlinquiryDto.AcceptingPort;
        tlinquiry.Country = editTlinquiryDto.Country;
        tlinquiry.DebtCapitalGeneralForerunEur = editTlinquiryDto.DebtCapitalGeneralForerunEur;
        tlinquiry.DebtCapitalMainDol = editTlinquiryDto.DebtCapitalMainDol;
        tlinquiry.DebtCapitalTrailingDol = editTlinquiryDto.DebtCapitalTrailingDol;
        tlinquiry.Eta = DateTime.ParseExact(editTlinquiryDto.Eta, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.Ets = DateTime.ParseExact(editTlinquiryDto.Ets, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.InvoiceOn = DateTime.ParseExact(editTlinquiryDto.InvoiceOn, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.IsContainer40 = editTlinquiryDto.IsContainer40;
        tlinquiry.IsContainerHc = editTlinquiryDto.IsContainerHc;
        tlinquiry.PortOfDeparture = editTlinquiryDto.PortOfDeparture;
        tlinquiry.Sped = editTlinquiryDto.Sped;
        tlinquiry.WeightInKg = editTlinquiryDto.WeightInKg;
        _db.SaveChanges();

        return new TlinquiryDto 
        {
            DebtCapitalGeneralForerunEur = tlinquiry.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = tlinquiry.DebtCapitalMainDol,
            DebtCapitalTrailingDol = tlinquiry.DebtCapitalTrailingDol,
            PortOfDeparture = tlinquiry.PortOfDeparture,
            RetrieveDate = tlinquiry.RetrieveDate.ToString("dd.MM.yyyy"),
            AcceptingPort = tlinquiry.AcceptingPort,
            Boat = tlinquiry.Boat,
            Country = tlinquiry.Country,
            Eta = tlinquiry.Eta.ToString("dd.MM.yyyy"),
            Ets = tlinquiry.Ets.ToString("dd.MM.yyyy"),
            ExpectedRetrieveWeek = tlinquiry.ExpectedRetrieveWeek.ToString("dd.MM.yyyy"),
            InquiryNumber = tlinquiry.InquiryNumber,
            InvoiceOn = tlinquiry.InvoiceOn.ToString("dd.MM.yyyy"),
            Id = tlinquiry.Id,
            IsContainer40 = tlinquiry.IsContainer40,
            IsContainerHc = tlinquiry.IsContainerHc,
            RetrieveLocation = tlinquiry.RetrieveLocation,
            Sped = tlinquiry.Sped,
            WeightInKg = tlinquiry.WeightInKg
        };
    }

    public TlinquiryDto DeleteTlinquiry(int id)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == id);

        _db.Tlinquiries.Remove(tlinquiry);
        _db.SaveChanges();

        return new TlinquiryDto
        {
            DebtCapitalGeneralForerunEur = tlinquiry.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = tlinquiry.DebtCapitalMainDol,
            DebtCapitalTrailingDol = tlinquiry.DebtCapitalTrailingDol,
            PortOfDeparture = tlinquiry.PortOfDeparture,
            RetrieveDate = tlinquiry.RetrieveDate.ToString("dd.MM.yyyy"),
            AcceptingPort = tlinquiry.AcceptingPort,
            Boat = tlinquiry.Boat,
            Country = tlinquiry.Country,
            Eta = tlinquiry.Eta.ToString("dd.MM.yyyy"),
            Ets = tlinquiry.Ets.ToString("dd.MM.yyyy"),
            ExpectedRetrieveWeek = tlinquiry.ExpectedRetrieveWeek.ToString("dd.MM.yyyy"),
            InquiryNumber = tlinquiry.InquiryNumber,
            InvoiceOn = tlinquiry.InvoiceOn.ToString("dd.MM.yyyy"),
            Id = tlinquiry.Id,
            IsContainer40 = tlinquiry.IsContainer40,
            IsContainerHc = tlinquiry.IsContainerHc,
            RetrieveLocation = tlinquiry.RetrieveLocation,
            Sped = tlinquiry.Sped,
            WeightInKg = tlinquiry.WeightInKg
        };
    }
}
