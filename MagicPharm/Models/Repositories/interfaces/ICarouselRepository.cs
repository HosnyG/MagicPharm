using MagicPharm.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Repositories.interfaces
{
    public interface ICarouselRepository
    {
        public IEnumerable<Carousel> GetAll();
        public Carousel Find(int id);
        public void Add(Carousel carousel);
        public void Delete(int id);
        public void Update(Carousel newCarousel);

    }
}
