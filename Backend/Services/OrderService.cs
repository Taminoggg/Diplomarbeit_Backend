using Backend.Dtos;
using Backend.Services;
using ContainerToolDB;
using ContainerToolDBDb;
using System.Globalization;
using System.Linq;

namespace TippsBackend.Services;

public class OrderService
{
    private readonly ContainerToolDBContext _db;

    public OrderService(ContainerToolDBContext db)
    {
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

    public List<Order> GetOrdersWithApprovedByCs(bool approved)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Cs!.ApprovedByCrCs == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithApprovedByTl(bool approved)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Tl!.ApprovedByCrTl == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithApprovedByPpCs(bool approved)
    {
        return _db.Orders
            .Include(x => x.ProductionPlanning)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.ProductionPlanning!.ApprovedByPpCs == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithApprovedByPp(bool approved)
    {
        return _db.Orders
            .Include(x => x.ProductionPlanning)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.ProductionPlanning!.ApprovedByPpPp == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithCreatedBy(string createdBy)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.CreatedByCS.ToLower().Contains(createdBy.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithCountry(string country)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(y => _db.Csinquiries.Single(x => x.Id == y.Id).Country.ToLower().Contains(country.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithSped(string sped)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(y => _db.Tlinquiries.Single(x => x.Id == y.TlId).Sped.ToLower().Contains(sped.ToLower()))
            .ToList();
    }

    public List<Order>? GetOrdersWithLastUpdated(string date)
    {
        try
        {
            DateTime parsedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return _db.Orders
                .Include(x => x.Tl)
                .Include(x => x.Cs)
                .Include(x => x.Checklist)
                .OrderBy(x => x.Id)
                .AsEnumerable()
                .Where(x => (x.LastUpdatedOn.Date - parsedDate.Date).Days == 0)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
    }


    public List<Order> GetOrdersWithStatus(string status)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Status.ToLower().Contains(status.ToLower()))
            .ToList();
    }

    public Order? GetOrderWithId(int id)
    {
        try
        {
            Order order = _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .Single(x => x.Id == id);

            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    public List<Order> GetOrdersOrderedBySped(OrderOrdersDto orderOrdersDto)
    {        
        var ordersToOrder = new List<Order>();
        foreach (int orderId in orderOrdersDto.OrderIds)
        {
            ordersToOrder.Add(_db.Orders.Include(x => x.Cs).Include(x => x.Tl).Single(x => x.Id == orderId));
        }
        if (orderOrdersDto.Asc) return ordersToOrder.OrderBy(x => x.Tl?.Sped ?? "").ToList();
        return ordersToOrder.OrderByDescending(x => x.Tl?.Sped ?? "").ToList();
    }

    public List<Order> GetOrdersOrderedByReadyToLoad(OrderOrdersDto orderOrdersDto)
    {
        var ordersToOrder = new List<Order>();
        foreach (int orderId in orderOrdersDto.OrderIds)
        {
            ordersToOrder.Add(_db.Orders.Include(x => x.Cs).Include(x => x.Tl).Single(x => x.Id == orderId));
        }
        if (orderOrdersDto.Asc) return ordersToOrder.OrderBy(x => x.Cs?.ReadyToLoad ?? DateTime.Now).ToList();
        return ordersToOrder.OrderByDescending(x => x.Cs?.ReadyToLoad ?? DateTime.Now).ToList();
    }

    public List<Order> GetOrdersOrderedByCountry(OrderOrdersDto orderOrdersDto)
    {
        var ordersToOrder = new List<Order>();
        foreach (int orderId in orderOrdersDto.OrderIds)
        {
            ordersToOrder.Add(_db.Orders.Include(x => x.Cs).Include(x => x.Tl).Single(x => x.Id == orderId));
        }
        if (orderOrdersDto.Asc) return ordersToOrder.OrderBy(x => x.Cs?.Country ?? "").ToList();
        return ordersToOrder.OrderByDescending(x => x.Cs?.Country ?? "").ToList();
    }

    public List<Order> GetOrdersOrderedByAbNumber(OrderOrdersDto orderOrdersDto)
    {
        var ordersToOrder = new List<Order>();
        foreach (int orderId in orderOrdersDto.OrderIds)
        {
            ordersToOrder.Add(_db.Orders.Include(x => x.Cs).Include(x => x.Tl).Single(x => x.Id == orderId));
        }
        if (orderOrdersDto.Asc) return ordersToOrder.OrderBy(x => x.Cs?.Abnumber ?? 0).ToList();
        return ordersToOrder.OrderByDescending(x => x.Cs?.Abnumber ?? 0).ToList();
    }

    public Order? AddOrder(AddOrderDto addOrderDto)
    {
        try
        {
            Console.WriteLine("posting Order");
            Checklist? checklist = null;
            Csinquiry? cs = null;
            Tlinquiry? tl = null;
            ProductionPlanning? pp = null;
            int? csId = addOrderDto.CsId;
            int? checklistId = addOrderDto.ChecklistId;
            int? tlId = addOrderDto.TlId;
            int? ppId = addOrderDto.PpId;

            if (addOrderDto.CsId > 0 && addOrderDto.TlId > 0)
            {
                cs = _db.Csinquiries.Single(x => x.Id == addOrderDto.CsId);
                tl = _db.Tlinquiries.Single(x => x.Id == addOrderDto.TlId);
                checklist = _db.Checklists.Single(x => x.Id == addOrderDto.ChecklistId);

                ppId = null;
            }
            else if(addOrderDto.PpId > 0)
            {
                pp = _db.ProductionPlannings.Single(x => x.Id == addOrderDto.PpId);

                csId = null;
                tlId = null;
                checklistId = null;
            }
            else
            {
                return null;
            }

            var order = new Order
            {
                Checklist = checklist,
                ChecklistId = checklistId,
                CreatedByCS = addOrderDto.CreatedBy,
                Cs = cs,
                Tl = tl,
                CreatedBySD = "",
                CsId = csId,
                CustomerName = addOrderDto.CustomerName,
                LastUpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                Status = "cs-in-progress",
                TlId = tlId,
                FinishedOn = null,
                AdditionalInformation = addOrderDto.AdditionalInformation,
                PpId = ppId,
                ProductionPlanning = pp
            };
            Console.WriteLine(order);

            _db.Orders.Add(order);
            _db.SaveChanges();

            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Order SetOrderSuccessfullyFinished(EditStatusDto statusDto)
    {
        var order = _db.Orders.Single(x => x.Id == statusDto.Id);
        order.SuccessfullyFinished = statusDto.Status;
        order.FinishedOn = DateTime.Now;
        _db.SaveChanges();
        return order;
    }

    public Order SetOrderCanceled(EditStatusDto statusDto)
    {
        var order = _db.Orders.Single(x => x.Id == statusDto.Id);
        order.Canceled = statusDto.Status;
        order.FinishedOn = DateTime.Now;
        _db.SaveChanges();
        return order;
    }

    public Order SetOrderStatus(EditOrderStatusDto editOrderStatusDto)
    {
        var order = _db.Orders.Single(x => x.Id == editOrderStatusDto.Id);
        order.Status = editOrderStatusDto.Status;
        _db.SaveChanges();
        return order;
    }

    public Order EditOrderCS(EditOrderCSDto editOrderDto)
    {
        var order = _db.Orders.Include(x => x.ProductionPlanning).Include(x => x.Tl).Include(x => x.Cs).Include(x => x.Checklist).Single(x => x.Id == editOrderDto.Id);
        order.CreatedByCS = editOrderDto.CreatedBy;
        order.CustomerName = editOrderDto.CustomerName;
        order.AdditionalInformation = editOrderDto.AdditionalInformation;
        order.LastUpdatedOn = DateTime.Now;
        _db.SaveChanges();

        return order;
    }

    public Order EditOrderSD(EditOrderSDDto editOrderDto)
    {
        var order = _db.Orders.Include(x => x.ProductionPlanning).Include(x => x.Tl).Include(x => x.Cs).Include(x => x.Checklist).Single(x => x.Id == editOrderDto.Id);
        order.CreatedBySD = editOrderDto.CreatedBy;
        order.AdditionalInformation = editOrderDto.AdditionalInformation;
        order.LastUpdatedOn = DateTime.Now;
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
