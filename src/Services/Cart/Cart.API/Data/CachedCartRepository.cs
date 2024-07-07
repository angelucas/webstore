using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Cart.API.Data
{
    public class CachedCartRepository
        (ICartRepository repository, IDistributedCache cache) 
        : ICartRepository
    {
        public async Task<ShoppingCart> GetCart(string userName, CancellationToken cancellationToken = default)
        {
            var cacheCart = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cacheCart)) 
                return JsonSerializer.Deserialize<ShoppingCart>(cacheCart)!;

            var cart = await repository.GetCart(userName, cancellationToken);
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(cart));
            return cart;
        }

        public async Task<ShoppingCart> StoreCart(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            await repository.StoreCart(cart, cancellationToken);

            await cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart), cancellationToken);

            return cart;
        }

        public async Task<bool> DeleteCart(string userName, CancellationToken cancellationToken = default)
        {
            await repository.DeleteCart(userName, cancellationToken);

            await cache.RemoveAsync(userName, cancellationToken);

            return true;
        }
    }
}
