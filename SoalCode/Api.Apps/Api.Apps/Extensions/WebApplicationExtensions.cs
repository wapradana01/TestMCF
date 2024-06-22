﻿using Microsoft.EntityFrameworkCore;

namespace Api.Apps.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication UseDbContext<TApplicationDbContext>(this WebApplication app)
            where TApplicationDbContext : DbContext
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TApplicationDbContext>();

            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();

            return app;
        }
    }
}
