namespace BookLibrary.Domain.Events;

public class BookCreatedEvent : BaseEvent
{
    public BookCreatedEvent(Book item)
    {
        Item = item;
    }

    public Book Item { get; }
}
