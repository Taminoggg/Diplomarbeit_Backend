using Backend;

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
}
