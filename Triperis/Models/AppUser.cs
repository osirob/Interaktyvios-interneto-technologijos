using Microsoft.AspNetCore.Identity;

namespace Triperis.Models
{
    public class AppUser : IdentityUser<int>
    {
        //email, password and username are inherited from identityUser
        //roles are also taken care of by identityUser
        public bool CanCreateListings { get; set; }
        public bool CanComment { get; set; }

        //Relationship with cars
        public List<Car> Cars { get; set; }
    }
}
