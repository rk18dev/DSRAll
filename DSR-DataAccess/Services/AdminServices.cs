using DSR_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DSR_DataAccess.Services.CommonServices;
using DSR_DataAccess.Utils.CustomExceptions;
using DSR_DataAccess.Utils.CommonModels;

namespace DSR_DataAccess.Services
{
    public class AdminServices : IAdminService
    {
        CommonActions _commonActions;
        public AdminServices()
        {
            _commonActions=new CommonActions(); 
        }
        public SuccessResponse AddHotels(Hotel hotel)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Hotel? existinghotel = db.Hotels.Where(w => w.HotelId == hotel.HotelId).SingleOrDefault();

                if (existinghotel == null && hotel.HotelId != 0)
                {
                    //it is not new record and there is no data in table
                    throw new HotelNotFound();
                }
                if (existinghotel == null && hotel.HotelId == 0)
                {
                    //it is new record so insert
                    var dbresult = db.Hotels.Add(hotel);
                    response.Message = "Hotel added successfully";
                }
                else
                {
                    if(existinghotel != null)
                    {
                        existinghotel.HotelName = hotel.HotelName;
                        existinghotel.HotelLocation=hotel.HotelLocation;
                        existinghotel.ImageList = hotel.ImageList;
                        existinghotel.IsActive=hotel.IsActive;
                        db.Hotels.Update(existinghotel);
                        response.Message = "Hotel updated successfully";

                    }

                }
                int result = db.SaveChanges();
                return response;

            }
        }

        public SuccessResponse AddRooms(Room room)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Room? existingroom = db.Rooms.Where(w => w.RoomId == room.RoomId).SingleOrDefault();

                if (existingroom == null && room.RoomId !=0)
                {
                    throw new RoomNotFound();
                }
                else
                {
                 
                     _commonActions.IsHotelAvailable(room.HotelId);

                    if (existingroom == null && room.RoomId == 0)
                    {
                        //roomid is 0 so add new reocrd

                        var dbresult = db.Rooms.Add(room);
                        response.Message = "Room added successfully";
                    }
                    else
                    {
                        if (existingroom != null)
                        {
                            existingroom.HotelId = room.HotelId;
                            existingroom.TotalAcRooms = room.TotalAcRooms;
                            existingroom.TotalNonAcRooms = room.TotalNonAcRooms;
                            existingroom.AmendmentList = room.AmendmentList;
                            existingroom.IsActive = room.IsActive;
                            existingroom.IsAvailable = room.IsAvailable;
                            db.Rooms.Update(existingroom);
                            response.Message = "Room updated successfully";
                        }
                    }
                }


                var resullt = db.SaveChanges();
                return response;
            }
        }

        public SuccessResponse AddAmendments(Amendment amendment)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Amendment? existingamendment=db.Amendments.Where(a=>a.AmendmentId==amendment.AmendmentId).SingleOrDefault();
                if (existingamendment == null && amendment.AmendmentId !=0)
                {
                    throw new AmendmentNotFound();             
                }
                else if (existingamendment == null && amendment.AmendmentId == 0)
                {
                    var dbresult = db.Amendments.Add(amendment);
                    response.Message = "Amendments added successfully";
                }
                else
                {
                    if (existingamendment != null)
                    {
                        existingamendment.Features = amendment.Features;
                        existingamendment.IsActive = amendment.IsActive;
                        db.Amendments.Update(existingamendment);
                        response.Message = "Amendments updated successfully";
                    }

                }


                int result = db.SaveChanges();
                return response;
            }
        }

        public SuccessResponse AddRatings(Rating rating)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Rating? existingrating = db.Ratings.Where(r => r.ReviewId == rating.ReviewId).SingleOrDefault();
                if (existingrating == null && rating.ReviewId != 0)
                {
                    throw new RatingNotFound();
                }
                else
                {
                    _commonActions.IsHotelAvailable(rating.HotelId);

                    if (existingrating == null && rating.ReviewId == 0)
                    {
                        var dbresult = db.Ratings.Add(rating);
                        response.Message = "Rating added successfully";
                    }
                    else
                    {
                        if(existingrating != null)
                        {
                            existingrating.Rating1 = rating.Rating1;
                            existingrating.Comments = rating.Comments;
                            existingrating.ReviewedBy = rating.ReviewedBy;
                            existingrating.ReviewModifiedDate = rating.ReviewModifiedDate;
                            existingrating.HotelId = rating.HotelId;
                            existingrating.IsActive = rating.IsActive;
                            db.Ratings.Update(existingrating);
                            response.Message = "Rating updated successfully";
                        }
                    }
                }
                
                int result = db.SaveChanges();
                return response;
            }
        }

        public SuccessResponse AddContactDetails(ContactDetail contactDetail)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                ContactDetail? existingcontactdetails=db.ContactDetails.Where(c=>c.ContactId==contactDetail.ContactId).SingleOrDefault();
                if (existingcontactdetails == null && contactDetail.ContactId !=0)
                {
                    throw new ContactDetailsNotFound();
                }
                else
                {
                    _commonActions.IsHotelAvailable(contactDetail.HotelId);

                    if (existingcontactdetails == null && contactDetail.ContactId == 0)
                    {
                        var dbresult = db.ContactDetails.Add(contactDetail);
                        response.Message = "ContactDetails added successfully";
                    }
                    else
                    {
                        if (existingcontactdetails != null)
                        {
                            existingcontactdetails.ContactName = contactDetail.ContactName;
                            existingcontactdetails.HotelId= contactDetail.HotelId;
                            existingcontactdetails.IsActive = contactDetail.IsActive;
                            db.ContactDetails.Update(existingcontactdetails);
                            response.Message = "ContactDetails Updated successfully";


                        }
                    }
                }
                
                var result = db.SaveChanges();
                return response;

            }
        }

        public SuccessResponse AddLocations(Location location)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Location? existinglocation = db.Locations.Where(l => l.LocationId == location.LocationId).SingleOrDefault();
                if (existinglocation == null && location.LocationId != 0)
                {
                    throw new LocationNotFound();
                }
                else
                {
                    _commonActions.IsHotelAvailable(location.HotelId);
                    if (existinglocation == null && location.LocationId == 0)
                    {
                        var dbresult = db.Locations.Add(location);
                        response.Message = "Location added successfully";
                    }
                    else
                    {
                        if(existinglocation != null)
                        {
                            existinglocation.City = location.City;
                            existinglocation.Address = location.Address;
                            existinglocation.Latitude = location.Latitude;
                            existinglocation.Longitude = location.Longitude;
                            existinglocation.HotelId = location.HotelId;
                            existinglocation.IsActive = location.IsActive;
                            db.Locations.Update(existinglocation);
                            response.Message = "Location Updated successfully";

                        }
                    }
                }
                
                int result = db.SaveChanges();
                return response;

            }
        }

        public SuccessResponse AddAdditionalGuestCost(AdditionalGuestCost additionalGuestCost)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                AdditionalGuestCost? existingadditionalguestcost = db.AdditionalGuestCosts.Where(a => a.AdditionGuestId == additionalGuestCost.AdditionGuestId).SingleOrDefault();
                if (existingadditionalguestcost == null && additionalGuestCost.AdditionGuestId != 0)
                {
                    throw new AdditionalGuestCostNotFound();
                }
                else if (existingadditionalguestcost == null && additionalGuestCost.AdditionGuestId == 0)
                {
                    var dbresult = db.AdditionalGuestCosts.Add(additionalGuestCost);
                    response.Message = "Additionalguestcost added successfully";

                }
                else
                {
                    if(existingadditionalguestcost != null)
                    {
                        existingadditionalguestcost.AdditionGuestType = additionalGuestCost.AdditionGuestType;
                        existingadditionalguestcost.AdditionGuestCost= additionalGuestCost.AdditionGuestCost;
                        existingadditionalguestcost.IsActive=additionalGuestCost.IsActive;
                        db.AdditionalGuestCosts.Update(existingadditionalguestcost);
                        response.Message = "Additionalguestcost updated successfully";
                    }
                }
                int result = db.SaveChanges();
                return response;

            }
        }

        public SuccessResponse AddUsers(User user)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                User? existinguser=db.Users.Where(u=>u.UserId==user.UserId).SingleOrDefault();
                if (existinguser == null && user.UserId != 0)
                {
                    throw new UserNotFound();
                }
                else if (existinguser == null && user.UserId == 0)
                {
                    var dbresult = db.Users.Add(user);
                    response.Message = "User added successfully";
                }
                else
                {
                    if (existinguser != null)
                    {
                        existinguser.UserName = user.UserName;
                        existinguser.Password = user.Password;
                        existinguser.FullName = user.FullName;
                        existinguser.IsActive = user.IsActive;
                        db.Users.Update(existinguser);
                        response.Message = "User updated successfully";

                    }
                }
                
                int result = db.SaveChanges();
                return response;

            }
        }

        public SuccessResponse AddImages(Image image)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Image? existingimage=db.Images.Where(i=>i.ImageId==image.ImageId).SingleOrDefault();
                if (existingimage == null && image.ImageId != 0)
                {
                    throw new ImageNotFound();

                }
                else if (existingimage == null && image.ImageId == 0)
                {
                    var dbresult = db.Images.Add(image);
                    response.Message = "Image added successfully";
                }
                else
                {
                    if(existingimage != null)
                    {
                        existingimage.ImageUrl = image.ImageUrl;
                        existingimage.IsActive = image.IsActive;
                        db.Images.Update(existingimage);
                        response.Message = "Image updated successfully";

                    }
                }
                
                int result = db.SaveChanges();
                return response;
            }
        }

        public SuccessResponse AddAdmin(Dsradmin dsradmin)
        {
            SuccessResponse response = new SuccessResponse();
            using (var db=new DsrContext())
            {
                Dsradmin? existingadmin = db.Dsradmins.Where(d => d.AdminId == dsradmin.AdminId).SingleOrDefault();
                if (existingadmin == null && dsradmin.AdminId != 0)
                {
                    throw new AdminException();
                }
                else if (existingadmin == null && dsradmin.AdminId == 0)
                {
                    var dbresult = db.Dsradmins.Add(dsradmin);
                    response.Message = "Admin added successfully";
                }
                else
                {
                    if (existingadmin != null)
                    {
                        existingadmin.Username = dsradmin.Username;
                        existingadmin.Password = dsradmin.Password;
                        existingadmin.Fullname = dsradmin.Fullname;
                        existingadmin.IsActive = dsradmin.IsActive;
                        db.Dsradmins.Update(existingadmin);
                        response.Message = "Admin updated successfully";

                    }
                }
                int result = db.SaveChanges();
                return response;

            }
        }



        public List<Hotel> GetHotels(int? hotelid)
        {
            using (var db = new DsrContext())
            {
                if (hotelid.HasValue)
                {
                    var result = db.Hotels.Where(h => h.HotelId == hotelid).ToList();
                    return result;
                }
                else
                {
                    var result = db.Hotels.ToList();
                    return result;
                }
            }
        }

        public List<Room> GetRooms(int? roomid)
        {
            using (var db=new DsrContext())
            {
                if (roomid.HasValue)
                {
                    var result=db.Rooms.Where(r=>r.RoomId==roomid).ToList();
                    return result;
                }
                else
                {
                    var result=db.Rooms.ToList();
                    return result;
                }
            }
        }

        public List<Amendment> GetAmendments(int? amendmentid)
        {
            using (var db=new DsrContext())
            {
                if (amendmentid.HasValue)
                {
                    var result=db.Amendments.Where(a=>a.AmendmentId==amendmentid).ToList();
                    return result;
                }
                else
                {
                    var result=db.Amendments.ToList();
                    return result;
                }

            }
        }

        public List<Rating> GetRatings(int? reviewid)
        {
            using (var db=new DsrContext())
            {
                if (reviewid.HasValue)
                {
                    var result=db.Ratings.Where(r=>r.ReviewId==reviewid).ToList();
                    return result;
                }
                else 
                {
                    var result = db.Ratings.ToList();
                    return result;
                }

            }
           
        }

        public List<ContactDetail> GetContactDetails(int? contactid)
        {
            using (var db=new DsrContext())
            {
                if (contactid.HasValue)
                {
                    var result=db.ContactDetails.Where(c=>c.ContactId==contactid).ToList();
                    return result;
                }
                else
                {
                    var result=db.ContactDetails.ToList();
                    return result;
                }
            }
        }

        public List<Location> GetLocations(int? locationid)
        {
            using (var db=new DsrContext())
            {
                if(locationid.HasValue)
                {
                    var result=db.Locations.Where(l=>l.LocationId==locationid).ToList();
                    return result;
                }
                else
                {
                    var result= db.Locations.ToList();
                    return result;
                }
            }
        }

        public List<AdditionalGuestCost> GetAdditionalGuestCosts(int? additionguestid)
        {
            using (var db=new DsrContext())
            {
                if (additionguestid.HasValue)
                {
                    var result=db.AdditionalGuestCosts.Where(a=>a.AdditionGuestId==additionguestid).ToList();
                    return result;
                }
                else
                {
                    var result=db.AdditionalGuestCosts.ToList();
                    return result;
                }
            }
        }

        public List<User> GetUsers(int? userid)
        {
            using (var db=new DsrContext())
            {
                if (userid.HasValue)
                {
                    var result=db.Users.Where(u=>u.UserId==userid).ToList();
                    return result;

                }
                else
                {
                    var result=db.Users.ToList();
                    return result;
                }
            }
        }

        public List<Image> GetImages(int? imageid)
        {
            using (var db=new DsrContext())
            {
                if (imageid.HasValue) 
                { 
                    var result=db.Images.Where(i=>i.ImageId==imageid).ToList();
                    return result;
                }
                else
                {
                    var result= db.Images.ToList();
                    return result;
                }
            }

        }

        public List<Dsradmin> GetDsradmins(int? adminid)
        {
            using (var db=new DsrContext())
            {
                if (adminid.HasValue)
                {
                    var result = db.Dsradmins.Where(d => d.AdminId == adminid).ToList();
                    return result;
                }
                else
                {
                    var result=db.Dsradmins.ToList();
                    return result;
                }
            }
        }

        //public Dsradmin GetDsradmin(Dsradmin dsradmin)
        //{
        //    using (var db = new DsrContext())
        //    {
        //        Dsradmin dsrresult = db.Dsradmins.Where(x => x.Username == dsradmin.Username && x.Password == dsradmin.Password).SingleOrDefault();
        //        return dsrresult;
        //    }
        //}

    }
}
