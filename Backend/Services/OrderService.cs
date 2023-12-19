namespace TippsBackend.Services;

public class OrderService
{
    private readonly ContainerToolDBContext _db;

    public OrderService(ContainerToolDBContext db) => _db = db;

    public List<OrderDto> GetAllOrders()
    {
        return _db.Orders
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    public OrderDto GetOrderWithId(int id)
    {
        Order order = _db.Orders
            .Single(x => x.Id == id);

        return new OrderDto().CopyFrom(order);
    }

    public OrderDto AddOrder(AddOrderDto addOrderDto)
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

        return new OrderDto().CopyFrom(order);
    }

    public OrderDto EditOrder(EditOrderDto editOrderDto)
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

        return new OrderDto().CopyFrom(order);
    }

    public OrderDto DeleteOrder(int id)
    {
        var order = _db.Orders.Single(x=> x.Id == id);

        _db.Orders.Remove(order);
        _db.SaveChanges();

        return new OrderDto().CopyFrom(order);
    }
}
