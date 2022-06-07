using Microsoft.AspNetCore.Identity;

namespace InteractiveMap.Infrastructure.Identity.Defaults;

public static class RoleDefaults
{
    public const string Basic = nameof(Basic);
    public const string Admin = nameof(Admin);

    public static IEnumerable<IdentityRole> All => new List<IdentityRole>()
    {
        new IdentityRole { Name = Basic, NormalizedName = Basic.ToUpper() },
        new IdentityRole { Name = Admin, NormalizedName = Admin.ToUpper() },
    };
}
