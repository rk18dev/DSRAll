using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Rating
{
    public int ReviewId { get; set; }

    public int Rating1 { get; set; }

    public string Comments { get; set; } = null!;

    public string ReviewedBy { get; set; } = null!;

    public DateTime ReviewModifiedDate { get; set; }

    public int HotelId { get; set; }

    public int IsActive { get; set; }
}
