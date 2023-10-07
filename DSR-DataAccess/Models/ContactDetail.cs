using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class ContactDetail
{
    public int ContactId { get; set; }

    public string ContactName { get; set; } = null!;

    public int HotelId { get; set; }

    public int IsActive { get; set; }
}
