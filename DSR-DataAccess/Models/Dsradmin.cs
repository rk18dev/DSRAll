using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Dsradmin
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public int? IsActive { get; set; }

    public int AdminId { get; set; }
}
