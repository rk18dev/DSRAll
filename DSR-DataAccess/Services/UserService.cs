using DSR_DataAccess.Models;
using DSR_DataAccess.Services.CommonServices;
using DSR_DataAccess.Utils.CommonModels;
using DSR_DataAccess.Utils.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_DataAccess.Services
{
    public class UserService : IUserService
    {
        public SuccessResponse addBookings(Booking booking)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Booking? existingbooking = db.Bookings.Where(b=>b.Id==booking.Id).SingleOrDefault();
                if (existingbooking == null && booking.Id != 0)
                {

                    throw new BookingNotFound();
                }
                

                    if (existingbooking == null && booking.Id == 0)
                    {
                        var dbresult = db.Bookings.Add(booking);
                        response.Message = "Room booked successfully";
                    }
                    else
                    {
                        if (existingbooking != null)
                        {
                            existingbooking.BookingId = booking.BookingId;
                            existingbooking.Hotelid = booking.Hotelid;
                            existingbooking.IsProofSubmitted = booking.IsProofSubmitted;
                            existingbooking.BookingUser = booking.BookingUser;
                            existingbooking.BookingDate = booking.BookingDate;
                            existingbooking.BookingDateTime = booking.BookingDateTime;
                            existingbooking.BookFromDate = booking.BookFromDate;
                            existingbooking.BookToDate = booking.BookToDate;
                            existingbooking.IsPayment = booking.IsPayment;
                            existingbooking.PaymentAmount = booking.PaymentAmount;
                            existingbooking.AllocatedRoomNo = booking.AllocatedRoomNo;
                            existingbooking.BookingStatus = booking.BookingStatus;
                            db.Bookings.Add(existingbooking);
                            response.Message = "Booking Updated Successfully";

                        }

                    }
                

                int result=db.SaveChanges();
                return response;


            }
            
            
        }

       

        public List<Booking> getBookings(int? id)
        {
            using (var db=new DsrContext())
            {
                if (id.HasValue)
                {
                    var result=db.Bookings.Where(h=>h.Id==id).ToList();
                    return result;
                }
                else
                {
                    var result=db.Bookings.ToList();
                    return result;
                }

            }
        }

       
    }
}
