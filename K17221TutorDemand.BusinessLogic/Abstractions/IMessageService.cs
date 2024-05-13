using K17221TutorDemand.Models.Dtos.Message;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IMessageService
{
    Task CreateMessage(MessageCreationDto messageDto);
}