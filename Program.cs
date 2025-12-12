using Microsoft.EntityFrameworkCore;
using IsabelliDoces.Data;
using IsabelliDoces.UI;


var optionsBuilder = new DbContextOptionsBuilder<IsabelliDocesContext>();
optionsBuilder.UseSqlite(IsabelliDocesContextFactory.CONNECTION_STRING);

using var dbContext = new IsabelliDocesContext(optionsBuilder.Options);

await dbContext.Database.MigrateAsync();

await MenuManager.StartProgram(dbContext);
