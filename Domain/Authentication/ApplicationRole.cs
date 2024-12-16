using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication;

public class ApplicationRole : IdentityRole<int>
{
    public ApplicationRole(string name)
    {
        Name = name;
    }
}