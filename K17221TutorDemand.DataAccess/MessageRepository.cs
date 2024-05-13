using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.DataAccess;

public class MessageRepository : GenericRepository<Message>, IMessageRepository
{
    public MessageRepository(TutorDemandDbContext context) : base(context)
    {
    }

    public void CreateMessage(Message message)
    {
        Create(message);
    }
}