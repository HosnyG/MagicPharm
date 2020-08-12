using MagicPharm.Models.Context;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicPharm.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Category category = Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category Find(Guid id)
        {
            Category category = _context.Categories.AsNoTracking().SingleOrDefault(b => b.Id == id);
            
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public void Update(Category newCategory)
        {
            _context.Categories.Update(newCategory);
            _context.SaveChanges();
        }
    }
}
