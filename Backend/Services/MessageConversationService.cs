using Backend.Dtos;
using ContainerToolDBDb;

namespace Backend.Services;


public class MessageConversationService
{
    private readonly ContainerToolDBContext _db;

    public MessageConversationService(ContainerToolDBContext db) => _db = db;

    public List<Message> GetMessagesForOrder(int id)
    {
        try
        {
            var conversation = _db.Orders.Where(x => x.Id == id).First();

            var messageIds = _db.MessageConversations.Where(x => x.OrderId == conversation.Id).Select(x => x.MessageId).ToList();

            var messages = new List<Message>();

            foreach (var currId in messageIds)
            {
                messages.Add(_db.Messages.Single(x => x.Id == currId));
            }

            return messages.OrderBy(x => x.DateTime).ToList();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Message>();
        }
       
    }

    public List<MessageConversation> GetMessageConversations()
    {
        return _db.MessageConversations.ToList();
    }

    public MessageConversation PostMessageForOrder(AddMessageConversationDto addMessageConversationDto)
    {
        var messageConversaion = new MessageConversation
        {
            MessageId = addMessageConversationDto.MessageId,
            OrderId = addMessageConversationDto.OrderId
        };

        _db.MessageConversations.Add(messageConversaion);
        _db.SaveChanges();

        return messageConversaion;
    }
}
