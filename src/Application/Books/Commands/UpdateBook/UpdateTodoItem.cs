using BookLibrary.Application.Common.Interfaces;

namespace BookLibrary.Application.Books.Commands.UpdateBook;

public record UpdateBookCommand : IRequest
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public int TotalCopies { get; set; } 
    public int CopiesInUse { get; set; } 
    public string? Type { get; set; } 
    public string? Isbn { get; set; } 
    public string? Category { get; set; } 
}

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Books
            .FindAsync(new object[] { request.BookId }, cancellationToken);

        Guard.Against.NotFound(request.BookId, entity);

        entity.Title = request.Title!;
        entity.FirstName = request.FirstName!;
        entity.LastName = request.LastName!;
        entity.TotalCopies = request.TotalCopies;
        entity.CopiesInUse = request.CopiesInUse;
        entity.Type = request.Type!;
        entity.Isbn = request.Isbn!;
        entity.Category = request.Category!;
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
