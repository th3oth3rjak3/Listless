using Listless.Persistence.Entities;

using Microsoft.EntityFrameworkCore;

namespace Listless.Persistence;

/// <summary>
/// The database context for this application.
/// </summary>
public class ListlessContext : DbContext
{
    /// <summary>
    /// Create a new instance of the context.
    /// </summary>
    public ListlessContext() { }

    /// <summary>
    /// Create a new instance of the context with options. 
    /// </summary>
    /// <param name="options">Options used to create the context.</param>
    public ListlessContext(DbContextOptions<ListlessContext> options) : base(options) { }

    /// <summary>
    /// A collection of lists that a user has generated.
    /// </summary>
    internal DbSet<DbUserList> UserLists { get; set; }

    /// <summary>
    /// A collection of items that are associated with a list.
    /// </summary>
    internal DbSet<DbListItem> ListItems { get; set; }

    /// <summary>
    /// Apply configurations from the persistence assembly.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to apply configuration.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListlessContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Allow for design time migration creation.
    /// </summary>
    /// <param name="optionsBuilder">An options builder used for constructing a database for design time migrations.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Listless.db3");
    }
}
