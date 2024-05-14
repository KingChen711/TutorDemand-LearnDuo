using Microsoft.AspNetCore.SignalR;

namespace K17221TutorDemand.WebApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}