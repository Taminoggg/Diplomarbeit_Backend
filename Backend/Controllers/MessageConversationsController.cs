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
        public List<MessageConversation> MessageConversations()
        {
            return _messageConversationService.GetMessageConversations()
                .ToList();
        }

        [HttpGet("{conversationId}")]
        public List<MessageDto> MessageConversationForOrder(int conversationId)
        {
            return _messageConversationService.GetMessagesForOrder(conversationId)
                .Select(x => new MessageDto
                {
                    Id = x.Id,
                    DateTime = x.DateTime.ToString("dd.MM.yyyy HH:mm"),
                    AttachmentId = x.AttachmentId ?? 0,
                    Content = x.Content,
                    From = x.From
                })
                .ToList();
        }

        [HttpPost]
        public MessageConversationDto MessageConversation(AddMessageConversationDto message)
        {
            return new MessageConversationDto().CopyFrom(_messageConversationService.PostMessageForOrder(message));
        }
    }
}
