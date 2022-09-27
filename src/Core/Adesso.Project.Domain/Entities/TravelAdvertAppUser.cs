using Adesso.Project.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adesso.Project.Domain.Entities
{
    public class TravelAdvertAppUser
    {

        public string AppUserId { get; set; }
        public Guid TravelAdvertId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
        [ForeignKey("TravelAdvertId")]
        public TravelAdvert TravelAdvert { get; set; }
    }
}
