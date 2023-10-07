using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class DsrImage
{
    public int Id { get; set; }

    public string? Imageurl { get; set; }

    public int? HotelId { get; set; }

    public int? IsActive { get; set; }

    public DateTime? AddDate { get; set; }
}
