using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IsabelliDoces.Data;

public class IsabelliDocesContextFactory : IDesignTimeDbContextFactory<IsabelliDocesContext>
{
    public const string CONNECTION_STRING = "Data Source=IsabelliDoces.db";
    public IsabelliDocesContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IsabelliDocesContext>();
        optionsBuilder.UseSqlite(CONNECTION_STRING);
        return new IsabelliDocesContext(optionsBuilder.Options);
    }
}
