using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(RaceModel race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Delete(RaceModel race)
        {
            _context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<RaceModel>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<RaceModel> GetByIdAsync(int id)
        {
            return await _context.Races.Include(r => r.Address).FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<RaceModel> GetByIdAsyncAsNoTracking(int id)
        {
            return await _context.Races.Include(r => r.Address).AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RaceModel>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(r => r.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(RaceModel race)
        {
            _context.Update(race);
            return Save();
        }
    }
}
