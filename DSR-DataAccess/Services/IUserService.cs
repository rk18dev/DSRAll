using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSR_DataAccess.Models;
using DSR_DataAccess.Utils.CommonModels;

namespace DSR_DataAccess.Services
{
    public interface IUserService
    {
        SuccessResponse addBookings(Booking booking);

        List<Booking> getBookings(int? id);
    }
}
