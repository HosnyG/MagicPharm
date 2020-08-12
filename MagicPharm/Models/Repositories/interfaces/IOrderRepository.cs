using MagicPharm.Models.Entites;


namespace MagicPharm.Models.Repositories.interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
