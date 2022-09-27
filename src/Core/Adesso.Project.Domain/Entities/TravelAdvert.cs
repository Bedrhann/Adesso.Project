using Adesso.Project.Domain.Entities.Common;
using Adesso.Project.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adesso.Project.Domain.Entities
{
    public class TravelAdvert : BaseEntity
    {
        public string StartingCity { get; set; }
        public string DestinationCity { get; set; }
        public int NumberOfSeat { get; set; }
        public bool AdvertStatus { get; set; } = true;
        public string Description { get; set; }
        public DateTime TravelDate { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
        public ICollection<TravelAdvertAppUser> AppUsers { get; set; }
    }
}
