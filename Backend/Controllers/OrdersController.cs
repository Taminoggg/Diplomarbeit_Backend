using Backend.Dtos;
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
        return _orderService.GetAllOrders().Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("Customername")]
    public List<OrderDto> OrdersWithCustomername([FromQuery] string customername)
    {
        return _orderService.GetOrdersWithCustomername(customername).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("Approved")]
    public List<OrderDto> GetOrdersWithApproved([FromQuery] bool approved)
    {
        return _orderService.GetOrdersWithApproved(approved).Select(x => ToOrderDto(x))
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
    public List<OrderDto> GetOrdersWithLastUpdatedAt([FromQuery] string lastUpdated)
    {
        return _orderService.GetOrdersWithLastUpdated(lastUpdated).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("Country")]
    public List<OrderDto> GetOrdersWithCountry([FromQuery] string country)
    {
        return _orderService.GetOrdersWithCountry(country).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("Sped")]
    public List<OrderDto> GetOrdersWithSped([FromQuery] string sped)
    {
        return _orderService.GetOrdersWithSped(sped).Select(x => ToOrderDto(x))
        .ToList();
    }

    [HttpGet("{id}")]
    public OrderDto OrderWithId(int id)
    {
        try
        {
            return ToOrderDto(_orderService.GetOrderWithId(id));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new OrderDto
            {
                Id = 0,
                AbNumber = 1,
                Amount = 1,
                ApprovedByCs = false,
                ApprovedByTs = false,
                ChecklistId = 1,
                Country = "",
                CreatedBy = "",
                Csid = 1,
                CustomerName = "",
                LastUpdated = "",
                ReadyToLoad = "",
                Sped = "",
                Status = "",
                Tlid = 1
            };
        }
    }

    [HttpPost]
    public OrderDto Order(AddOrderDto addOrderDto)
    {
        return _orderService.AddOrder(addOrderDto);
    }

    [HttpPut("ApprovedByCs")]
    public OrderDto? ApprovedByCs(EditApproveOrderDto editApproveOrderDto)
    {
        if (_orderService.ApproveCs(editApproveOrderDto) == null) return null;
        return ToOrderDto(_orderService.ApproveCs(editApproveOrderDto)!);
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

    private static OrderDto ToOrderDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            AbNumber = order.Cs.Abnumber,
            Amount = order.Amount,
            ApprovedByCs = order.ApprovedByCs,
            ApprovedByTs = order.ApprovedByTs,
            ChecklistId = order.ChecklistId,
            Country = order.Tl.Country,
            CreatedBy = order.CreatedBy,
            Csid = order.Csid,
            CustomerName = order.CustomerName,
            LastUpdated = order.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = order.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = order.Tl.Sped,
            Status = order.Status,
            Tlid = order.Tlid
        };
    }
}
