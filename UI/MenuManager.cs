using IsabelliDoces.Data;
using IsabelliDoces.UI.Menus;

namespace IsabelliDoces.UI;

public static class MenuManager
{
    public static LoginMenu LoginMenu { get; set; } = new();
    public static MainMenu MainMenu { get; set; } = new();
    public static EmployeeMenu EmployeeMenu { get; set; } = new();
    // public static OrderMenu OrderMenu { get; set; } = new();

    public static async Task StartProgram(IsabelliDocesContext dbContext)
    {
        await LoginMenu.Display(dbContext);
    }
}
