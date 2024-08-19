using Microsoft.AspNetCore.Identity;

namespace HotelListing.Api.Data
{
    public class ApiUser: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    } 
}