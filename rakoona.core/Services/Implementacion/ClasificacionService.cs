using Microsoft.EntityFrameworkCore;
using rakoona.core.Context;
using rakoona.core.Entities.Mappers;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Implementacion
{
    public class ClasificacionService : IClasificacionService
    {
        private readonly ApplicationDbContext _context;

        public ClasificacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FamiliaResponse>> GetFamilias()
        {
            if (_context.Familia == null)
                throw new Exception("Validar _context.Familia, es null");


            var familias = await _context.Familia.ToListAsync();

            return familias.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<List<EspecieResponse>> GetEspecies()
        {
            if (_context.Especie == null)
                throw new Exception("Validar _context.Especie, es null");


            var especies = await _context.Especie.ToListAsync();

            return especies.Select(x => x.MapToResponse()).ToList();
        }

        public async Task<List<GeneroAnimalResponse>> GetGenerosPorFamilia(string familiaId)
        {
            if (_context.Familia == null)
                throw new Exception("Validar _context.Familia, es null");
            if (_context.GeneroAnimal == null)
                throw new Exception("Validar _context.GeneroAnimal, es null");


            var familia = await _context.Familia.FirstAsync(x => x.ExternalId == familiaId);

            var generos = await _context.GeneroAnimal.Where(x => x.FamiliaRef == familia.Id).ToListAsync();

            return generos.Select(x => x.MapToResponse()).ToList();
        }

        public async Task<List<RazaResponse>> GetRazasPorEspecie(string especieId)
        {
            if (_context.Especie == null)
                throw new Exception("Validar _context.Especie, es null");
            if (_context.RazaAnimal == null)
                throw new Exception("Validar _context.RazaAnimal, es null");


            var especie = await _context.Especie.FirstAsync(x => x.ExternalId == especieId);

            var razas = await _context.RazaAnimal.Where(x => x.EspecieRef == especie.Id).ToListAsync();

            return razas.Select(x => x.MapToResponse()).ToList();
        }

        public async Task<List<EspecieResponse>> GetEspeciesPorGenero(string generoId)
        {
            if (_context.Especie == null)
                throw new Exception("Validar _context.Especie, es null");
            if (_context.GeneroAnimal == null)
                throw new Exception("Validar _context.GeneroAnimal, es null");


            var genero = await _context.GeneroAnimal.FirstAsync(x => x.ExternalId == generoId);

            var especies = await _context.Especie.Where(x => x.GeneroRef == genero.Id).ToListAsync();

            return especies.Select(x => x.MapToResponse()).ToList();
        }
    }
}
