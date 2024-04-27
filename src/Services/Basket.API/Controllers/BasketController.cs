﻿using Basket.API.Models;
using Basket.API.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository )
        {
            _basketRepository = basketRepository;
            
        }

        [HttpGet]
        [ProducesResponseType( typeof(ShoppingCart ), (int)HttpStatusCode.OK )]
        public async Task<IActionResult> GetBasket(string username)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(username);
                return CustomResult("data loaded succesfull", basket);


            }
            catch( Exception ex )
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest );
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK )]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                return CustomResult("basket modified done", await _basketRepository.UpdateBasket(basket));
            }
            catch ( Exception ex )
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest );
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK )]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            try
            {
                await _basketRepository.DeleteBasket(username);
                return CustomResult("delete succesfully");

            }
            catch ( Exception ex )
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


    }
}
