using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PlaceMe.Core.ResourceParameters;
using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaceMe.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            try
            {
                unitOfWork.ProductRepository.Create(product);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                unitOfWork.Rollback();
                throw e;
            }
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return unitOfWork.ProductRepository.Get(includeProperties: "ImageLines,DescriptionLines");
            }
            catch (Exception e)
            {
                throw e;
            };
        }

        public IEnumerable<Product> GetProduct(ProductResourceParameters productResourceParameters)
        {
            if (productResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(productResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(productResourceParameters.SearchQuery))
            {
                return GetProducts();
            }

            var collection = unitOfWork.ProductRepository.Get(includeProperties:"ImageLines,DescriptionLines").AsQueryable();

            if (!string.IsNullOrWhiteSpace(productResourceParameters.SearchQuery))
            {
                var searchQuery = productResourceParameters.SearchQuery.Trim();
                collection = collection.Where(p => p.Name.Contains(searchQuery,StringComparison.OrdinalIgnoreCase));
            }

            return collection.Include("ImageLines,DescriptionLines").ToList();
        }

        public void Update(Product product,int productId,  int quantity)
        {
            if(product != null)
            {
                UpdateProductDetail(product);
            }
            else
            {
                UpdateProductQuantity(productId, quantity);
            }
        }

        private void UpdateProductDetail(Product product)
        {
            try
            {
                unitOfWork.ProductRepository.Update(product);
                unitOfWork.Save();
                unitOfWork.Commit();
            }
            catch(Exception e)
            {
                unitOfWork.Rollback();
                throw e;
            }
        }

        private void UpdateProductQuantity(int productId, int quantity)
        {
            try
            {
                var product = GetProducts().Where(p => p.Id == productId).First();
                var description = product.DescriptionLines.Where(p => p.ShortDescription == p.ShortDescription).First();

                if (product != null)
                {
                    foreach (var i in product.DescriptionLines)
                    {
                        i.Quantity = description.Quantity + quantity;
                        i.SalesCount = description.SalesCount + -(quantity);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(product));
                }

                unitOfWork.ProductRepository.Update(product);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                return unitOfWork.ProductRepository.Get(includeProperties: "ImageLines,DescriptionLines").First(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
