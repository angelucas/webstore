namespace Cart.API.Cart.GetCart
{
    public record GetCartQuery(string UserName) : IQuery<GetCartResult>;
    public record GetCartResult(ShoppingCart Cart);
    public class GetCartQueryHandler : IQueryHandler<GetCartQuery, GetCartResult>
    {
        public async Task<GetCartResult> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return new GetCartResult(new ShoppingCart("swn"));
        }
    }
}
