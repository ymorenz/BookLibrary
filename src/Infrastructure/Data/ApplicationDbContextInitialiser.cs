using System.Runtime.InteropServices;
using BookLibrary.Domain.Constants;
using BookLibrary.Domain.Entities;
using BookLibrary.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }
        
        // Seed, if necessary
        if (!_context.Books.Any())
        {
            _context.Books.AddRange(new List<Book>()
                {
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        FirstName = "Jane",
                        LastName = "Austen",
                        TotalCopies = 100,
                        CopiesInUse = 80,
                        Type = "Hardcover",
                        Isbn = "1234567891",
                        Category = "Fiction"
                    },
                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        FirstName = "Harper",
                        LastName = "Lee",
                        TotalCopies = 75,
                        CopiesInUse = 65,
                        Type = "Paperback",
                        Isbn = "1234567892",
                        Category = "Fiction"
                    },
                    new Book
                    {
                        Title = "The Catcher in the Rye",
                        FirstName = "J.D.",
                        LastName = "Salinger",
                        TotalCopies = 10,
                        CopiesInUse = 1,
                        Type = "Hardcover",
                        Isbn = "0123456789",
                        Category = "Non-Fiction"
                    }
                }
            );
           
            await _context.SaveChangesAsync();
        }
    }
}
