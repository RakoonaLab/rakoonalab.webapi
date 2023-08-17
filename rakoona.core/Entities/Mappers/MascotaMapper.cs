using Microsoft.IdentityModel.Tokens;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.core.Entities.Models.Pacientes;
using System.Globalization;
using System.Text;

namespace rakoona.core.Entities.Mappers
{
    internal static class MascotaMapper
    {
        internal static Mascota CreateFromRequest(this CreateMascotaRequest request, int? clienteId)
        {
            var now = DateTime.Now;

            Mascota mascota = new Mascota
            {
                Nombre = request.Nombre,
                Genero = request.Genero,
                ExternalId = Guid.NewGuid().ToString(),
                DiaNacimiento = string.IsNullOrEmpty(request.DiaNacimiento) ? 0 : Int32.Parse(request.DiaNacimiento),
                MesNacimiento = string.IsNullOrEmpty(request.MesNacimiento) ? 0 : Int32.Parse(request.MesNacimiento),
                AnioNacimiento = string.IsNullOrEmpty(request.AnioNacimiento) ? 0 : Int32.Parse(request.AnioNacimiento),
                FechaDeCreacion = now
            };
            if (!request.Colores.IsNullOrEmpty() && request.Colores != null)
            {
                string[] colores = request.Colores.Split(",");
                foreach (var color in colores)
                {
                    //mascota.Colores.Add(new Color { ExternalId = Guid.NewGuid().ToString(), Nombre = color, FechaDeCreacion = now });
                }
            }

            if (clienteId != null)
                mascota.DuenioRef = clienteId.Value;

            return mascota;
        }
        internal static MascotaResponse MapToResponse(this Mascota mascota)
        {
            MascotaResponse response = new()
            {
                Id = mascota.ExternalId,
                Nombre = mascota.Nombre,
                Genero = mascota.Genero,
                Edad = GetEdad(mascota.AnioNacimiento),
                FechaDeNacimiento = GetFecha(mascota.DiaNacimiento, mascota.MesNacimiento, mascota.AnioNacimiento),
                DuenioNombre = mascota.Duenio?.GetNombreCompleto(),
                DuenioId = mascota.Duenio?.ExternalId,
                FechaDeCreacion = mascota.FechaDeCreacion
            };

            var consulta = mascota.Cartilla?.Consultas?.OrderByDescending(x => x.FechaAplicacion).FirstOrDefault();
            if (consulta != null)
            {
                response.FechaUltimaConsulta = GetFecha(consulta.FechaAplicacion.Date.Day, consulta.FechaAplicacion.Date.Month, consulta.FechaAplicacion.Date.Year);
            }

            var peso = mascota.MedicionesDePeso?.OrderByDescending(x => x.FechaAplicacion).FirstOrDefault();
            if (peso != null)
            {
                response.Peso = $"{peso.Valor}Kg, ({GetFecha(peso.FechaAplicacion.Date.Day, peso.FechaAplicacion.Date.Month, peso.FechaAplicacion.Date.Year)})";
            }

            //if (mascota.Colores != null)
            //{
            //    response.Colores = String.Join(", ", mascota.Colores.Select(x => x.Nombre).ToList().ToArray());
            //}

            return response;
        }
        private static string GetFecha(int? diaNacimiento, int? mesNacimiento, int? anioNacimiento)
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
