using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public interface IMessagingService
    {
        Task<bool> SendMessage(string sender, string receiver, string messageData);
        List<string> ListMessages(string receiverName);
        void ReadMessage(string receiverName, string senderName);
    }
}
