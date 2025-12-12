using IsabelliDoces.Data;

namespace IsabelliDoces.UI.Menus;

public class MainMenu() : Menu
{
    protected override string MenuTitle => "MENU PRINCIPAL";
    protected override string MenuSubtitle => $"Bem vindo(a) {MenuManager.LoginMenu.GetUser()?.Name}.";

    protected override MenuOption[] AllOptions => [
        new("Funcionários", (context, label) => MenuManager.EmployeeMenu.Display(context) ),
        new("Pedidos", (context, label) => MenuManager.OrderMenu.Display(context) )
    ];

    public override async Task Display(IsabelliDocesContext dbContext)
    {
        while (true)
        {
            await base.Display(dbContext);
        }
    }
}