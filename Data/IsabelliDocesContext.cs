using System.Globalization;
using IsabelliDoces.Entities;
using IsabelliDoces.Enums;
using IsabelliDoces.Relations;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace IsabelliDoces.Data;

public class IsabelliDocesContext(DbContextOptions<IsabelliDocesContext> options)
    : DbContext(options)
{
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();
    public DbSet<CakeFlavor> CakeFlavors => Set<CakeFlavor>();
    public DbSet<RoleContract> RoleContracts => Set<RoleContract>();
    public DbSet<DeliveryPlace> DeliveryPlaces => Set<DeliveryPlace>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>().HasData(
            new
            {
                Id = 1,
                Street = "Rua Mato Fino",
                Number = "4226",
                Cep = "12345-678",
                Complement = "Kitnet"
            },
            new
            {
                Id = 2,
                Street = "Rua Floresta Grossa",
                Number = "9995",
                Cep = "54321-876",
                Complement = ""
            }
        );


        modelBuilder.Entity<Client>().HasData(
            new { Id = 1, Name = "Gustavo", Phone = "(44) 91234-5678", HomeId = 1 },
            new { Id = 2, Name = "Lana", Phone = "(44) 95555-4444", HomeId = 2 }
        );


        modelBuilder.Entity<DeliveryPlace>(e =>
        {
            e.HasKey("ClientId", "AddressId");
        });

        modelBuilder.Entity<DeliveryPlace>().HasData(
            new { ClientId = 1, AddressId = 1 },
            new { ClientId = 1, AddressId = 2 },
            new { ClientId = 2, AddressId = 1 }
        );


        modelBuilder.Entity<Employee>().HasData(
            new
            {
                Id = 1,
                Cpf = "025.156.745-89",
                Name = "Eduardo",
                Phone = "(44) 91234-5678",
                Email = "edu@gmail.com",
                Password = "123",
                HomeId = 2
            }
        );


        const string ROLE_FK_NAME = "RoleId";
        modelBuilder.Entity<RolePermission>(e =>
        {
            e.HasKey(ROLE_FK_NAME, nameof(RolePermission.PermissionType));
        });


        modelBuilder.Entity<CakeFlavor>().HasData(
            new { Id = 1, Name = "Chocolate", Price = 30.00M },
            new { Id = 2, Name = "Morango", Price = 35.00M }
        );


        modelBuilder.Entity<RolePermission>().HasData(
            new { RoleId = 1, PermissionType = PermissionType.CRUD_CLIENT },
            new { RoleId = 1, PermissionType = PermissionType.CRUD_EMPLOYEE },
            new { RoleId = 1, PermissionType = PermissionType.CREATE_ORDER },
            new { RoleId = 1, PermissionType = PermissionType.UPDATE_ORDER },
            new { RoleId = 1, PermissionType = PermissionType.CONFIRM_ORDER },
            new { RoleId = 1, PermissionType = PermissionType.LIST_ORDERS },
            new { RoleId = 1, PermissionType = PermissionType.CANCEL_ORDER }
        );


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
