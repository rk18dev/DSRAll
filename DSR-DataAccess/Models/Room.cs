using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public int TotalAcRooms { get; set; }

    public int TotalNonAcRooms { get; set; }

    public string AmendmentList { get; set; } = null!;

    public int IsActive { get; set; }

    public int IsAvailable { get; set; }
}
