using DSR_DataAccess.Models;
using DSR_DataAccess.Utils.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_DataAccess.Services
{
    public interface IAdminService
    {

        SuccessResponse AddHotels(Hotel hotel);
        SuccessResponse AddRooms(Room room);
        SuccessResponse AddAmendments(Amendment amendment);
        SuccessResponse AddRatings(Rating rating);
        SuccessResponse AddContactDetails(ContactDetail contactDetail);
        SuccessResponse AddLocations(Location location);
        SuccessResponse AddAdditionalGuestCost(AdditionalGuestCost additionalGuestCost);
        SuccessResponse AddUsers(User user);
        SuccessResponse AddImages(Image image);
        SuccessResponse AddAdmin(Dsradmin dsradmin);



        List<Hotel> GetHotels(int? hotelid );
        List<Room> GetRooms(int? roomid);
        List<Amendment> GetAmendments(int? amendmentid);
        List<Rating> GetRatings(int? reviewid);
        List<ContactDetail> GetContactDetails(int? contactid);
        List<Location> GetLocations(int? locationid);
        List<AdditionalGuestCost> GetAdditionalGuestCosts(int? additionguestid);
        List<User> GetUsers(int? userid);
        List<Image> GetImages(int? imageid);
        List<Dsradmin> GetDsradmins(int? adminid);
         //Dsradmin GetDsradmin(Dsradmin dsradmin);


    }
}
