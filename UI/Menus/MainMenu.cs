using IsabelliDoces.Data;
using IsabelliDoces.Enums;

namespace IsabelliDoces.UI.Menus;

public class MainMenu() : Menu
{
    protected override string MenuTitle => "MENU PRINCIPAL";
    protected override string MenuSubtitle => $"Bem vindo(a) {LoginManager.GetUser()?.Name}.";

    protected override Func<IsabelliDocesContext, string, Task> GoBackFunction =>
        (dbContext, label) => LoginManager.Login(dbContext);

    protected override MenuOption[] AllOptions => [
        new("Funcionários", (context, label) =>
            MenuManager.EmployeeMenu.Display(context),
            PermissionType.CRUD_EMPLOYEE),
        new("Clientes", (context, label) =>
            MenuManager.ClientMenu.Display(context),
            PermissionType.CRUD_CLIENT),
        new("Pedidos", (context, label) => MenuManager.OrderMenu.Display(context),
            PermissionType.MENU_ORDER),
        new("Encerrar Programa", (context, label) =>
        {
            Environment.Exit(0);
            return Task.CompletedTask;
        })
    ];

    public override async Task Display(IsabelliDocesContext dbContext)
    {
        while (true)
        {
            await base.Display(dbContext);
        }
    }
}