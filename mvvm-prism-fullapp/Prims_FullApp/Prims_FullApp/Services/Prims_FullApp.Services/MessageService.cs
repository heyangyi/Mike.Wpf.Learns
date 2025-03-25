using Prims_FullApp.Services.Interfaces;

namespace Prims_FullApp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
