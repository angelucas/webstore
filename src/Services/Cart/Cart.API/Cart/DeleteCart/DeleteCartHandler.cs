
namespace Cart.API.Cart.DeleteCart
{
    public record DeleteCartCommand(string UserName) : ICommand<DeleteCartResult>;
    public record DeleteCartResult(bool IsSuccess);

    public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
    {
        public DeleteCartCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    public class DeleteCartCommandHandler(ICartRepository repository)
        : ICommandHandler<DeleteCartCommand, DeleteCartResult>
    {
        public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteCart(command.UserName, cancellationToken);

            return new DeleteCartResult(true);
        }
    }
}
