using Adesso.Project.Domain.Entities.Common;
using Adesso.Project.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adesso.Project.Domain.Entities
{
    public class TravelOffer : BaseEntity
    {
        public string AppUserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; }

        public Guid TravelAdvertId { get; set; }
        [ForeignKey("TravelAdvertId")]
        public TravelAdvert TravelAdvert { get; set; }

        public  string OfferStatus { get; set; } = "Waiting";
    }
}
