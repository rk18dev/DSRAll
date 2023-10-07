using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int IsActive { get; set; }
}
