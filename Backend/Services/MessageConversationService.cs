using Backend.Dtos;
using ContainerToolDBDb;

namespace Backend.Services;


public class MessageConversationService
{
    private readonly ContainerToolDBContext _db;

    public MessageConversationService(ContainerToolDBContext db) => _db = db;

    public List<MessageDto> GetMessagesForOrder(int id)
    {
        var conversation = _db.Conversations.Where(x => x.OrderId == id).First();

        

        var messageIds = _db.MessageConversations.Where(x => x.ConversationId == conversation.Id).Select(x => x.MessageId).ToList();

        var messages = new List<Message>();

        Console.WriteLine("messageId length: | " + messageIds.Count);
        foreach (var currId in messageIds)
        {
            Console.WriteLine("messageIds: | " + currId);
            messages.Add(_db.Messages.Single(x => x.Id == currId));
        }

        return messages.Select(x => new MessageDto
        {
            Id = x.Id,
            DateTime = x.DateTime.ToString("dd.MM.yyyy"),
            AttachmentId = x.AttachmentId,
            Content = x.Content
        }).ToList();
    }

    public List<MessageConversationDto> GetMessageConversations()
    {
        return _db.MessageConversations.Select(x => new MessageConversationDto().CopyFrom(x)).ToList();
    }

    public MessageConversationDto PostMessageForOrder(AddMessageConversationDto addMessageConversationDto)
    {
        var messageConversaion = new MessageConversation
        {
            MessageId = addMessageConversationDto.MessageId,
            ConversationId = addMessageConversationDto.ConversationId
        };

        _db.MessageConversations.Add(messageConversaion);
        _db.SaveChanges();

        return new MessageConversationDto
        {
            MessageId= addMessageConversationDto.MessageId,
            ConversationId= addMessageConversationDto.ConversationId,
            Id = messageConversaion.Id
        };
    }
}
