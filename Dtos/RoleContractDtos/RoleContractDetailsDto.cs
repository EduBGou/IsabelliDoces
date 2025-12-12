using IsabelliDoces.Entities;

namespace IsabelliDoces.Dtos.RoleContractDtos;

public record class RoleContractDetailsDto()
{
    public int Id { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public Employee? Employee { get; init; } 
    public Role? Role { get; init; }
}
