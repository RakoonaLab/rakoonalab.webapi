using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Config.Helpers;
using rakoona.services.Entities.Models.Pacientes;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace rakoona.services.Entities.Mappers
{
    public static class MascotaMapper
    {
        public static Mascota CreateFromRequest(this CreatePacienteRequest request, int? clienteId)
        {
            var a = request.DiaNacimiento.IsStringEmpty() ;
            var b = request.MesNacimiento.IsStringEmpty() ;
            var c = request.AnioNacimiento.IsStringEmpty() ;

            Mascota Paciente = new Mascota
            {
                Nombre = request.Nombre,
                Genero = request.Genero,
                Especie = request.Especie,
                Raza = request.Raza,
                ExternalId = Guid.NewGuid().ToString(),
                DiaNacimiento = request.DiaNacimiento.IsStringEmpty() ? 0 : request.DiaNacimiento.ToNumber(),
                MesNacimiento = request.MesNacimiento.IsStringEmpty() ? 0 : request.MesNacimiento.ToNumber(),
                AnioNacimiento = request.AnioNacimiento.IsStringEmpty() ? 0 : request.AnioNacimiento.ToNumber(),
                FechaDeCreacion = DateTime.Now
            };

            if (clienteId != null)
                Paciente.DuenioRef = clienteId.Value;

            return Paciente;
        }

        public static MascotaResponse MapToResponse(this Mascota entity)
        {
            MascotaResponse response = new MascotaResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                Genero = entity.Genero,
                Especie = entity.Especie,
                Raza = entity.Raza,
                Edad = GetEdad(entity.AnioNacimiento),
                FechaDeNacimiento = GetFechaNacimiento(entity.DiaNacimiento, entity.MesNacimiento, entity.AnioNacimiento) ,
                VacunasCount = entity.ConsultasPreventivas?.Where(x => x.Motivo == "Vacuna").Count(),
                Peso = entity.ConsultasPreventivas?.OrderByDescending(x => x.FechaDeCreacion).FirstOrDefault()?.Peso,
                DuenioNombre= entity.Duenio?.GetNombreCompleto(),
                DuenioId = entity.Duenio?.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }

        private static string GetFechaNacimiento(int? diaNacimiento, int? mesNacimiento, int? anioNacimiento)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();
            if (diaNacimiento.HasValue && diaNacimiento.Value != 0 && mesNacimiento.HasValue && mesNacimiento.Value != 0)
            {
                sb.Append(diaNacimiento.Value + "/");
            }
            if (mesNacimiento.HasValue && mesNacimiento.Value != 0 && anioNacimiento.HasValue && anioNacimiento.Value != 0)
            {
                sb.Append(GetMes(mesNacimiento.Value) + "/");
            }
            if (anioNacimiento.HasValue && anioNacimiento.Value != 0)
            {
                sb.Append(anioNacimiento);
            }

            return sb.ToString();
        }
        private static string GetEdad(int? anioNacimiento)
        {
            var today = DateTime.Today;
            return anioNacimiento.HasValue && anioNacimiento.Value != 0 ?
                today.Year - anioNacimiento.Value + " Años" :
                "";
            
        }
        private static string GetMes(int month)
        {
            DateTime date = new DateTime(2020, month, 1);

            return date.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
        }
    }
}
