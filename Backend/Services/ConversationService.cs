using ContainerToolDBDb;

namespace TippsBackend.Services;

public class ConversationService
{
    private readonly ContainerToolDBContext _db;

    public ConversationService(ContainerToolDBContext db) => _db = db;

    public List<ConversationDto> GetConversations(int id)
    {
        bool getAll = false;
        if(id == 0) getAll = true;
        return _db.Conversations
            .Where(x => getAll | x.Id == id)
            .Select(x => new ConversationDto().CopyFrom(x))
            .ToList();
    }

    public ConversationDto ConversatoinForOrder(int id)
    {
        try
        {
            var conversation = _db.Conversations.Single(x => x.OrderId == id);
            return new ConversationDto()
            {
                OrderId = conversation.OrderId,
                Id = conversation.Id
            };
        }
        catch (Exception ex)
        {
            return new ConversationDto { OrderId = 0, Id = 0 };
        }
    }
    public ConversationDto AddConversation(int id)
    {
        var order = _db.Orders.Single(x => x.Id == id); 
        var conversation = new Conversation { OrderId = id, Order = order };

        _db.Conversations.Add(conversation);
        _db.SaveChanges();

        return new ConversationDto().CopyFrom(conversation);
    }

    public ConversationDto DeleteConversaion(int id)
    {
        try
        {
            var conversation = _db.Conversations.Single(x => x.Id == id);

            _db.Conversations.Remove(conversation);
            _db.SaveChanges();

            return new ConversationDto().CopyFrom(conversation);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
    }
}
