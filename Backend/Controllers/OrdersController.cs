using Backend.Dtos;
using Backend.Services;
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

    [HttpGet("Sped")]
    public List<OrderDto> GetOrdersWithSped([FromQuery] string sped)
    {
        return _orderService.GetOrdersWithSped(sped)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpPut("OrderedBySped")]
    public List<OrderDto> GetOrdersOrderedBySped(OrderOrdersDto orderOrdersDto)
    {
        return _orderService.GetOrdersOrderedBySped(orderOrdersDto)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpPut("OrderedByCountry")]
    public List<OrderDto> GetOrdersOrderedByCountry(OrderOrdersDto orderOrdersDto)
    {
        return _orderService.GetOrdersOrderedByCountry(orderOrdersDto)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpPut("OrderedByAbnumber")]
    public List<OrderDto> GetOrdersOrderedByAbnumber(OrderOrdersDto orderOrdersDto)
    {
        return _orderService.GetOrdersOrderedByAbNumber(orderOrdersDto)
            .Select(x => ToOrderDto(x))
            .ToList();
    }

    [HttpPut("OrderedByReadyToLoad")]
    public List<OrderDto> GetOrdersOrderedByReadyToLoad(OrderOrdersDto orderOrdersDto)
    {
        return _orderService.GetOrdersOrderedByReadyToLoad(orderOrdersDto)
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

    [HttpPut("SuccessfullyFinished")]
    public OrderDto SetSuccessfullyFinishedForOrder(EditStatusDto statusDto)
    {
        return ToOrderDto(_orderService.SetOrderSuccessfullyFinished(statusDto));
    }

    [HttpPut("Cancel")]
    public OrderDto SetCancelForOrder(EditStatusDto statusDto)
    {
        return ToOrderDto(_orderService.SetOrderCanceled(statusDto));
    }

    [HttpPut("Status")]
    public OrderDto SetOrderStatus(EditOrderStatusDto editOrderStatusDto)
    {
        return ToOrderDto(_orderService.SetOrderStatus(editOrderStatusDto));
    }

    [HttpPut("OrderCS")]
    public OrderDto OrderCS(EditOrderCSDto editOrderDto)
    {
        return ToOrderDto(_orderService.EditOrderCS(editOrderDto));
    }

    [HttpPut("OrderSD")]
    public OrderDto OrderSD(EditOrderSDDto editOrderDto)
    {
        return ToOrderDto(_orderService.EditOrderSD(editOrderDto));
    }

    [HttpDelete]
    public OrderDto Order(int id)
    {
        return ToOrderDto(_orderService.DeleteOrder(id));
    }

    private static OrderDto ToOrderDto(Order order) => new()
    {
        Id = order.Id,
        ChecklistId = order.ChecklistId ?? -1,
        CreatedByCS = order.CreatedByCS,
        CreatedBySD = order.CreatedBySD,
        Csid = order.CsId ?? -1,
        CustomerName = order.CustomerName,
        LastUpdated = order.LastUpdatedOn.ToString("yyyy-MM-dd"),
        CreatedOn = order.CreatedOn.ToString("yyyy-MM-dd"),
        FinishedOn = order.FinishedOn?.ToString("yyyy-MM-dd") ?? "",
        Status = order.Status,
        Tlid = order.TlId ?? -1,
        AdditionalInformation = order.AdditionalInformation,
        PpId = order.PpId ?? -1,
        Canceled = order.Canceled,
        SuccessfullyFinished = order.SuccessfullyFinished
    };
}
