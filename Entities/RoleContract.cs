namespace IsabelliDoces.Entities;

public class RoleContract () : Entity
{
    public required DateTime StartDate { get; init; }
    public DateTime? EndDate { get; set; }
    public required Employee Employee { get; init; }
    public required Role Role { get; init; }

    public void SetEndDate(DateTime endDate)
    {
        EndDate = endDate;
    }

    public bool IsActive() => StartDate <= DateTime.Today && (EndDate == null || EndDate >= DateTime.Today);
}
