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

    public List<OrderDto> GetAllOrders()
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<OrderDto> GetOrdersWithCustomername(string customerName)
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Where(x => x.CustomerName.ToLower().Contains(customerName.ToLower()))
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<OrderDto> GetOrdersWithApproved(bool approved)
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Where(x => x.Approved == approved)
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<OrderDto> GetOrdersWithAmount(int amount)
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Where(x => x.Amount == amount)
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<OrderDto> GetOrdersWithCreatedBy(string createdBy)
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Where(x => x.CreatedBy.ToLower().Contains(createdBy.ToLower()))
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<OrderDto> GetOrdersWithCountry(string country)
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Where(y => _db.Tlinquiries.Single(x => x.Id == y.Tlid).Country.ToLower().Contains(country.ToLower()))
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<OrderDto> GetOrdersWithSped(string sped)
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Where(y => _db.Tlinquiries.Single(x => x.Id == y.Tlid).Sped.ToLower().Contains(sped.ToLower()))
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<OrderDto> GetOrdersWithLastUpdated(string date)
    {
        try
        {
            return _db.Orders
            .OrderBy(x => x.Id)
            .Where(x => EF.Functions.DateDiffDay(x.LastUpdated, DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)) == 0)
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new List<OrderDto>();
        }
    }

    public List<OrderDto> GetOrdersWithStatus(int status)
    {
        return _db.Orders
            .OrderBy(x => x.Id)
            .Where(x => x.Status == status)
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public List<Order> GetOrdersSortedBySpedAsc(string orderIdString)
    {
        string[] idStrings = orderIdString.Split(',');
        int[] orderIds = idStrings.Select(int.Parse).ToArray();
        var allOrders = new List<Order>();

        foreach (int id in orderIds)
        {
            var order = _db.Orders
            .Include(x => x.Tl)
            .SingleOrDefault(x => x.Id == id);

            if (order != null)
            {
                allOrders.Add(order);
            }
        }

        return allOrders
        .OrderBy(x => x.Tl.Sped)
            .ToList();
    }

    public List<Order> GetOrdersSortedBySpedDec(string orderIdString)
    {
        string[] idStrings = orderIdString.Split(',');
        int[] orderIds = idStrings.Select(int.Parse).ToArray();
        var allOrders = new List<Order>();

        foreach (int id in orderIds)
        {
            var order = _db.Orders
            .Include(x => x.Tl)
            .SingleOrDefault(x => x.Id == id);

            if (order != null)
            {
                allOrders.Add(order);
            }
        }

        return allOrders
        .OrderByDescending(x => x.Tl.Sped)
            .ToList();
    }

    public string GetDispatchDateForOrder(int id)
    {
        var order = _db.Orders.Single(x => x.Id == id);

        return order.Tl.ExpectedRetrieveWeek.ToString("dd.MM.yyyy");
    }

    public Order GetOrderWithId(int id)
    {
        Order order = _db.Orders
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

        _db.Orders.Add(order);
        _db.SaveChanges();

        return order;
    }

    public Order EditOrder(EditOrderDto editOrderDto)
    {
        var checklist = _db.Checklists.Single(x => x.Id == editOrderDto.ChecklistId);

        var order = _db.Orders.Single(x => x.Id == editOrderDto.Id);
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
        var order = _db.Orders.Single(x => x.Id == id);

        _db.Orders.Remove(order);
        _db.SaveChanges();

        return order;
    }
}
