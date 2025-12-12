using IsabelliDoces.Relations;

namespace IsabelliDoces.Entities;

public class Role() : Entity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<RolePermission> RolePermissions { get; set; } = [];

    public override string ToString() => Name;
}
