using Microsoft.AspNetCore.Identity;

namespace Adesso.Project.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Isdeleted { get; set; }

        public ICollection<TravelAdvertAppUser> TravelAdverts { get; set; }

    }
}
