using BookLibrary.Domain.Events;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Application.Books.EventHandlers;

public class BookCreatedEventHandler : INotificationHandler<BookCreatedEvent>
{
    private readonly ILogger<BookCreatedEventHandler> _logger;

    public BookCreatedEventHandler(ILogger<BookCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("BookLibrary Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
