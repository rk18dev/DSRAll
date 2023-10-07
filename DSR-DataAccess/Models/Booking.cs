using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class Booking
{
    public int Id { get; set; }

    public string BookingId { get; set; } = null!;

    public int Hotelid { get; set; }

    public string IsProofSubmitted { get; set; } = null!;

    public string BookingUser { get; set; } = null!;

    public DateTime BookingDate { get; set; }

    public DateTime BookingDateTime { get; set; }

    public DateTime BookFromDate { get; set; }

    public DateTime BookToDate { get; set; }

    public string IsPayment { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public long AllocatedRoomNo { get; set; }

    public string BookingStatus { get; set; } = null!;
}
