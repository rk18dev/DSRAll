using DSR_DataAccess.Models;
using DSR_DataAccess.Utils.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_DataAccess.Services.CommonServices
{
    public class CommonActions : ICommonActions
    {
        public Hotel IsHotelAvailable(int HotelId)
        {
            using (var db=new DsrContext())
            {
                Hotel? hotel=db.Hotels.Where(h=>h.HotelId== HotelId).SingleOrDefault();
                if (hotel == null)
                {
                    throw new HotelNotFound();
                }
                return hotel;
            }
        }
    }
}
