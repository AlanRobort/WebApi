using System;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Model;
using WebApi.Services;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [Route("api/product")]  
    //[ApiController]
    public class ProudctController : ControllerBase
    {
        
        private readonly ILogger<ProudctController> _logger;

        public ProudctController(ILogger<ProudctController> logger)
        {
            _logger = logger;
        }

       [HttpGet]    
        public IActionResult GetProdcts()
        {
            var ProductsList = ProductService.Current.products;
            return Ok(ProductsList);
        }

        [Route("{id}",Name ="GetProduct")]
        public IActionResult GetProudct(int id)
        {
            try
            {
                //throw new Exception("来个异常");
                var Product = ProductService.Current.products.SingleOrDefault(x => x.Id == id);
                if (Product == null)
                {
                    _logger.LogInformation($"Id为{id}的产品没有找到");
                    return NotFound();
                }

                return Ok(Product);
            }
            catch (Exception ex)
            {
                //记录Exception就建议使用LogCritical了，
                //这里需要注意的是Exception的发生就表示服务器发生了错误，
                //我们应该处理这个exception并返回500。
                //使用StatusCode这个方法返回特定的StatusCode，
                //然后可以加一个参数来解释这个错误
                _logger.LogCritical($"查找Id为{id}时发生错误！",ex);
                return StatusCode(500, "处理请求时发生错误！");
            }
           
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductCreation product)
        {
            if (product != null)
            {
                if (ModelState.IsValid)
                {
                    var maxId = ProductService.Current.products.Max(x => x.Id);

                    var newProduct = new Products
                    {
                        Id = ++maxId,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description
                    };

                   
                    //addproduct
                    ProductService.Current.products.Add(newProduct);
                    return CreatedAtRoute("GetProduct", new { id = newProduct.Id }, newProduct);
                }
                
                return BadRequest(ModelState);
            }

            return BadRequest();

        }

        /// <summary>
        /// [HttpPut("{id}")] 更新根据产品的id来更改，所以在路由的时候需要知道[HttpPut("{id}")]传输的id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpAllProduct(int id, [FromBody] ProductModification product)
        {
            if (product != null)
            {
                if (ModelState.IsValid)
                {
                    var result = ProductService.Current.products.SingleOrDefault(x=>x.Id==id);
                    if (result != null)
                    {
                        //change in model of data
                        result.Name = product.Name;
                        result.Price = product.Price;
                        result.Description = product.Description;
                        return NoContent();
                    }

                    return BadRequest();

                }
                return BadRequest(ModelState);
            }

            return NotFound();

        }

        [HttpPatch("{id}")]
        public IActionResult UpPatchProduct(int id, [FromBody] JsonPatchDocument<ProductModification> patchDoc)
        {
            if (patchDoc != null)
            {
                var result = ProductService.Current.products.SingleOrDefault(x => x.Id==id);
                if (result != null)
                {
                    var toPatch = new ProductModification
                    {
                        Name = result.Name,
                        Price = result.Price,
                        Description = result.Description
                    };

                    patchDoc.ApplyTo(toPatch, ModelState);
                    TryValidateModel(toPatch);

                    if (ModelState.IsValid)
                    {
                        result.Name = toPatch.Name;
                        result.Price = toPatch.Price;
                        result.Description = toPatch.Description;
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }

                }
                else
                {
                    return BadRequest();
                }
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = ProductService.Current.products.SingleOrDefault(x=>x.Id==id);
            if (result != null)
            {
                if (ModelState.IsValid)
                {
                    var Deleteproduct = ProductService.Current.products.Remove(result);
                    return NoContent();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest();
            }


        }
    }
}