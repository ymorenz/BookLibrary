using BookLibrary.Domain.Events;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Application.Books.EventHandlers;

public class BookCompletedEventHandler : INotificationHandler<BookCompletedEvent>
{
    private readonly ILogger<BookCompletedEventHandler> _logger;

    public BookCompletedEventHandler(ILogger<BookCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BookCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("BookLibrary Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
