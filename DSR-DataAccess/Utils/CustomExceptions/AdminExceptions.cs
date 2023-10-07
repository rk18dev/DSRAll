using DSR_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_DataAccess.Utils.CustomExceptions
{
   
    public  class AdminException :Exception
    {
        public override string ToString()
        {
            return "Admin is not available ";
        }
    }

    public class HotelNotFound : Exception
    {
        public override string ToString()
        {
            return "Hotel is not available ";
        }
    }
    public class RoomNotFound : Exception
    {
        public override string ToString()
        {
            return "Room is not available ";
        }
    }

    public class AmendmentNotFound : Exception
    {
        public override string ToString()
        {
            return "Amendments is not available ";
        }
    }

    public class RatingNotFound : Exception
    {
        public override string ToString()
        {
            return "Rating is not available ";
        }
    }

    public class ContactDetailsNotFound : Exception
    {
        public override string ToString()
        {
            return "ContactDetails is not available ";
        }
    }

    public class LocationNotFound : Exception
    {
        public override string ToString()
        {
            return "Location is not available ";
        }
    }

    public class AdditionalGuestCostNotFound : Exception
    {
        public override string ToString()
        {
            return "AdditionalGuestCost is not available ";
        }
    }

    public class UserNotFound : Exception
    {
        public override string ToString()
        {
            return "User is not available ";
        }
    }

    public class ImageNotFound : Exception
    {
        public override string ToString()
        {
            return "Image is not available ";
        }
    }

    public class BookingNotFound :Exception
    {
        public override string ToString()
        {
            return "booking is not available";
        }
    }
}

