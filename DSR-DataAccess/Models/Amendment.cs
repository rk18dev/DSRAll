using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Amendment
{
    public int AmendmentId { get; set; }

    public string Features { get; set; } = null!;

    public int IsActive { get; set; }
}
