using InteractiveMap.Infrastructure.Identity.Defaults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Identity.Seeds;

public static class DefaultRolesSeeder
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<IdentityRole<string>>().HasData(RoleDefaults.User, RoleDefaults.Admin);
    }
}
