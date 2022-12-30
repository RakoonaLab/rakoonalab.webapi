﻿using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
{
    public class MascotaService : IMascotaService
    {
        private readonly ApplicationDbContext _context;

        public MascotaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationResponse> CreateAsync(CreatePacienteRequest request, string clienteId)
        {
            if (_context.Mascotas == null)
                return new ApplicationResponse("Entity set 'ApplicationDbContext.Pacientes' is null.");
            if (_context.Clientes == null)
                return new ApplicationResponse("Entity set 'ApplicationDbContext.Clientes' is null.");

            var cliente = await _context.Clientes.SingleAsync(x => x.ExternalId == clienteId);

            if (cliente == null)
                return new ApplicationResponse();

            var paciente = request.CreateFromRequest(cliente.Id);

            await _context.Mascotas.AddAsync(paciente);
            await _context.SaveChangesAsync();

            return new ApplicationResponse(paciente.MapToResponse());
        }

        public async Task<ApplicationResponse> GetAsync(string mascotaId)
        {
            if (_context.Mascotas == null)
                return new ApplicationResponse("Entity set 'ApplicationDbContext.Pacientes' is null.");

            var mascota = await _context.Mascotas.Where(x => x.ExternalId == mascotaId)
                .Include(x => x.Duenio)
                .FirstOrDefaultAsync();

            if (mascota == null)
                return new ApplicationResponse();

            return new ApplicationResponse(mascota.MapToResponse());
        }
    }
}
