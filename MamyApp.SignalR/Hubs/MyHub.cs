using Microsoft.AspNetCore.SignalR;

public class MyHub : Hub
{
    // A method that clients can call
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
