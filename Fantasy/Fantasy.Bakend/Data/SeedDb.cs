using Fantasy.Shared.Entities;
using Microsoft.EntityFrameworkCore;

//Creando la base de datos y dando migraciones con codigo
namespace Fantasy.Backend.Data
{
    public class SeedDb
    {
        private readonly FantasyContext _context;

        public SeedDb(FantasyContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();//Si la base de datos no existe, el metodo la crea
            await CheckCountriesAsync();
            await CheckTeamsAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                var countriesSQLScript = File.ReadAllText("Data\\Countries.sql");
                await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
            }
        }

        private async Task CheckTeamsAsync()
        {
            if (!_context.Teams.Any())
            {
                foreach (var country in _context.Countries)
                {
                    _context.Teams.Add(new Team { Name = country.Name, Country = country! });
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}