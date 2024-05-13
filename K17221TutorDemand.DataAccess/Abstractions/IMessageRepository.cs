using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IMessageRepository : IGenericRepository<Message>
{
    void CreateMessage(Message message);
}