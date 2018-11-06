using System;
using System.Collections.Generic;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public interface IMessageService
    {
        List<MessageView> GetMessages(Guid userid);
        void SendMessage(MessageView messageView);
        void SetReadedMessage(MessageView messageView);
    }
}