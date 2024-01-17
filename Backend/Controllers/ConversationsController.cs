using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class ConversationsController : ControllerBase
{
    private readonly ConversationService _conversationService;
    public ConversationsController(ConversationService conversationService) => _conversationService = conversationService;

    [HttpGet]
    public List<ConversationDto> AllConversations(int id)
    {
        return _conversationService.GetConversations(id);
    }

    [HttpGet("{orderId}")]
    public ConversationDto ConversationForOrder(int orderId)
    {
        return _conversationService.ConversatoinForOrder(orderId);
    }

    [HttpPost]
    public ConversationDto Conversation(int id)
    {
        return _conversationService.AddConversation(id);
    }

    [HttpDelete]
    public ConversationDto ConversationDel(int id)
    {
        return _conversationService.DeleteConversaion(id);
    }
}
