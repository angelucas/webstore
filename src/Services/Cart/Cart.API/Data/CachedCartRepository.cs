namespace Cart.API.Data
{
    public class CachedCartRepository(ICartRepository repository) 
        : ICartRepository
    {
        public async Task<ShoppingCart> GetCart(string userName, CancellationToken cancellationToken = default)
        {
            return await repository.GetCart(userName, cancellationToken);
        }

        public async Task<ShoppingCart> StoreCart(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            return await repository.StoreCart(cart, cancellationToken);
        }

        public async Task<bool> DeleteCart(string userName, CancellationToken cancellationToken = default)
        {
            return await repository.DeleteCart(userName, cancellationToken);
        }
    }
}
