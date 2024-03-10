namespace BookLibrary.Domain.Events;

public class BookCompletedEvent : BaseEvent
{
    public BookCompletedEvent(Book item)
    {
        Item = item;
    }

    public Book Item { get; }
}
