using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Parameters;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<List<ClienteResponse>>> GetClientesByClinica(string clinicaId, SearchClienteParameters parameters, PaginationParameters pagination)
        {
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");
            if (_context.InformacionDeContacto == null)
                throw new Exception("Validar _context.InformacionDeContacto, es null");
            if (_context.Clientes == null)
                throw new Exception("Validar _context.Clientes, es null");


            var clinica = await _context.Clinicas.SingleAsync(x => x.ExternalId == clinicaId);

            var query = _context.ClientesClinicas.Where(x => x.Clinica.ExternalId == clinicaId);
            query = query.Include(x => x.Cliente);

            query = query.OrderBy(x => x.Cliente.Nombres);
            if (pagination.Page > 1)
            {
                query = query.Skip(pagination.Page-1 * pagination.PageSize);
            }
            query = query.Take(pagination.PageSize);

            query = query.Include(x => x.Cliente)
                .ThenInclude(x => x.Domicilios.Where(d => d.Principal));

            query = query.Include(x => x.Cliente)
                .ThenInclude(x => x.Mascotas);

            query = query.Include(x => x.Cliente)
                 .ThenInclude(x => x.InformacionDeContacto);

            if (!string.IsNullOrEmpty(parameters.Celular))
            {
                var celular = parameters.Celular;
                query = query.Where(x => x.Cliente.InformacionDeContacto.Any(c => c.ContactType == "Celular" &&
                                                                            (c.Valor.Contains(celular) ||
                                                                            c.Valor.StartsWith(celular) ||
                                                                            c.Valor.EndsWith(celular) ||
                                                                            c.Valor == celular)));
            }

            if (!string.IsNullOrEmpty(parameters.Nombres))
            {
                var nombres = parameters.Nombres;
                query = query.Where(x => !string.IsNullOrEmpty(x.Cliente.Nombres) && x.Cliente.Nombres.Contains(nombres));
            }

            if (!string.IsNullOrEmpty(parameters.Apellidos))
            {
                var apellidos = parameters.Apellidos;
                query = query.Where(x => !string.IsNullOrEmpty(x.Cliente.Apellidos) && x.Cliente.Apellidos.Contains(apellidos));
            }

            

            

            var clientes = query.ToList();
            
            return new PagedResponse<List<ClienteResponse>>(pagination.Page,
                pagination.PageSize, 
                clientes.Select(x => x.Cliente.MapToResponse()).ToList(),
                _context.ClientesClinicas.Where(x => x.Clinica.ExternalId == clinicaId).Count());
        }
    }
}
