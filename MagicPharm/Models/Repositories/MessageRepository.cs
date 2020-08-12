using MagicPharm.Models.Context;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Create(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Message message = Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }

        public Message Find(Guid id)
        {
            return _context.Messages.AsNoTracking().SingleOrDefault(m => m.Id == id);
        }

        public IList<Message> GetAll()
        {
            return _context.Messages.AsNoTracking().ToList();
        }
    }
}
