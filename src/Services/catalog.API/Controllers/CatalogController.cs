using catalog.API.Interface.Manager;
using catalog.API.Manager;
using catalog.API.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Diagnostics;
using System.Net;

namespace catalog.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : BaseController
    {
        IProductManager _productManager;
        public CatalogController(IProductManager productManager)
        {
            _productManager = productManager;

        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ResponseCache(Duration = 10)]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productManager.GetAll();
                return CustomResult("data loaded success", products);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }

        }









        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ResponseCache(Duration = 10)]
        public IActionResult GetByCatagory(string catagory)
        {
            try
            {
                var products = _productManager.GetByCatagory(catagory);
                return CustomResult("data loaded success", products);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }

        }



        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]

        public IActionResult GetById(string id)
        {
            try
            {
                var product = _productManager.GetById(id);
                return CustomResult("data loaded success", product);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]

        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                product.Id = ObjectId.GenerateNewId().ToString();
                bool isSaved = _productManager.Add(product);
                if (isSaved)
                {
                    return CustomResult("product has created", product, HttpStatusCode.Created);
                }
                else
                {
                    return CustomResult("product not saved", product, HttpStatusCode.BadRequest);

                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }



        }


        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]

        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Id))
                {
                    return CustomResult("data not found", HttpStatusCode.NotFound);
                }
                bool isUpdate = _productManager.Update(product.Id, product);
                if (isUpdate)
                {
                    return CustomResult("product has updated", product, HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("product modified failed", product, HttpStatusCode.BadRequest);

                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }



        }




        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public IActionResult DeleteProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return CustomResult("data not found", HttpStatusCode.NotFound);
                }
                bool isDelete = _productManager.Delete(id);
                if (isDelete)
                {
                    return CustomResult("product has deleted", HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("product delete failed", HttpStatusCode.BadRequest);

                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }



        }

       

    }
}
