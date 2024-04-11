using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<RaceModel>> GetAll();
        Task<RaceModel> GetByIdAsync(int id);
        Task<IEnumerable<RaceModel>> GetAllRacesByCity(string city);
        bool Add(RaceModel race);
        bool Update(RaceModel race);    
        bool Delete(RaceModel race);
        bool Save();

    }
}
