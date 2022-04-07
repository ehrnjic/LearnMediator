using LearnMediator.Models;

namespace LearnMediator.Data;

public static class DataSeeder
{
    public static void Seed(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
        context.Database.EnsureCreated();
        AddCustomers(context);
    }

    private static void AddCustomers(CustomerDbContext context)
    {
        var customers = context.Customers.FirstOrDefault();
        if (customers != null) return;

        context.Customers.Add(new Customer
        {
            Id = Guid.Parse("21c0521d-f860-4f03-b140-1a85c89dbfd3"),
            Name = "Restoran AS"
        });

        context.Customers.Add(new Customer
        {
            Id = Guid.Parse("17470c6c-2271-46cf-8528-023ae1312e98"),
            Name = "Heco"
        });

        context.Customers.Add(new Customer
        {
            Id = Guid.Parse("67a1329e-cbb2-4e1f-adf9-a3573310c8a5"),
            Name = "Bingo"
        });

        context.SaveChanges();
    }
}
