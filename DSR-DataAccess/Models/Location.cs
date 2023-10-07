using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public int HotelId { get; set; }

    public int IsActive { get; set; }
}
