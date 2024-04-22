using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<ClubModel>> GetAll();
        Task<ClubModel> GetByIdAsync(int id);
        Task<ClubModel> GetByIdAsyncAsNoTracking(int id);
        Task<IEnumerable<ClubModel>> GetClubByCity(string city);
        bool Add(ClubModel club);
        bool Update(ClubModel club);
        bool Delete(ClubModel club);    
        bool Save();  
    }
}
