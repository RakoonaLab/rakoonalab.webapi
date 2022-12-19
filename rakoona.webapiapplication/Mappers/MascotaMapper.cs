using rakoona.services.Dtos.Request;
using rakoona.services.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Pacientes;
using System.Globalization;
using System.Text;

namespace rakoona.webapiapplication.Mappers
{
    public static class MascotaMapper
    {
        public static Mascota CreateFromRequest(this CreatePacienteRequest request, int? clienteId)
        {
            Mascota Paciente = new Mascota
            {
                Nombre = request.Nombre,
                Genero = request.Genero,
                ExternalId = Guid.NewGuid().ToString(),
                DiaNacimiento = request.DiaNacimiento,
                MesNacimiento = request.MesNacimiento,
                AnioNacimiento = request.AnioNacimiento,
                FechaDeCreacion = DateTime.Now
            };

            if (clienteId != null)
                Paciente.DuenioRef = clienteId.Value;

            return Paciente;
        }

        public static PacienteResponse MapToResponse(this Mascota entity)
        {
            var today = DateTime.Today;
            StringBuilder sb = new StringBuilder();
            if (entity.DiaNacimiento.HasValue)
            {
                sb.Append(entity.DiaNacimiento.Value + "/");
            }
            if (entity.MesNacimiento.HasValue)
            {
                sb.Append(getFullName(entity.MesNacimiento.Value) + "/");
            }
            if (entity.AnioNacimiento.HasValue)
            {
                sb.Append(entity.AnioNacimiento.Value);
            }

            PacienteResponse response = new PacienteResponse
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                Genero = entity.Genero,
                Edad = entity.AnioNacimiento.HasValue ? (today.Year - entity.AnioNacimiento.Value) + " Años" : null,
                FechaDeNacimiento = sb.ToString(),
                Vacunas = entity.Vacunas?.Count(),
                FechaDeCreacion = entity.FechaDeCreacion,
            };
            return response;
        }

        static string getFullName(int month)
        {
            DateTime date = new DateTime(2020, month, 1);

            return date.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
        }
    }
}
