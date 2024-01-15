using Backend.Dtos;
using Backend.Services;
using Microsoft.VisualStudio.TextTemplating;
using TippsBackend.Services;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageConversationsController
    {
        private readonly MessageConversationService _messageConversationService;
        public MessageConversationsController(MessageConversationService messageConversationService) => _messageConversationService = messageConversationService;

        [HttpGet]
        public List<MessageConversationDto> MessageConversations()
        {
            return _messageConversationService.GetMessageConversations();
        }

        [HttpGet("{id}")]
        public List<MessageDto> MessageConversationForOrder(int id)
        {
            return _messageConversationService.GetMessagesForOrder(id);
        }

        [HttpPost]
        public MessageConversationDto MessageConversation(AddMessageConversationDto message)
        {
            return _messageConversationService.PostMessageForOrder(message);
        }
    }
}
