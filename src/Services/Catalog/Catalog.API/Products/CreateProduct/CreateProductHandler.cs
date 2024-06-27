using Microsoft.Extensions.Logging;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }

        internal class CreateProductCommandHandler
            (IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
            : ICommandHandler<CreateProductCommand, CreateProductResult>
        {
            public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                logger.LogInformation("CreateProductCommandHandler.Handle called with {@Command}", command);

                var product = new Product
                {
                    Name = command.Name,
                    Category = command.Category,
                    Description = command.Description,
                    ImageFile = command.ImageFile,
                    Price = command.Price,
                };

                session.Store(product);
                await session.SaveChangesAsync(cancellationToken);

                return new CreateProductResult(product.Id);
            }
        }
    }
}
