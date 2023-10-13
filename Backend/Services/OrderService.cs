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

    public OrderDto GetOrdersWithId(int id)
    {
        Order order = _db.Orders
            .Single(x => x.Id == id);

        return new OrderDto
        {
            Id = order.Id,
            Amount = order.Amount,
            Approved = order.Approved,
            ChecklistId = order.ChecklistId,
            CreatedBy = order.CreatedBy,
            Csid = order.Csid,
            CustomerName = order.CustomerName,
            LastUpdated = order.LastUpdated,
            Status = order.Status,
            Tlid = order.Tlid
        };
    }

    public OrderDto AddOrderDto(AddOrderDto addOrderDto)
    {
        var order = new Order
        {
            Amount = addOrderDto.Amount,
            Approved = addOrderDto.Approved,
            ChecklistId = addOrderDto.ChecklistId,
            CreatedBy = addOrderDto.CreatedBy,
            Csid = addOrderDto.Csid,
            CustomerName = addOrderDto.CustomerName,
            LastUpdated = addOrderDto.LastUpdated,
            Status = addOrderDto.Status,
            Tlid = addOrderDto.Tlid
        };

        _db.Orders.Add(order);
        _db.SaveChanges();

        return new OrderDto
        {
            Id = order.Id,
            Amount = order.Amount,
            Approved = order.Approved,
            ChecklistId = order.ChecklistId,
            CreatedBy = order.CreatedBy,
            Csid = order.Csid,
            CustomerName = order.CustomerName,
            LastUpdated = order.LastUpdated,
            Status = order.Status,
            Tlid = order.Tlid
        };
    }

    public OrderDto DeleteOrder(int id)
    {
        var order = _db.Orders.Single(x=> x.Id == id);

        _db.Orders.Remove(order);
        _db.SaveChanges();

        return new OrderDto
        {
            Id = order.Id,
            Amount = order.Amount,
            Approved = order.Approved,
            ChecklistId = order.ChecklistId,
            CreatedBy = order.CreatedBy,
            Csid = order.Csid,
            CustomerName = order.CustomerName,
            LastUpdated = order.LastUpdated,
            Status = order.Status,
            Tlid = order.Tlid
        };
    }
}
