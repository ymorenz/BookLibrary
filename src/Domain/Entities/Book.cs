namespace BookLibrary.Domain.Entities;

public class Book: BaseAuditableEntity
{
    public string? Title { get; set; } // Maps to title
    public string? FirstName { get; set; } // Maps to first_name
    public string? LastName { get; set; } // Maps to last_name
    public int TotalCopies { get; set; } // Maps to total_copies
    public int CopiesInUse { get; set; } // Maps to copies_in_use
    public string? Type { get; set; } // Maps to type
    public string? Isbn { get; set; } // Maps to isbn
    public string? Category { get; set; } // Maps to category

    // Calculated property that does not map to any column
    public int AvailableCopies => TotalCopies - CopiesInUse;
}
