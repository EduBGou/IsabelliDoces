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
                Cep = "78221-351",
                Complement = ""
            },
            new
            {
                Id = 3,
                Street = "Rua Luis Hasper",
                Number = "9855",
                Cep = "54321-876",
                Complement = "Casa Azul"
            },
            new
            {
                Id = 4,
                Street = "Rua Luis Hasper",
                Number = "871",
                Cep = "54321-876",
                Complement = "Casa Amarela"
            }
        );


        modelBuilder.Entity<Client>().HasData(
            new { Id = 1, Name = "Gustavo", Phone = "(44) 91234-5678", HomeId = 1 },
            new { Id = 2, Name = "Lana", Phone = "(44) 95555-4444", HomeId = 2 },
            new { Id = 3, Name = "Vincius", Phone = "(44) 96666-1050", HomeId = 1 }
        );


        modelBuilder.Entity<DeliveryPlace>(e =>
        {
            e.HasKey("ClientId", "AddressId");
        });

        modelBuilder.Entity<DeliveryPlace>().HasData(
            new { ClientId = 1, AddressId = 1 },
            new { ClientId = 1, AddressId = 2 },
            new { ClientId = 2, AddressId = 1 },
            new { ClientId = 2, AddressId = 3 }
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
            },
            new
            {
                Id = 2,
                Cpf = "010.174.775-54",
                Name = "Isabelli",
                Phone = "(44) 95445-1643",
                Email = "isa@gmail.com",
                Password = "321",
                HomeId = 3
            },
            new
            {
                Id = 3,
                Cpf = "410.214.875-12",
                Name = "Scopel",
                Phone = "(44) 97847-6941",
                Email = "scopel@gmail.com",
                Password = "852",
                HomeId = 4
            }
        );

        modelBuilder.Entity<CakeFlavor>().HasData(
            new { Id = 1, Name = "Chocolate", Price = 40.00M },
            new { Id = 2, Name = "Morango", Price = 50.00M },
            new { Id = 3, Name = "Pistache", Price = 60.00M }
        );

        const string ROLE_FK_NAME = "RoleId";
        modelBuilder.Entity<RolePermission>(e =>
        {
            e.HasKey(ROLE_FK_NAME, nameof(RolePermission.PermissionType));
        });

        modelBuilder.Entity<RolePermission>().HasData(
            new { RoleId = 1, PermissionType = PermissionType.CRUD_CLIENT },
            new { RoleId = 1, PermissionType = PermissionType.CRUD_EMPLOYEE },
            new { RoleId = 1, PermissionType = PermissionType.CREATE_ORDER },
            new { RoleId = 1, PermissionType = PermissionType.UPDATE_ORDER },
            new { RoleId = 1, PermissionType = PermissionType.CONFIRM_ORDER },
            new { RoleId = 1, PermissionType = PermissionType.LIST_ORDERS },
            new { RoleId = 1, PermissionType = PermissionType.CANCEL_ORDER },

            new { RoleId = 3, PermissionType = PermissionType.CREATE_ORDER },
            new { RoleId = 3, PermissionType = PermissionType.UPDATE_ORDER },
            new { RoleId = 3, PermissionType = PermissionType.LIST_ORDERS },
            new { RoleId = 3, PermissionType = PermissionType.CANCEL_ORDER },

            new { RoleId = 2, PermissionType = PermissionType.CRUD_EMPLOYEE },
            new { RoleId = 2, PermissionType = PermissionType.CRUD_CLIENT },

            new { RoleId = 4, PermissionType = PermissionType.LIST_ORDERS },
            new { RoleId = 4, PermissionType = PermissionType.CONFIRM_ORDER }
        );


        modelBuilder.Entity<Role>().HasData(
            new { Id = 1, Name = "SuperAdmin" },
            new { Id = 2, Name = "Admin" },
            new { Id = 3, Name = "Atendente" },
            new { Id = 4, Name = "Entregador" }
        );


        modelBuilder.Entity<RoleContract>().HasData(
            new
            {
                Id = 1,
                StartDate = new DateTime(2025, 12, 10),
                EmployeeId = 1,
                RoleId = 1
            },
            new
            {
                Id = 2,
                StartDate = new DateTime(2025, 12, 10),
                EmployeeId = 2,
                RoleId = 2
            },
            new
            {
                Id = 3,
                StartDate = new DateTime(2025, 12, 10),
                EmployeeId = 2,
                RoleId = 3
            },
            new
            {
                Id = 4,
                StartDate = new DateTime(2025, 12, 10),
                EmployeeId = 3,
                RoleId = 4
            }
        );
    }
}
