using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaceMe.Core.ResourceParameters;
using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;
using System;
using System.Collections.Generic;

namespace PlaceMe.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<ProductDto>> GetProduct([FromQuery] ProductResourceParameters productResourceParameters)
        {
            var product = productService.GetProduct(productResourceParameters);
            return Ok(mapper.Map<IEnumerable<ProductDto>>(product));
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductDto product)
        {
            var productEntity = mapper.Map<Product>(product);
            productService.Create(productEntity);

            return Ok("Created successfully!");
        }

        [HttpPut]
        public ActionResult<ProductDto> UpdateProduct(ProductDto product)
        {
            var productEntity = mapper.Map<Product>(product);
            productService.Update(productEntity, 0, 0);

            return Ok("Update successfully1");
        }

        [HttpDelete]
        public ActionResult<ProductDto> DeleteProduct(int id)
        {
            productService.Delete(id);

            return Ok("Deleted successfully!");
        }
    }
}
