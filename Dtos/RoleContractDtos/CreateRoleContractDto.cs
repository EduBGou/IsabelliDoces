using IsabelliDoces.Entities;

namespace IsabelliDoces.Dtos.RoleContractDtos;

public record class CreateRoleContractDto()
{
    public DateTime StartDate { get; init; }
    public int EmployeeId { get; init; }
    public int RoleId { get; init; }
}
