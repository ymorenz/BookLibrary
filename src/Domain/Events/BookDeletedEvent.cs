namespace BookLibrary.Domain.Events;

public class BookDeletedEvent : BaseEvent
{
    public BookDeletedEvent(Book item)
    {
        Item = item;
    }
    public Book Item { get; }
}
