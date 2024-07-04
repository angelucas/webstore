using Cart.API.Cart.GetCart;

namespace Cart.API.Cart.DeleteCart
{
    public record DeleteCartResponse(bool IsSuccess);
    public class DeleteCartEndpoint : ICarterModule
    {
        public async void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/carrinho/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteCartCommand(userName));

                var response = result.Adapt<DeleteCartResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteCart")
            .Produces<GetCartResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Cart")
            .WithDescription("Delete Cart");
        }
    }
}
