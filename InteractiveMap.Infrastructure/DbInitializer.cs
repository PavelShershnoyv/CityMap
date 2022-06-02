using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Persistence;

public class DbInitializer
{
    public static void Initialize(DbContext context)
    {
        context.Database.EnsureCreated();
    }
}
