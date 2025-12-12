using IsabelliDoces.Entities;
using IsabelliDoces.Enums;

namespace IsabelliDoces.Relations;

public class RolePermission
{
    public required Role Role { get; init; }
    public required PermissionType PermissionType { get; init; }
}
