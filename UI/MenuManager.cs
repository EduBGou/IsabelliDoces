using IsabelliDoces.UI.Menus;

namespace IsabelliDoces.UI;

public static class MenuManager
{
    public static MainMenu MainMenu { get; set; } = new();
    public static EmployeeMenu EmployeeMenu { get; set; } = new();
    public static OrderMenu OrderMenu { get; set; } = new();
}
