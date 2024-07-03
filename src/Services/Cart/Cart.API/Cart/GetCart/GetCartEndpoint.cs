namespace Cart.API.Cart.GetCart
{
    public record GetCartResponse(ShoppingCart Cart);
    public class GetCartEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/carrinho/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new GetCartQuery(userName));

                var response = result.Adapt<GetCartResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetCartResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
        }
    }
}
