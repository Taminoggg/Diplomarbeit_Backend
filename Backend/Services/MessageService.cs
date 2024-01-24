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
        return _db.Messages
            .Where(x => getAll || x.Id == id)
            .Select(x => new MessageDto
            {
                Id = x.Id,
                DateTime = x.DateTime.ToString("dd.MM.yyyy"),
                AttachmentId = x.AttachmentId,
                Content = x.Content
            })
            .ToList();
    }

    public MessageDto PostMessage(AddMessageDto addMessageDto)
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

        return new MessageDto
        {
            DateTime = message.DateTime.ToString("dd.MM.yyyy"),
            AttachmentId = message.AttachmentId,
            Content = message.Content,
            Id = message.Id
        };
    }
}