using MagicPharm.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Repositories.interfaces
{
    public interface IMessageRepository
    {
        public IList<Message> GetAll();
        public Message Find(Guid id);
        public void Delete(Guid id);
        public void Create(Message message);
    }
}
