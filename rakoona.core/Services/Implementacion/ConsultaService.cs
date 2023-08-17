using Microsoft.EntityFrameworkCore;
using rakoona.core.Context;
using rakoona.core.Entities.Mappers;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request.Consultas;
using rakoona.dtos.Response;

namespace rakoona.core.Services.Implementacion
{
    public class ConsultaService : IConsultaService
    {
        private readonly ApplicationDbContext _context;

        public ConsultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ConsultaResponse> CrearAsync(CreateConsultaRequest request, string mascotaId)
        {
            if (_context.Consultas == null)
                throw new Exception("Validar _context.Consultas, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");
            if (_context.Medicos == null)
                throw new Exception("Validar _context.Medicos, es null");

            var mascota = await _context.Mascotas.Include(x => x.Cartilla).SingleAsync(x => x.ExternalId == mascotaId);

            var medico = await _context.Medicos.SingleAsync(x => x.ExternalId == request.MedicoId);

            if (mascota == null)
                throw new Exception("Mascota no encontrada");

            if (medico == null)
                throw new Exception("Medico no encontrado");

            var consulta = request.CreateFromRequest(mascota.Cartilla.Id, medico.Id);

            if (request.Pulso.HasValue)
            {
                if (_context.MedicionesDePulso == null)
                    throw new Exception("Validar _context.MedicionesDePulso, es null");

                var pulso = PulsoMapper.CreateFromRequest(request.Pulso.Value, mascota.Id, consulta.FechaAplicacion, consulta.FechaDeCreacion);
                await _context.MedicionesDePulso.AddAsync(pulso);
            }
            if (request.Temperatura.HasValue)
            {
                if (_context.MedicionesDeTemperatura == null)
                    throw new Exception("Validar _context.MedicionesDeTemperatura, es null");

                var temperatura = TemperaturaMapper.CreateFromRequest(request.Temperatura.Value, mascota.Id, consulta.FechaAplicacion, consulta.FechaDeCreacion);
                await _context.MedicionesDeTemperatura.AddAsync(temperatura);
            }
            if (request.Peso.HasValue)
            {
                if (_context.MedicionDePeso == null)
                    throw new Exception("Validar _context.MedicionesDePeso, es null");

                var temperatura = PesoMapper.CreateFromRequest(request.Peso.Value, mascota.Id, consulta.FechaAplicacion, consulta.FechaDeCreacion);
                await _context.MedicionDePeso.AddAsync(temperatura);
            }
            if (request.RitmoCardiaco.HasValue)
            {
                if (_context.MedicionesDeRitmoCardiaco == null)
                    throw new Exception("Validar _context.MedicionesDeRitmoCardiaco, es null");

                var temperatura = RitmoCardiacoMapper.CreateFromRequest(request.RitmoCardiaco.Value, mascota.Id, consulta.FechaAplicacion, consulta.FechaDeCreacion);
                await _context.MedicionesDeRitmoCardiaco.AddAsync(temperatura);
            }
            if (request.FrecuenciaRespiratoria.HasValue)
            {
                if (_context.MedicionDeFrecuenciaRespiratoria == null)
                    throw new Exception("Validar _context.MedicionesDeFrecuenciaRespiratoria, es null");

                var temperatura = FrecuenciaRespiratoriaMapper.CreateFromRequest(request.FrecuenciaRespiratoria.Value, mascota.Id, consulta.FechaAplicacion, consulta.FechaDeCreacion);
                await _context.MedicionDeFrecuenciaRespiratoria.AddAsync(temperatura);
            }

            await _context.Consultas.AddAsync(consulta);
            await _context.SaveChangesAsync();

            var response = consulta.MapToResponse();
            if (response != null)
            {
                if (request.Pulso.HasValue)
                    response.Pulso = request.Pulso.Value;
                if (request.Temperatura.HasValue)
                    response.Temperatura = request.Temperatura.Value;
                if (request.Peso.HasValue)
                    response.Peso = request.Peso.Value;
                if (request.RitmoCardiaco.HasValue)
                    response.RitmoCardiaco = request.RitmoCardiaco.Value;
                if (request.FrecuenciaRespiratoria.HasValue)
                    response.FrecuenciaRespiratoria = request.RitmoCardiaco.Value;
            }
            return response;
        }
        public async Task<ConsultaResponse> GetConsultaById(string consultaId)
        {

            var consulta = await _context.Consultas.FirstOrDefaultAsync(x => x.ExternalId == consultaId);
            if (consulta != null)
            {
                var peso = await _context.MedicionDePeso.Where(x => x.FechaDeCreacion == consulta.FechaDeCreacion).FirstOrDefaultAsync();
                var frecRes = await _context.MedicionDeFrecuenciaRespiratoria.Where(x => x.FechaDeCreacion == consulta.FechaDeCreacion).FirstOrDefaultAsync();
                var pulso = await _context.MedicionesDePulso.Where(x => x.FechaDeCreacion == consulta.FechaDeCreacion).FirstOrDefaultAsync();
                var retCard = await _context.MedicionesDeRitmoCardiaco.Where(x => x.FechaDeCreacion == consulta.FechaDeCreacion).FirstOrDefaultAsync();
                var temp = await _context.MedicionesDeTemperatura.Where(x => x.FechaDeCreacion == consulta.FechaDeCreacion).FirstOrDefaultAsync();
            }
            return consulta.MapToResponse();
        }
        public async Task<List<ConsultaResponse>> GetConsultasByMascota(string mascotaId)
        {
            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            var cartilla = await _context.Cartilla.Where(x => x.MascotaRef == mascota.Id)
                .Include(x => x.Consultas)
                .FirstOrDefaultAsync();

            return cartilla.Consultas.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<List<ConsultaResponse>> GetConsultasByClinica(string clinicaId)
        {
            if (_context.Consultas == null)
                throw new Exception("Validar _context.Consultas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");

            var clinica = await _context.Clinicas.SingleAsync(x => x.ExternalId == clinicaId);

            var clienteClinica = await _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .Include(c => c.Cliente)
                    .ThenInclude(c => c.Mascotas)
                        .ThenInclude(c => c.Cartilla)
                            .ThenInclude(c => c.Consultas)
                .Include(c => c.Cliente.Mascotas).ThenInclude(m => m.Duenio)
                .ToListAsync();

            var consultas = clienteClinica.SelectMany(x => x.Cliente.Mascotas.SelectMany(m => m.Cartilla.Consultas)).ToList();

            return consultas.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<List<ConsultaResponse>> GetConsultaByCliente(string clienteId)
        {
            if (_context.Consultas == null)
                throw new Exception("Validar _context.Consultas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");
            if (_context.Clientes == null)
                throw new Exception("Validar _context.Clientes, es null");

            var cliente = await _context.Clientes.SingleAsync(x => x.ExternalId == clienteId);

            var consultas = await _context.Consultas.Where(x => x.Cartilla.Mascota.DuenioRef == cliente.Id).ToListAsync();

            return consultas.Select(x => x.MapToResponse()).ToList();
        }
        public async Task<ConsultaResponse> Update(UpdateConsultaRequest request, string consultaId)
        {
            if (_context.Consultas == null)
                throw new Exception("Validar _context.Consultas, es null");
            if (_context.ClientesClinicas == null)
                throw new Exception("Validar _context.ClientesClinicas, es null");
            if (_context.Clinicas == null)
                throw new Exception("Validar _context.Clinicas, es null");

            var consulta = _context.Consultas.FirstOrDefault(x => x.ExternalId == consultaId);

            if (consulta == null)
                throw new Exception("Consulta No Encontrada");

            var update = request.UpdateFromRequest(consulta);

            await _context.SaveChangesAsync();

            return consulta.MapToResponse();
        }
        public async Task<bool> DeleteAsync(string consultaId)
        {
            if (_context.Consultas == null)
                throw new Exception("Validar _context.Consultas, es null");
            if (_context.Mascotas == null)
                throw new Exception("Validar _context.Mascotas, es null");

            var consulta = await _context.Consultas.SingleAsync(x => x.ExternalId == consultaId);

            if (consulta == null)
                throw new Exception("consulta no encontrada");


            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
