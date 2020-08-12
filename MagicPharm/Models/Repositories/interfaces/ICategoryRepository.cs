using MagicPharm.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Repositories.interfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();
        public Category Find(Guid id);
        public void Add(Category category);
        public void Delete(Guid id);
        public void Update(Category newCategory);
    }
}
