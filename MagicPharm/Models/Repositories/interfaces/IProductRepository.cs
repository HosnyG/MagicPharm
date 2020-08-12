using MagicPharm.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Repositories.interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public IEnumerable<Product> GetPreferredProducts();
        public IEnumerable<Product> GetByCategory(Guid categoryId);
        public Product Find(int id);
        public void Add(Product product);
        public void Delete(int id);
        public void Update(Product newProduct);
        public IEnumerable<Product> Search(string term);

    }
}
