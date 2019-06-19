using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/product")]
    public class MaterialController:ControllerBase
    {
        [HttpGet("{id}/Material")]
        public IActionResult GetMaterials(int id)
        {
            var result = ProductService.Current.products.SingleOrDefault(x=>x.Id==id);
            if (result != null)
            {
                return Ok(result.Materials);
            }

            return NotFound();
        }

        [HttpGet("{Productid}/Material/{Materialid}")]
        public IActionResult GetMaterials(int Productid, int Materialid)
        {
            var result = ProductService.Current.products.SingleOrDefault(x => x.Id == Productid);
            if (result != null)
            {
                var MaterialResult = result.Materials.SingleOrDefault(x => x.Id == Materialid);
                if (MaterialResult != null)
                {
                    return Ok(MaterialResult);
                }

                return NotFound(Materialid);
            }
            return NotFound(Productid);
        }
    }
}
