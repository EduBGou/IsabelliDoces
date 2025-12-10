using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.Data;

public static class DataExtentions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IsabelliDocesContext>();
        await dbContext.Database.MigrateAsync();
    }
}
