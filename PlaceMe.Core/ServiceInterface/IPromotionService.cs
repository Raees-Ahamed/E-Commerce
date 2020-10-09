using PlaceMe.Infrastructure.Entities;
using System.Collections.Generic;

namespace PlaceMe.Core.ServiceInterface
{
    public interface IPromotionService
    {
        public IEnumerable<Promotion> GetPromotion();
        void CreatePromotion(Promotion promotion);
    }
}
