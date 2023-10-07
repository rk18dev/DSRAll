using DSR_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_DataAccess.Services.CommonServices
{
    public  interface ICommonActions
    {
        Hotel IsHotelAvailable(int HotelId);
    }
}
