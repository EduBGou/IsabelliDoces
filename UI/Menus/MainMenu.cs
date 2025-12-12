namespace IsabelliDoces.UI.Menus;

public class MainMenu() : Menu
{
    protected override string MenuTitle => "MENU PRINCIPAL";
    protected override string MenuSubtitle => $"Bem vindo(a) {MenuManager.LoginMenu.GetUser()?.Name}.";

    protected override MenuOption[] AllOptions => [
        new("Funcionários", MenuManager.EmployeeMenu.Display),
        new("Pedidos", MenuManager.OrderMenu.Display)
    ];
}