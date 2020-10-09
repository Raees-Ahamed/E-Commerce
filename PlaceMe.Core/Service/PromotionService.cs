using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace PlaceMe.Core.Service
{
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork unitOfWork;

        public PromotionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreatePromotion(Promotion promotion)
        {
            try
            {
                promotion.Id = Guid.NewGuid().ToString();

                foreach(var promotionLine in promotion.PromotionLines)
                {
                    promotionLine.PromotionId = promotion.Id;
                }
                unitOfWork.PromotionRepository.Create(promotion);
                unitOfWork.Save();
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Promotion> GetPromotion()
        {
            try
            {
                var promotions = unitOfWork.PromotionRepository.Get(includeProperties: "PromotionLines");

                if (promotions != null)
                {
                    return promotions;
                }
                else
                {
                    throw new ArgumentNullException(nameof(promotions));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
