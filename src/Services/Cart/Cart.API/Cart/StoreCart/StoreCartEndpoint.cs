namespace Cart.API.Cart.StoreCart
{
    public record StoredCartRequest(ShoppingCart Cart);
    public record StoreCartResponse(string UserName);

    public class StoreCartEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/carrinho", async (StoredCartRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreCartCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<StoreCartResponse>();

                return Results.Created($"/carrinho/{response.UserName}", response);
            })
            .WithName("CreateProduct")
            .Produces<StoreCartResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}
