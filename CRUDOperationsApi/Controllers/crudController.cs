using CRUDOperationsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class crudController : ControllerBase
    {
        [HttpPost]
        public int addProducts(Products products)
        {
            products.ProductId = products.ProductId;
            products.ProductName = products.ProductName;
            products.ProductDescription = products.ProductDescription;
            
            return 0;

        }


    }
}
