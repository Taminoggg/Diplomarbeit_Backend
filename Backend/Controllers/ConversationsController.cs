using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class ConversationsController : ControllerBase
{
    private readonly ConversationService _conversationService;
    public ConversationsController(ConversationService conversationService) => _conversationService = conversationService;

    [HttpGet]
    public List<ConversationDto> AllConversations()
    {
        return _conversationService.GetAllConversations();
    }

    [HttpGet("{id}")]
    public ConversationDto ConversationWithId(int id)
    {
        return _conversationService.GetConersationWithId(id);
    }

    [HttpPost]
    public ConversationDto Conversation(AddConversationDto addConversationDto)
    {
        return _conversationService.AddConversation(addConversationDto);
    }

    [HttpDelete]
    public ConversationDto Conversation(int id)
    {
        return _conversationService.DeleteConversaion(id);
    }
}
