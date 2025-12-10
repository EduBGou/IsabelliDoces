using IsabelliDoces.Entities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Data;

public class IsabelliDocesContext(DbContextOptions<IsabelliDocesContext> options)
    : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>().HasData(
            new { Id = 1, Type = 0, Street = "Rua Mato Fino", Number = "4226", Cep = "12345-678", Complement = "Kitnet" },
            new { Id = 2, Type = 1, Street = "Rua Floresta Grossa", Number = "9995", Cep = "54321-876", Complement = "" }
        );

        modelBuilder.Entity<Client>().HasData(
            new { Id = 1, Name = "Eduardo", Phone = "(44) 91234-5678", AddressId = 1 },
            new { Id = 2, Name = "Lana", Phone = "(44) 95555-4444", AddressId = 2 }
        );
    }
}
