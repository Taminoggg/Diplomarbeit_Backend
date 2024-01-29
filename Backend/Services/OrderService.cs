using ContainerToolDBDb;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TippsBackend.Services;

public class OrderService
{
    private readonly ContainerToolDBContext _db;
    private readonly ILogger _logger;

    public OrderService(ContainerToolDBContext db, ILogger<OrderService> logger)
    {
        this._logger = logger;
        this._db = db;
    }

    public List<Order> GetAllOrders()
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .ToList();
    }

    public List<Order> GetOrdersWithCustomername(string customerName)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.CustomerName.ToLower().Contains(customerName.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithApproved(bool approved)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Approved == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithAmount(int amount)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Amount == amount)
            .ToList();
    }

    public List<Order> GetOrdersWithCreatedBy(string createdBy)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.CreatedBy.ToLower().Contains(createdBy.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithCountry(string country)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(y => _db.Tlinquiries.Single(x => x.Id == y.Tlid).Country.ToLower().Contains(country.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithSped(string sped)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(y => _db.Tlinquiries.Single(x => x.Id == y.Tlid).Sped.ToLower().Contains(sped.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithLastUpdated(string date)
    {
        try
        {
            return _db.Orders
             .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => EF.Functions.DateDiffDay(x.LastUpdated, DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)) == 0)
            .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new List<Order>();
        }
    }

    public List<Order> GetOrdersWithStatus(int status)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Status == status)
            .ToList();
    }

    public Order GetOrderWithId(int id)
    {
        Order order = _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .Single(x => x.Id == id);

        return order;
    }

    public Order AddOrder(AddOrderDto addOrderDto)
    {
        var checklist = _db.Checklists.Single(x => x.Id == addOrderDto.ChecklistId);
        var cs = _db.Csinquiries.Single(x => x.Id == addOrderDto.Csid);
        var tl = _db.Tlinquiries.Single(x => x.Id == addOrderDto.Tlid);
        var order = new Order
        {
            Amount = addOrderDto.Amount,
            Approved = false,
            Checklist = checklist,
            ChecklistId = addOrderDto.ChecklistId,
            CreatedBy = addOrderDto.CreatedBy,
            Cs = cs,
            Tl = tl,
            Csid = addOrderDto.Csid,
            CustomerName = addOrderDto.CustomerName,
            LastUpdated = DateTime.Now,
            Status = addOrderDto.Status,
            Tlid = addOrderDto.Tlid,
        };

        _db.Entry(order).Reference(o => o.Checklist).Load();
        _db.Entry(order).Reference(o => o.Cs).Load();
        _db.Entry(order).Reference(o => o.Tl).Load();

        _db.Orders.Add(order);
        _db.SaveChanges();

        return order;
    }

    public Order EditOrder(EditOrderDto editOrderDto)
    {
        var checklist = _db.Checklists.Single(x => x.Id == editOrderDto.ChecklistId);

        var order = _db.Orders.Include(x => x.Tl).Include(x => x.Cs).Include(x => x.Checklist).Single(x => x.Id == editOrderDto.Id);
        order.Approved = editOrderDto.Approved;
        order.Checklist = checklist;
        order.ChecklistId = editOrderDto.ChecklistId;
        order.Amount = editOrderDto.Amount;
        order.CreatedBy = editOrderDto.CreatedBy;
        order.CustomerName = editOrderDto.CustomerName;
        order.Status = editOrderDto.Status;

        order.LastUpdated = DateTime.Now;
        _db.SaveChanges();

        return order;
    }

    public Order DeleteOrder(int id)
    {
        var order = _db.Orders.Include(x => x.Tl).Include(x => x.Cs).Include(x => x.Checklist).Single(x => x.Id == id);

        _db.Orders.Remove(order);
        _db.SaveChanges();

        return order;
    }
}
