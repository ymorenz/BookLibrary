using BookLibrary.Application.Common.Interfaces;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Events;

namespace BookLibrary.Application.Books.Commands.CreateBook;

public record CreateBookCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public int TotalCopies { get; set; } 
    public int CopiesInUse { get; set; } 
    public string? Type { get; set; } 
    public string? Isbn { get; set; } 
    public string? Category { get; set; } 
}

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBookCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = new Book()
        {
            Title = request.Title,
            FirstName = request.FirstName,
            LastName = request.LastName,
            TotalCopies = request.TotalCopies,
            CopiesInUse = request.CopiesInUse,
            Type = request.Type,
            Isbn = request.Isbn,
            Category = request.Category
        };

        entity.AddDomainEvent(new BookCreatedEvent(entity));

        _context.Books.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
