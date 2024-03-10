using BookLibrary.Application.Books.Commands.CreateBook;
using BookLibrary.Application.Books.Commands.UpdateBook;
using BookLibrary.Application.Books.Queries.GetBooksWithPagination;
using BookLibrary.Application.Common.Models;

namespace BookLibrary.Web.Endpoints;

public class Books : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBooksWithPagination)
            .MapPost(CreateBook)
            .MapPut(UpdateBook, "{bookId}")
            .MapDelete(DeleteBook, "{id}");
    }

    public Task<PaginatedList<BookDto>> GetBooksWithPagination(ISender sender, [AsParameters] GetBooksWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateBook(ISender sender, CreateBookCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateBook(ISender sender, int id, UpdateBookCommand command)
    {
        if (id != command.BookId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteBook(ISender sender, int id)
    {
        await sender.Send(new DeleteBookCommand(id));
        return Results.NoContent();
    }
}
