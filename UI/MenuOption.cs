using IsabelliDoces.Data;
using IsabelliDoces.Enums;
using IsabelliDoces.Relations;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.UI;

public class MenuOption(string label, Action<IsabelliDocesContext> action, params PermissionType[] permissions)
{
    public string Label { get; } = label;
    public Action<IsabelliDocesContext> Action { get; } = action;
    public PermissionType[] RequiredPermissions { get; } = permissions;

    public bool HavePermission(IsabelliDocesContext dbContext)
    {
        var user = MenuManager.LoginMenu.GetUser() ??
            throw new Exception("Attempting to access menus without being logged in.");

        var existingClient = dbContext.Clients.Find(user.Id) ??
            throw new Exception("The logged-in user is not saved in the database.");

        var activesContracts = dbContext.RoleContracts
            .Include(rc => rc.Employee).Include(rc => rc.Role)
            .ThenInclude(r => r.RolePermissions).ToList()
            .Where(rc => rc.Employee.Id == user.Id && rc.IsActive());

        List<PermissionType> userPermissions = [];
        foreach (var contract in activesContracts)
        {
            if (contract.Role.RolePermissions is null) continue;
            foreach (var permission in contract.Role.RolePermissions)
            {
                userPermissions.Add(permission.PermissionType);
            }
        }
        return RequiredPermissions.All(userPermissions.Contains);
    }
}