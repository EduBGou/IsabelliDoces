using IsabelliDoces.Data;
using IsabelliDoces.Entities;
using IsabelliDoces.Enums;
using IsabelliDoces.UI.Helpers;

namespace IsabelliDoces.UI.Menus;

public class ClientMenu() : Menu
{
    protected override string MenuTitle => "FUNCIONÁRIO";

    protected override MenuOption[] AllOptions => [
        new("Listar Clientes", ListEmployee, PermissionType.CRUD_CLIENT),
    ];

    private async Task ListEmployee(IsabelliDocesContext dbContext, string label)
    {
        Console.Clear();
        Console.WriteLine($"=== {label.ToUpper()} ===");
        await ListingHelper.ListingAsync<Client>(dbContext);
        Console.WriteLine("\nPressione qualquer tecla pra voltar.");
        Console.ReadKey();
    }
}
