using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VuetifySpa.Data.Model;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public class MessageService : IMessageService
    {
        private MyDbContext _db;
        
        public MessageService(MyDbContext db)
        {
            _db = db;
        }

        public List<MessageView> GetMessages(Guid userid)
        {
           return _db.Messages.Where(x => x.ToId == userid).AsNoTracking()
                .OrderByDescending(x => x.IsReaded)
                .ThenByDescending(x => x.CreatedAt)
                .ToList().Select(x => GetFrom(x)).ToList();
        }

        public void SendMessage(MessageView messageView)
        {
            var message = GetFrom(messageView);
            _db.Messages.Add(message);
            _db.SaveChanges();
        }

        public void SetReadedMessage(MessageView messageView)
        {
           var message= _db.Messages.SingleOrDefault(x => x.Id == messageView.Id);
            if (message != null)
            {
                message.IsReaded = messageView.IsReaded;
                _db.Messages.Update(message);
                _db.SaveChanges();
            }
        }



        private MessageView GetFrom(Message message)
        {
            return new MessageView
            {
                Id = message.Id,
                ToId =message.ToId,
                Title = message.Title,
                Text = message.Text,
                FromId = message.FromUser.Id,
                FromFio = string.Format("{0}", message.FromUser.FirstName, message.FromUser.LastName),
                FromAvatarUrl = message.FromUser.Avatar,
                CreatedAt = message.CreatedAt,
                IsReaded = message.IsReaded
            };
        }

        private Message GetFrom(MessageView message)
        {
            return new Message
            {
                ToId = message.ToId,
                FromUserId = message.FromId,
                Text = message.Text,
                Title = message.Title,             
                CreatedAt = message.CreatedAt,
                IsReaded = message.IsReaded
            };
        }
    }
}
