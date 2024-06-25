using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products",
                async (UpdateProductRequest request, ISender sender) =>
                {
                    var comand = request.Adapt<UpdateProductCommand>();

                    var result = await sender.Send(comand);

                    var response = result.Adapt<UpdateProductResponse>();

                    return Results.Ok(response);
                })
                .WithName("UpdateProduct")
                .Produces<UpdateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Update Product")
                .WithDescription("Update Product");
        }
    }
}
