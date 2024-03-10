namespace BookLibrary.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(100)
            .NotEmpty();
    }
}
