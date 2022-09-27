using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Project.Application.DTOs.TravelAdvertDTOs
{
    public class GetTravelAdvertDto
    {
        public string StartingCity { get; set; }
        public string DestinationCity { get; set; }
        public string AppUserId { get; set; }
        public int NumberOfSeat { get; set; }
        public string Description { get; set; }
        public DateTime TravelDate { get; set; }
    }
}
