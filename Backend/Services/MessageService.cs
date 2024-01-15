using Backend.Dtos;
using ContainerToolDBDb;

namespace Backend.Services;

public class MessageService
{
    private readonly ContainerToolDBContext _db;

    public MessageService(ContainerToolDBContext db) => _db = db;

    public List<MessageDto> GetMessages(int id)
    {
        var getAll = false;
        if (id == 0) getAll = true;
        return _db.Messages.Where(x => getAll || x.Id == id).Select(x => new MessageDto().CopyFrom(x)).ToList();
    }

    public MessageDto PostMessage(AddMessageDto addMessageDto)
    {
        var message = new Message
        {
            DateTime = DateTime.ParseExact(addMessageDto.DateTime, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
            AttachmentId = addMessageDto.AttachmentId,
            Content = addMessageDto.Content
        };

        _db.Messages.Add(message);
        _db.SaveChanges();
       
        return new MessageDto
        {
            DateTime = message.DateTime.ToString("dd.MM.yyyy"),
            AttachmentId = message.AttachmentId,
            Content= message.Content,
            Id = message.Id
        };
    }
}