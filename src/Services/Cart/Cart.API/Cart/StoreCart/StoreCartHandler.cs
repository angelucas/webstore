namespace Cart.API.Cart.StoreCart
{
    public record StoreCartCommand(ShoppingCart Cart) : ICommand<StoreCartResult>;
    public record StoreCartResult(string UserName);
    public class StoreCartCommandValidator : AbstractValidator<StoreCartCommand>
    {
        public StoreCartCommandValidator() 
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithName("UserName is required");
        }
    }
    public class StoreCartCommandHandler : ICommandHandler<StoreCartCommand, StoreCartResult>
    {
        public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;

            return new StoreCartResult("swn");
        }
    }
}
