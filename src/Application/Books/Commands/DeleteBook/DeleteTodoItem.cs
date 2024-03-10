using BookLibrary.Application.Common.Interfaces;
using BookLibrary.Domain.Events;

public record DeleteBookCommand(int BookId) : IRequest;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBookCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Books
            .FindAsync(new object[] { request.BookId }, cancellationToken);

        Guard.Against.NotFound(request.BookId, entity);

        _context.Books.Remove(entity);

        entity.AddDomainEvent(new BookDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
