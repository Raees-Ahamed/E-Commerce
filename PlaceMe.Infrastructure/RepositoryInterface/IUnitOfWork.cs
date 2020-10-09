

using PlaceMe.Infrastructure.Entities;

namespace PlaceMe.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<OrderLine> OrderLineRepository { get; }
        GenericRepository<PromotionLine> PromotionLineRepository { get; }
        GenericRepository<Promotion> PromotionRepository { get; }
        GenericRepository<User> UserRepository { get; }
        void Save();
        void Rollback();
        void Commit();
    }
}
