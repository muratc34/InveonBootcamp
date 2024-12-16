﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class LoginViewModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Beni Hatırla?")]
    public bool RememberMe { get; set; }
}
