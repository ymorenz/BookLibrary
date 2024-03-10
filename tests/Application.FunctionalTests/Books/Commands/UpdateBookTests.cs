using BookLibrary.Application.Books.Commands.CreateBook;
using BookLibrary.Application.Books.Commands.UpdateBook;
using BookLibrary.Domain.Entities;
using static BookLibrary.Application.FunctionalTests.Testing;

namespace BookLibrary.Application.FunctionalTests.Books.Commands;

public class UpdateBookTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidBookId()
    {
        var command = new UpdateBookCommand { BookId = 99, Title = "New Title" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateBook()
    {
        var userId = await RunAsDefaultUserAsync();

        var createBookCommandcommand = new CreateBookCommand
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

        var bookCreated = await SendAsync(createBookCommandcommand);
        
        var command = new UpdateBookCommand()
        {
            BookId = bookCreated,
            Title = "Random"
        };

        await SendAsync(command);

        var item = await FindAsync<Book>(bookCreated);

        item.Should().NotBeNull();
        item?.Title.Should().Be(command.Title);
        item?.LastModifiedBy.Should().NotBeNull();
        item?.LastModifiedBy.Should().Be(userId);
        item?.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
