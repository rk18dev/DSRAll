using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelLocation { get; set; } = null!;

    public string ImageList { get; set; } = null!;

    public int IsActive { get; set; }
}
