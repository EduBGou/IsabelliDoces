// using APS.Classes.Enum;

// namespace IsabelliDoces.UI;

// public class MenuOption(string label, Action action, params Permission[] permissions)
// {
//     public string Label { get; } = label;
//     public Action Action { get; } = action;
//     public Permission[] RequiredPermissions { get; } = permissions;

//     public bool HavePermission()
//     {
//         var user = MenuManager.LoginMenu.GetUser();
//         if (user is null) return false;
//         var userPerms = DAOManager.RoleContractDAO.GetEmployeePermissions(MenuManager.LoginMenu.GetUser());
//         return RequiredPermissions.All(userPerms.Contains);
//     }
// }