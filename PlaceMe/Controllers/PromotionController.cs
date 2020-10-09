using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;
using System;
using System.Collections.Generic;

namespace PlaceMe.Controllers
{
    [ApiController]
    [Route("api/promotions")]
    public class PromotionController : ControllerBase
    {

        private readonly IPromotionService promotionService;
        private readonly IMapper mapper;
        public PromotionController(IPromotionService promotionService, IMapper mapper)
        {
            this.promotionService = promotionService ?? throw new ArgumentNullException(nameof(promotionService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<PromotionDto>> GetPromotion()
        {
            var promotions = promotionService.GetPromotion();
            return Ok(mapper.Map<IEnumerable<PromotionDto>>(promotions));
        }

        [HttpPost]
        public ActionResult CreatePromotion(PromotionDto promotionDto)
        {
            var promotion = mapper.Map<Promotion>(promotionDto);
            promotionService.CreatePromotion(promotion);
            return Ok("Promotion placed successfully");
        }
    }
}