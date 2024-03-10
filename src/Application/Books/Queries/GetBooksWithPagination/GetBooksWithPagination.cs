using BookLibrary.Application.Common.Interfaces;
using BookLibrary.Application.Common.Mappings;
using BookLibrary.Application.Common.Models;

namespace BookLibrary.Application.Books.Queries.GetBooksWithPagination;

public record GetBooksWithPaginationQuery : IRequest<PaginatedList<BookDto>>
{
    public string SearchCriteria { get; init; } = string.Empty;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetBooksWithPaginationQueryHandler : IRequestHandler<GetBooksWithPaginationQuery, PaginatedList<BookDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBooksWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BookDto>> Handle(GetBooksWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Books
            .Where(x=> x.Title!.Contains(request.SearchCriteria) || x.FirstName!.Contains(request.SearchCriteria) || x.LastName!.Contains(request.SearchCriteria) || x.Isbn!.Contains(request.SearchCriteria))
            .OrderBy(x => x.Title)
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
