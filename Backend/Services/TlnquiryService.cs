using ContainerToolDBDb;

namespace TippsBackend.Services;

public class TlinquiryService
{
    private readonly ContainerToolDBContext _db;

    public TlinquiryService(ContainerToolDBContext db) => _db = db;

    public List<Tlinquiry> GetAllTlinquirys()
    {
        return _db.Tlinquiries.ToList();
    }

    public Tlinquiry? GetTlinquiryWithId(int id)
    {
        try
        {
            var tlinquiry = _db.Tlinquiries.Single(x => x.Id == id);

            return tlinquiry;
        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);    
            return null;
        }
    }

    public Tlinquiry? ApproveCrTl(EditStatusDto approveOrderDto)
    {
        try
        {
            var tlinquiry = _db.Tlinquiries
                .Single(x => x.Id == approveOrderDto.Id);
            tlinquiry.ApprovedByCrTlTime = DateTime.Now;
            tlinquiry.ApprovedByCrTl = approveOrderDto.Status;
            _db.SaveChanges();
            return tlinquiry;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Tlinquiry AddTlinquiry()
    {
        var tlinquiry = new Tlinquiry 
        {
            AcceptingPort = "",
            Boat = "",
            DebtCapitalGeneralForerunEur = 1,
            DebtCapitalMainDol = 1,
            DebtCapitalTrailingDol = 1,
            PortOfDeparture = "",
            RetrieveDate = null,
            Country = "",
            Eta = null,
            Ets = null,
            ExpectedRetrieveWeek = null,
            InquiryNumber = 1,
            InvoiceOn = null,
            IsContainer40 = false,
            IsContainerHc = false,
            RetrieveLocation = "",
            Sped = "",
            WeightInKg = 1,
            ApprovedByCrTl = false,
            ApprovedByCrTlTime = null
        };

        _db.Tlinquiries.Add(tlinquiry);
        _db.SaveChanges();

        return tlinquiry;
    }

    public Tlinquiry EditTlinquiry(EditTlInqueryDto editTlinquiryDto)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == editTlinquiryDto.Id);
        tlinquiry.InquiryNumber = editTlinquiryDto.InquiryNumber;
        tlinquiry.Boat = editTlinquiryDto.Boat;
        tlinquiry.RetrieveDate = DateTime.ParseExact(editTlinquiryDto.RetrieveDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.RetrieveLocation = editTlinquiryDto.RetrieveLocation;
        tlinquiry.ExpectedRetrieveWeek = DateTime.ParseExact(editTlinquiryDto.ExpectedRetrieveWeek, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.AcceptingPort = editTlinquiryDto.AcceptingPort;
        tlinquiry.Country = editTlinquiryDto.Country;
        tlinquiry.DebtCapitalGeneralForerunEur = editTlinquiryDto.DebtCapitalGeneralForerunEur;
        tlinquiry.DebtCapitalMainDol = editTlinquiryDto.DebtCapitalMainDol;
        tlinquiry.DebtCapitalTrailingDol = editTlinquiryDto.DebtCapitalTrailingDol;
        tlinquiry.Eta = DateTime.ParseExact(editTlinquiryDto.Eta, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.Ets = DateTime.ParseExact(editTlinquiryDto.Ets, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.InvoiceOn = DateTime.ParseExact(editTlinquiryDto.InvoiceOn, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.IsContainer40 = editTlinquiryDto.IsContainer40;
        tlinquiry.IsContainerHc = editTlinquiryDto.IsContainerHc;
        tlinquiry.PortOfDeparture = editTlinquiryDto.PortOfDeparture;
        tlinquiry.Sped = editTlinquiryDto.Sped;
        tlinquiry.WeightInKg = editTlinquiryDto.WeightInKg;
        _db.SaveChanges();

        return tlinquiry;
    }

    public Tlinquiry DeleteTlinquiry(int id)
    {
        var tlinquiry = _db.Tlinquiries.Single(x => x.Id == id);

        _db.Tlinquiries.Remove(tlinquiry);
        _db.SaveChanges();

        return tlinquiry;
    }
}
