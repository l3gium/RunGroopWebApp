namespace RunGroopWebApp.Models
{
    public class AppUserModel
    {
        public string Id { get; set; }
        public int? Pace { get; set; }
        public int? Milage { get; set; }
        public AddressModel? Address { get; set; }
        public ICollection<ClubModel> Clubs { get; set; }
        public ICollection<RaceModel> Races { get; set; }
    }
}
