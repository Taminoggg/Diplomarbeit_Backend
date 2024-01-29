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
        return _orderService.GetAllOrders().Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("Customername")]
    public List<OrderDto> OrdersWithCustomername([FromQuery] string customername)
    {
        return _orderService.GetOrdersWithCustomername(customername).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("Approved")]
    public List<OrderDto> GetOrdersWithApproved([FromQuery] bool approved)
    {
        return _orderService.GetOrdersWithApproved(approved).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("Amount")]
    public List<OrderDto> GetOrdersWithAmount([FromQuery] int amout)
    {
        return _orderService.GetOrdersWithAmount(amout).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("CreatedBy")]
    public List<OrderDto> GetOrdersWithCreatedBy([FromQuery] string createdBy)
    {
        return _orderService.GetOrdersWithCreatedBy(createdBy).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("Status")]
    public List<OrderDto> GetOrdersWithStatus([FromQuery] int status)
    {
        return _orderService.GetOrdersWithStatus(status).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("LastUpdated")]
    public List<OrderDto> GetOrdersWithLastUpdatedAt([FromQuery] string lastUpdated)
    {
        return _orderService.GetOrdersWithLastUpdated(lastUpdated).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("Country")]
    public List<OrderDto> GetOrdersWithCountry([FromQuery] string country)
    {
        return _orderService.GetOrdersWithCountry(country).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("Sped")]
    public List<OrderDto> GetOrdersWithSped([FromQuery] string sped)
    {
        return _orderService.GetOrdersWithSped(sped).Select(x => new OrderDto
        {
            Id = x.Id,
            AbNumber = x.Cs.Abnumber,
            Amount = x.Amount,
            Approved = x.Approved,
            ArticleNumber = x.Cs.ArticleNumber,
            ChecklistId = x.ChecklistId,
            Country = x.Tl.Country,
            CreatedBy = x.CreatedBy,
            Csid = x.Csid,
            CustomerName = x.CustomerName,
            LastUpdated = x.LastUpdated.ToString("dd.MM.yyyy"),
            ReadyToLoad = x.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
            Sped = x.Tl.Sped,
            Status = x.Status,
            Tlid = x.Tlid
        })
        .ToList();
    }

    [HttpGet("{id}")]
    public OrderDto OrderWithId(int id)
    {
        try
        {
            var order = _orderService.GetOrderWithId(id);
            return new OrderDto
            {
                Id = order.Id,
                AbNumber = order.Cs.Abnumber,
                Amount = order.Amount,
                Approved = order.Approved,
                ArticleNumber = order.Cs.ArticleNumber,
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
        }catch (Exception ex)
        {
            return new OrderDto
            {
                Id = 0,
                AbNumber = 1,
                Amount = 1,
                Approved = false,
                ArticleNumber = "",
                ChecklistId = 1,
                Country = "",
                CreatedBy = "",
                Csid = 1,
                CustomerName = "",
                LastUpdated = "",
                ReadyToLoad = "",
                Sped = "",
                Status = 1,
                Tlid = 1
            };
        }
    }

    [HttpPost]
    public OrderDto Order(AddOrderDto addOrderDto)
    {
        var order = _orderService.AddOrder(addOrderDto);
        return new OrderDto
        {
            Id = order.Id,
            AbNumber = order.Cs.Abnumber,
            Amount = order.Amount,
            Approved = order.Approved,
            ArticleNumber = order.Cs.ArticleNumber,
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

    [HttpPut]
    public OrderDto Order(EditOrderDto editOrderDto)
    {
        var order = _orderService.EditOrder(editOrderDto);
        return new OrderDto
        {
            Id = order.Id,
            AbNumber = order.Cs.Abnumber,
            Amount = order.Amount,
            Approved = order.Approved,
            ArticleNumber = order.Cs.ArticleNumber,
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

    [HttpDelete]
    public OrderDto Order(int id)
    {
        var order = _orderService.DeleteOrder(id);
        return new OrderDto
        {
            Id = order.Id,
            AbNumber = order.Cs.Abnumber,
            Amount = order.Amount,
            Approved = order.Approved,
            ArticleNumber = order.Cs.ArticleNumber,
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
