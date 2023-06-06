using pushistin.Models;

namespace pushistin.Core.Repositories
{

    public interface IOrderRepository
    {

        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
