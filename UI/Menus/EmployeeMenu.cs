using IsabelliDoces.Data;
using IsabelliDoces.Entities;
using IsabelliDoces.Enums;
using IsabelliDoces.UI.Helpers;

namespace IsabelliDoces.UI.Menus;

public class EmployeeMenu() : Menu
{
    protected override string MenuTitle => "FUNCIONÁRIO";

    protected override MenuOption[] AllOptions => [
        new("Listar/Alterar Funcionários", ListEmployee, PermissionType.CRUD_EMPLOYEE),
    ];

    private async Task ListEmployee(IsabelliDocesContext dbContext, string label)
    {
        Console.Clear();
        Console.WriteLine($"=== {label.ToUpper()} ===");
        await MenuExtention.ListingAsync<Employee>(dbContext);
        Console.WriteLine("\nPressione qualquer tecla pra voltar.");
        Console.ReadKey();
    }
}