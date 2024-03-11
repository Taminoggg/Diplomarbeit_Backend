using Backend.Dtos;
using ContainerToolDBDb;
using System.Net.Mail;

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
        var message = new Message();

        if (addMessageDto.AttachmentId != null)
        {
            var attachment = _db.Files.Single(x => x.Id == addMessageDto.AttachmentId);

            if (addMessageDto.Content != null)
            {
                message = new Message
                {
                    DateTime = DateTime.Now,
                    AttachmentId = addMessageDto.AttachmentId,
                    Content = addMessageDto.Content,
                    Attachment = attachment,
                    From = addMessageDto.From
                };
            }
            else
            {
                message = new Message
                {
                    DateTime = DateTime.Now,
                    AttachmentId = addMessageDto.AttachmentId,
                    Attachment = attachment,
                    Content = "",
                    From = addMessageDto.From
                };
            }
        }
        else
        {
            message = new Message
            {
                DateTime = DateTime.Now,
                Content = addMessageDto.Content!,
                From = addMessageDto.From
            };
        }  

        _db.Messages.Add(message);
        _db.SaveChanges();

        return message;
    }
}