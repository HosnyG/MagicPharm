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
    public class CarouselRepository : ICarouselRepository
    {
        private readonly AppDbContext _context;

        public CarouselRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Add(Carousel carousel)
        {
            _context.Carousels.Add(carousel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Carousel carousel = Find(id);
            _context.Carousels.Remove(carousel);
            _context.SaveChanges();
        }

        public Carousel Find(int id)
        {
            Carousel carousel = _context.Carousels.AsNoTracking().SingleOrDefault(b => b.Id == id);
            return carousel;
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _context.Carousels.AsNoTracking().ToList();
        }


        public void Update(Carousel newEntity)
        {
            _context.Update(newEntity);
            _context.SaveChanges();
        }
    }
}
