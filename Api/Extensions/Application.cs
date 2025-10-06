using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class Application
    {
        public static void Configure(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TechDbContext>();

                if (!dbContext.Database.CanConnect())
                {
                    var schemaDifference = dbContext.Database.GetPendingMigrations();
                    if (schemaDifference.Any())
                    {
                        dbContext.Database.Migrate();
                    }
                }
                else
                {
                    dbContext.Database.Migrate();
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
