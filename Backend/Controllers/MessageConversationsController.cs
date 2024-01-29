using Backend.Dtos;
using Backend.Services;
using ContainerToolDBDb;
using Microsoft.VisualStudio.TextTemplating;
using TippsBackend.Services;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageConversationsController : ControllerBase
    {
        private readonly MessageConversationService _messageConversationService;
        public MessageConversationsController(MessageConversationService messageConversationService) => _messageConversationService = messageConversationService;

        [HttpGet]
        public List<MessageConversationDto> MessageConversations()
        {
            return _messageConversationService.GetMessageConversations();
        }

        [HttpGet("{conversationId}")]
        public List<MessageDto> MessageConversationForOrder(int conversationId)
        {
            return _messageConversationService.GetMessagesForConversation(conversationId);
        }

        [HttpPost]
        public MessageConversationDto MessageConversation(AddMessageConversationDto message)
        {
            return _messageConversationService.PostMessageForOrder(message);
        }
    }
}
