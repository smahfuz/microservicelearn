﻿using Basket.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        //redis a j database ase take call korte hobe
        private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache distributedCache)
        {
            _redisCache = distributedCache;
            
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket =await _redisCache.GetStringAsync(userName);
            if(string.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
            
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.UserName);
           
        }
        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);

        }
    }
}
