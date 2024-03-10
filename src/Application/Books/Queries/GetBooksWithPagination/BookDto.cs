using BookLibrary.Domain.Entities;

namespace BookLibrary.Application.Books.Queries.GetBooksWithPagination;

public class BookDto
{
    public string? Title { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public int TotalCopies { get; set; } 
    public int CopiesInUse { get; set; } 
    public string? Type { get; set; } 
    public string? Isbn { get; set; } 
    public string? Category { get; set; } 

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, BookDto>();
        }
    }
}