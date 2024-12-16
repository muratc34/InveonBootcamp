using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models;

public class RoleEditViewModel
{
    public string Id { get; set; }
    public string RoleName { get; set; }
}

public class AssignRoleToUserViewModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool Exist { get; set; }
}