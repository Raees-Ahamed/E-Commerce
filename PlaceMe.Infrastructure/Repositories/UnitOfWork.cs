using Microsoft.EntityFrameworkCore;
using PlaceMe.Infrastructure.DbContexts;
using PlaceMe.Infrastructure.Entities;
using System;

namespace PlaceMe.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private GenericRepository<Product> productRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<OrderLine> orderLineRepository;
        private GenericRepository<Promotion> promotionRepository;
        private GenericRepository<PromotionLine> promotionLineRepository;
        private GenericRepository<User> userRepository;
        private readonly PlaceMeDbContext context;

        public UnitOfWork(DbContext dbContext)
        {
            context = (PlaceMeDbContext)dbContext;
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public GenericRepository<OrderLine> OrderLineRepository
        {
            get
            {
                if (this.orderLineRepository == null)
                {
                    this.orderLineRepository = new GenericRepository<OrderLine>(context);
                }
                return orderLineRepository;
            }
        }

        public GenericRepository<Promotion> PromotionRepository
        {
            get
            {
                if (this.promotionRepository == null)
                {
                    this.promotionRepository = new GenericRepository<Promotion>(context);
                }
                return promotionRepository;
            }
        }

        public GenericRepository<PromotionLine> PromotionLineRepository
        {
            get
            {
                if (this.promotionLineRepository == null)
                {
                    this.promotionLineRepository = new GenericRepository<PromotionLine>(context);
                }
                return promotionLineRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
            context.Database.RollbackTransaction();
        }

        public void Commit()
        {
            context.Database.CommitTransaction();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
