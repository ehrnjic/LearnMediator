using LearnMediator.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnMediator.Data;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; } = null!;

    /* The common practice of having uninitialized DbSet properties on context types is also
     * problematic, as the compiler will now emit warnings for them. This can be fixed as 
     * follows: public DbSet<Customer> Customers => Set<Customer>();
     * Another strategy is to use non-nullable auto-properties, but to initialize them to null,
     * using the null-forgiving operator (!) to silence the compiler warning. The DbContext base 
     * constructor ensures that all DbSet properties will get initialized, and null will never 
     * be observed on them.
     */
}
