using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;
    public OrdersController(OrderService orderService) => _orderService = orderService;

    [HttpGet]
    public List<OrderDto> AllOrders()
    {
        return _orderService.GetAllOrders();
    }

    [HttpGet("{id}")]
    public OrderDto OrderWithId(int id)
    {
        return _orderService.GetOrderWithId(id);
    }

    [HttpPost]
    public OrderDto Order(AddOrderDto addOrderDto)
    {
        return _orderService.AddOrder(addOrderDto);
    }

    [HttpPut]
    public OrderDto Order(EditOrderDto editOrderDto)
    {
        return _orderService.EditOrder(editOrderDto);
    }

    [HttpDelete]
    public OrderDto Order(int id)
    {
        return _orderService.DeleteOrder(id);
    }
}
