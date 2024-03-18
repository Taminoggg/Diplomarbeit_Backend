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
            SCGeneral = 1,
            SCMainRun = 1,
            SCTrail = 1,
            PortOfDeparture = "",
            RetrieveDate = null,
            Eta = null,
            Ets = null,
            InvoiceOn = null,
            RetrieveLocation = "",
            Sped = "",
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
        tlinquiry.Boat = editTlinquiryDto.Boat;
        tlinquiry.RetrieveDate = DateTime.ParseExact(editTlinquiryDto.RetrieveDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.RetrieveLocation = editTlinquiryDto.RetrieveLocation;
        tlinquiry.AcceptingPort = editTlinquiryDto.AcceptingPort;
        tlinquiry.SCGeneral = editTlinquiryDto.SCGeneral;
        tlinquiry.SCMainRun = editTlinquiryDto.SCMain;
        tlinquiry.SCTrail = editTlinquiryDto.SCTrail;
        tlinquiry.Eta = DateTime.ParseExact(editTlinquiryDto.Eta, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.Ets = DateTime.ParseExact(editTlinquiryDto.Ets, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.InvoiceOn = DateTime.ParseExact(editTlinquiryDto.InvoiceOn, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        tlinquiry.PortOfDeparture = editTlinquiryDto.PortOfDeparture;
        tlinquiry.Sped = editTlinquiryDto.Sped;
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
