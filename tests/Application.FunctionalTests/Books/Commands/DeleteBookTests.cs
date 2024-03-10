using BookLibrary.Application.Books.Commands.CreateBook;
using BookLibrary.Domain.Entities;
using static BookLibrary.Application.FunctionalTests.Testing;

namespace BookLibrary.Application.FunctionalTests.Books.Commands;

public class DeleteBookTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidBookId()
    {
        var command = new DeleteBookCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteBook()
    {
        var command = new CreateBookCommand
        {
            Title = "The Catcher in the Rye",
            FirstName = "J.D.",
            LastName = "Salinger",
            TotalCopies = 10,
            CopiesInUse = 1,
            Type = "Hardcover",
            Isbn = "0123456789",
            Category = "Non-Fiction"
        };
        
        var bookCreated = await SendAsync(command);

        await SendAsync(new DeleteBookCommand(bookCreated));

        var item = await FindAsync<Book>(bookCreated);

        item.Should().BeNull();
    }
}
