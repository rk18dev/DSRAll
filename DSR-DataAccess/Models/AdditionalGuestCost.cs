using System;
using System.Collections.Generic;

namespace DSR_DataAccess.Models;

public partial class AdditionalGuestCost
{
    public int AdditionGuestId { get; set; }

    public string AdditionGuestType { get; set; } = null!;

    public decimal AdditionGuestCost { get; set; }

    public int IsActive { get; set; }
}
