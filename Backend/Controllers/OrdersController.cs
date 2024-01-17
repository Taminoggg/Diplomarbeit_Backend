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

    [HttpGet("Customername")]
    public List<OrderDto> OrdersWithCustomername([FromQuery]string customername)
    {
        return _orderService.GetOrdersWithCustomername(customername);
    }

    [HttpGet("Approved")]
    public List<OrderDto> GetOrdersWithApproved([FromQuery] bool approved)
    {
        return _orderService.GetOrdersWithApproved(approved);
    }

    [HttpGet("Amount")]
    public List<OrderDto> GetOrdersWithAmount([FromQuery] int amout)
    {
        return _orderService.GetOrdersWithAmount(amout);
    }

    [HttpGet("CreatedBy")]
    public List<OrderDto> GetOrdersWithCreatedBy([FromQuery] string createdBy)
    {
        return _orderService.GetOrdersWithCreatedBy(createdBy);
    }

    [HttpGet("Status")]
    public List<OrderDto> GetOrdersWithStatus([FromQuery] int status)
    {
        return _orderService.GetOrdersWithStatus(status);
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
