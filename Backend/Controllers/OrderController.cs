using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;
    public OrderController(OrderService orderService) => _orderService = orderService;

    [HttpGet("GetAllOrders")]
    public List<OrderDto> GetAllOrders()
    {
        return _orderService.GetAllOrders();
    }



}
