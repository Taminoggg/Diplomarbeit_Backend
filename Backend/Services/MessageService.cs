using Backend.Dtos;
using ContainerToolDBDb;

namespace Backend.Services;

public class MessageService
{
    private readonly ContainerToolDBContext _db;

    public MessageService(ContainerToolDBContext db) => _db = db;

    public List<Message> GetMessages(int id)
    {
        var getAll = false;
        if (id == 0) getAll = true;
        return _db.Messages
            .Where(x => getAll || x.Id == id)
            .ToList();
    }

    public Message PostMessage(AddMessageDto addMessageDto)
    {
        var attachment = _db.Files.Single(x => x.Id == addMessageDto.AttachmentId);

        var message = new Message
        {
            DateTime = DateTime.Now,
            AttachmentId = addMessageDto.AttachmentId,
            Content = addMessageDto.Content,
            Attachment = attachment
        };

        _db.Messages.Add(message);
        _db.SaveChanges();

        return message;
    }
}