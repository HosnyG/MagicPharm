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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Find(int id)
        {
            return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(p => p.Category);
        }

        public IEnumerable<Product> GetByCategory(Guid categoryId)
        {
            return _context.Products.Include(p => p.Category).Where(p=>p.CategoryId==categoryId);
        }

        public IEnumerable<Product> GetPreferredProducts()
        {
            return _context.Products.Include(p => p.Category).Where(p => p.IsPreferred);
        }

        public void Update(Product newProduct)
        {
            _context.Products.Update(newProduct);
            _context.SaveChanges();

        }

        public IEnumerable<Product> Search(string term)
        {
            if (string.IsNullOrEmpty(term))
                return GetAll();
            term = term.ToLower();
            return _context.Products.Include(p => p.Category).Where(p => p.Name.ToLower().Contains(term)
              || p.Category.Name.ToLower().Contains(term));
        }
    }
}
