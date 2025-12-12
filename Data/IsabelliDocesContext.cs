using IsabelliDoces.Entities;
using IsabelliDoces.Enums;
using IsabelliDoces.Relations;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Data;

public class IsabelliDocesContext(DbContextOptions<IsabelliDocesContext> options)
    : DbContext(options)
{
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Employee> Employees => Set<Employee>();
    // public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RoleContract> RoleContracts => Set<RoleContract>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>().HasData(
            new { Id = 1, AddressType = AddressType.RESIDENTIAL, Street = "Rua Mato Fino", Number = "4226", Cep = "12345-678", Complement = "Kitnet" },
            new { Id = 2, AddressType = AddressType.RESIDENTIAL, Street = "Rua Floresta Grossa", Number = "9995", Cep = "54321-876", Complement = "" }
        );


        modelBuilder.Entity<Client>().HasData(
            new { Id = 1, Name = "Gustavo", Phone = "(44) 91234-5678", AddressId = 1 },
            new { Id = 2, Name = "Lana", Phone = "(44) 95555-4444", AddressId = 2 }
        );


        // modelBuilder.Entity<Employee>()
        //     .HasOne(e => e.Address)
        //     .WithMany().HasForeignKey($"{nameof(Address)}Id");

        modelBuilder.Entity<Employee>().HasData(
            new
            {
                Id = 1,
                Cpf = "025.156.745-89",
                Name = "Eduardo",
                Phone = "(44) 91234-5678",
                Email = "edu@gmail.com",
                Password = "123",
                AddressId = 2
            }
        );

        const string ROLE_FK_NAME = "RoleId";
        modelBuilder.Entity<RolePermission>(e =>
        {
            e.Property<int>(ROLE_FK_NAME);
            e.HasKey(ROLE_FK_NAME, nameof(RolePermission.PermissionType));
            e.HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(ROLE_FK_NAME);
        }
        );


        modelBuilder.Entity<RolePermission>().HasData(
            new { RoleId = 1, PermissionType = PermissionType.CRUD_CLIENT },
            new { RoleId = 1, PermissionType = PermissionType.CRUD_EMPLOYEE }
        );

        // modelBuilder.Entity<Permission>().HasData(
        //    new { Id = 1, Name = "CRUD_CLIENT" },
        //    new { Id = 2, Name = "CRUD_EMPLOYEE" }
        //  );

        // modelBuilder.Entity<Role>()
        //     .HasMany(r => r.Permissions)
        //     .WithMany(p => p.Roles)
        //     .UsingEntity(j => j.HasData(
        //         new { RolesId = 1, PermissionsId = 1 },
        //         new { RolesId = 1, PermissionsId = 2 }
        // ));

        modelBuilder.Entity<Role>().HasData(
            new
            {
                Id = 1,
                Name = "Admin"
            }
        );

        modelBuilder.Entity<RoleContract>().HasData(
            new
            {
                Id = 1,
                StartDate = new DateTime(2025, 12, 10),
                EmployeeId = 1,
                RoleId = 1
            }
        );
    }
}
