using IsabelliDoces.Entities;
using IsabelliDoces.Enums;

namespace IsabelliDoces.Relations;

public class RolePermission
{
    public Role Role { get; set; } = null!;
    public PermissionType PermissionType { get; set; }
}
