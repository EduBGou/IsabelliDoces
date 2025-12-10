using IsabelliDoces.Data;
using IsabelliDoces.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("IsabelliDoces");
builder.Services.AddSqlite<IsabelliDocesContext>(connString);

var app = builder.Build();
app.MapClientsEndpoints();
app.MapAddressesEndPoints();

await app.MigrateDbAsync();
app.Run();