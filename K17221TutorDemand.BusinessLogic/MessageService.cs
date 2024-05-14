using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Dtos.Message;
using K17221TutorDemand.Models.Entities;
using Mapster;

namespace K17221TutorDemand.BusinessLogic;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateMessage(MessageCreationDto messageDto)
    {
        var message = messageDto.Adapt<Message>();
        _unitOfWork.Message.Create(message); 
        await _unitOfWork.SaveAsync();
    }
}