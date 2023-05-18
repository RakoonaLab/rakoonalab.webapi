﻿using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Services.Interfaces;

namespace rakoona.services.Services.Implementacion
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

            var mascota = await _context.Mascotas.SingleAsync(x => x.ExternalId == mascotaId);

            var medico = await _context.Medicos.SingleAsync(x => x.ExternalId == request.MedicoId);

            if (mascota == null)
                throw new Exception("Mascota no encontrada");

            if (medico == null)
                throw new Exception("Medico no encontrado");

            var consulta = request.CreateFromRequest(mascota.Id, medico.Id);

            await _context.Consultas.AddAsync(consulta);
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
