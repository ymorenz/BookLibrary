using BookLibrary.Application.Books.Commands.CreateBook;
using BookLibrary.Application.Common.Exceptions;
using BookLibrary.Domain.Entities;
using static BookLibrary.Application.FunctionalTests.Testing;

namespace BookLibrary.Application.FunctionalTests.Books.Commands;

public class CreateBookTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateBookCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateBook()
    {
        var userId = await RunAsDefaultUserAsync();
        
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

        var itemId = await SendAsync(command);

        var item = await FindAsync<Book>(itemId);

        item.Should().NotBeNull();
        item?.Title.Should().Be(command.Title);
        item?.CreatedBy.Should().Be(userId);
        item?.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item?.LastModifiedBy.Should().Be(userId);
        item?.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
