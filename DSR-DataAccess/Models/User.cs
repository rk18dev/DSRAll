using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int IsActive { get; set; }
}
