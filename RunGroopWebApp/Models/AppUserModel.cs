using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroopWebApp.Models
{
    public class AppUserModel : IdentityUser
    {
        
        public int? Pace { get; set; }
        public int? Milage { get; set; }
        [ForeignKey("AddressModel")]
        public int? AddressId { get; set; }
        public AddressModel? Address { get; set; }
        public ICollection<ClubModel> Clubs { get; set; }
        public ICollection<RaceModel> Races { get; set; }
    }
}
