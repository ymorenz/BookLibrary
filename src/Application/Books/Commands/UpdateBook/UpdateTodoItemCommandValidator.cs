
namespace BookLibrary.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(100)
            .NotEmpty();
    }
}
