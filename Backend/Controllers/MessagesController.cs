using Backend.Dtos;
using Backend.Services;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class MessagesController
{
    private readonly MessageService _messageService;
    public MessagesController(MessageService messageService) => _messageService = messageService;

    [HttpGet]
    public List<MessageDto> AllMessages(int id)
    {
        return _messageService.GetMessages(id);
    }

    [HttpPost]
    public MessageDto Message(AddMessageDto message)
    {
        return _messageService.PostMessage(message);
    }
}
