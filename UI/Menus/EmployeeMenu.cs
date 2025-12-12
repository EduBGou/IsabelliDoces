using IsabelliDoces.Data;
using IsabelliDoces.Entities;
using IsabelliDoces.Enums;
using IsabelliDoces.Utilities;

namespace IsabelliDoces.UI.Menus;

public class EmployeeMenu() : Menu
{
    protected override string MenuTitle => "FUNCIONÁRIO";
    public override Menu PreviousMenuHierarchy => MenuManager.MainMenu;

    protected override MenuOption[] AllOptions => [
        new("Listar/Alterar Funcionários", ListEmployee),
        new("Cadastrar Funcionário", (context) => { CreateEmployee(); },  PermissionType.CRUD_EMPLOYEE),
    ];

    private static void ListEmployee(IsabelliDocesContext dbContext)
    {
        MenuExtention.Listing<Employee>(dbContext);
    }

    private void CreateEmployee()
    {

    }
}