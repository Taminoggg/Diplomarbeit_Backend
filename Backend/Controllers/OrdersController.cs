using ContainerToolDBDb;
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
    public List<OrderDto> OrdersWithCustomername([FromQuery] string customername)
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

    [HttpGet("LastUpdated")]
    public List<OrderDto> GetOrdersWithLastUpdatedAt([FromQuery] string lastUpdated)
    {
        return _orderService.GetOrdersWithLastUpdated(lastUpdated);
    }

    [HttpGet("Country")]
    public List<OrderDto> GetOrdersWithCountry([FromQuery] string country)
    {
        return _orderService.GetOrdersWithCountry(country);
    }

    [HttpGet("Sped")]
    public List<OrderDto> GetOrdersWithSped([FromQuery] string sped)
    {
        return _orderService.GetOrdersWithSped(sped);
    }

    [HttpGet("TEST")]
    public string Test(string orderIds)
    {
        return orderIds.Split(",")[0].ToString();
    }

    [HttpGet("AscSped")]
    public List<OrderDto> GetOrdersSortedBySpedAsc(string orderIds)
    {
        return _orderService.GetOrdersSortedBySpedAsc(orderIds)
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    [HttpGet("DecSped")]
    public List<OrderDto> GetOrdersSortedBySpedDec(string orderIds)
    {
        return _orderService.GetOrdersSortedBySpedDec(orderIds)
            .Select(x => new OrderDto().CopyFrom(x))
            .ToList();
    }

    [HttpGet("{id}")]
    public OrderDto OrderWithId(int id)
    {
        return new OrderDto().CopyFrom(_orderService.GetOrderWithId(id));
    }

    [HttpPost]
    public OrderDto Order(AddOrderDto addOrderDto)
    {
        return new OrderDto().CopyFrom(_orderService.AddOrder(addOrderDto));
    }

    [HttpPut]
    public OrderDto Order(EditOrderDto editOrderDto)
    {
        return new OrderDto().CopyFrom(_orderService.EditOrder(editOrderDto));
    }

    [HttpDelete]
    public OrderDto Order(int id)
    {
        return new OrderDto().CopyFrom(_orderService.DeleteOrder(id));
    }
}
