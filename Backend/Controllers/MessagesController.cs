using Backend.Dtos;
using Backend.Services;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly MessageService _messageService;
    public MessagesController(MessageService messageService) => _messageService = messageService;

    [HttpGet]
    public List<MessageDto> AllMessages(int id)
    {
        return _messageService.GetMessages(id).Select(x => ToMessageDto(x)).ToList();
        
    }

    [HttpPost]
    public MessageDto Message(AddMessageDto addMessageDto)
    {
        return ToMessageDto(_messageService.PostMessage(addMessageDto));
    }

    private static MessageDto ToMessageDto(Message message)
    {
        return new MessageDto
        {
            Id = message.Id,
            DateTime = message.DateTime.ToString("yyyy-MM-dd"),
            AttachmentId = message.AttachmentId ?? 0,
            Content = message.Content,
            From = message.From
        };
    }
}
