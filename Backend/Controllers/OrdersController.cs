using Backend.Dtos;
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
        return _orderService.GetAllOrders().Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("Customername")]
    public List<OrderDto> OrdersWithCustomername([FromQuery] string customername)
    {
        return _orderService.GetOrdersWithCustomername(customername).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("ApprovedByCs")]
    public List<OrderDto> GetOrdersWithApprovedByCs([FromQuery] bool approved)
    {
        return _orderService.GetOrdersWithApprovedByCs(approved).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("ApprovedByTl")]
    public List<OrderDto> GetOrdersWithApprovedByTl([FromQuery] bool approved)
    {
        return _orderService.GetOrdersWithApprovedByTl(approved).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("ApprovedByPpCs")]
    public List<OrderDto> GetOrdersWithApprovedByPpCs([FromQuery] bool approved)
    {
        return _orderService.GetOrdersWithApprovedByPpCs(approved)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpGet("ApprovedByPp")]
    public List<OrderDto> GetOrdersWithApprovedByPp([FromQuery] bool approved)
    {
        return _orderService.GetOrdersWithApprovedByPp(approved)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpGet("Amount")]
    public List<OrderDto> GetOrdersWithAmount([FromQuery] int amout)
    {
        return _orderService.GetOrdersWithAmount(amout).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("CreatedBy")]
    public List<OrderDto> GetOrdersWithCreatedBy([FromQuery] string createdBy)
    {
        return _orderService.GetOrdersWithCreatedBy(createdBy).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("Status")]
    public List<OrderDto> GetOrdersWithStatus([FromQuery] string status)
    {
        return _orderService.GetOrdersWithStatus(status).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("LastUpdated")]
    public List<OrderDto>? GetOrdersWithLastUpdatedAt([FromQuery] string lastUpdated)
    {
        var ordersWithLastUpdated = _orderService.GetOrdersWithLastUpdated(lastUpdated);
        if (ordersWithLastUpdated == null) return null;
        return ordersWithLastUpdated.Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("Country")]
    public List<OrderDto> GetOrdersWithCountry([FromQuery] string country)
    {
        return _orderService.GetOrdersWithCountry(country)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpGet("Sped")]
    public List<OrderDto> GetOrdersWithSped([FromQuery] string sped)
    {
        return _orderService.GetOrdersWithSped(sped)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpGet("{id}")]
    public OrderDto? OrderWithId(int id)
    {
        var orderedById = _orderService.GetOrderWithId(id);
        if (orderedById == null) return null;
        return ToOrderDto(orderedById);
    }

    [HttpPost]
    public OrderDto? Order(AddOrderDto addOrderDto)
    {
        var addedOrder = _orderService.AddOrder(addOrderDto);
        if (addedOrder == null) return null;
        return ToOrderDto(addedOrder);
    }

    [HttpPut]
    public OrderDto Order(EditOrderDto editOrderDto)
    {
        return ToOrderDto(_orderService.EditOrder(editOrderDto));
    }

    [HttpDelete]
    public OrderDto Order(int id)
    {
        return ToOrderDto(_orderService.DeleteOrder(id));
    }

    private static OrderDto ToOrderDto(Order order) => new()
    {
        Id = order.Id,
        AbNumber = order.Cs?.Abnumber ?? -1,
        Amount = order.Amount,
        ChecklistId = order.ChecklistId ?? -1,
        Country = order.Tl?.Country ?? "",
        CreatedBy = order.CreatedBy,
        Csid = order.CsId ?? -1,
        CustomerName = order.CustomerName,
        LastUpdated = order.LastUpdated.ToString("dd.MM.yyyy"),
        ReadyToLoad = order.Cs?.ReadyToLoad.ToString("dd.MM.yyyy") ?? "",
        Sped = order.Tl?.Sped ?? "",
        Status = order.Status,
        Tlid = order.TlId ?? -1,
        AdditionalInformation = order.AdditionalInformation,
        PpId = order.PpId ?? -1
    };
}
