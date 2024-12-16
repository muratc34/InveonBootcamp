using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication;

public class ApplicationUser : IdentityUser<int>
{
    public ApplicationUser(string firstName, string lastName, string email, string userName)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}