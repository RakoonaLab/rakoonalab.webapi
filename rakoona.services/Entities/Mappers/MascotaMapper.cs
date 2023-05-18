using Microsoft.IdentityModel.Tokens;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.Pacientes;
using System.Globalization;
using System.Text;

namespace rakoona.services.Entities.Mappers
{
    public static class MascotaMapper
    {
        public static Mascota CreateFromRequest(this CreateMascotaRequest request, int? clienteId)
        {
            var now = DateTime.Now;

            Mascota mascota = new Mascota
            {
                Nombre = request.Nombre,
                Genero = request.Genero,
                Especie = request.Especie,
                Raza = request.Raza,
                ExternalId = Guid.NewGuid().ToString(),
                DiaNacimiento = string.IsNullOrEmpty(request.DiaNacimiento) ? 0 : Int32.Parse(request.DiaNacimiento),
                MesNacimiento = string.IsNullOrEmpty(request.MesNacimiento) ? 0 : Int32.Parse(request.MesNacimiento),
                AnioNacimiento = string.IsNullOrEmpty(request.AnioNacimiento) ? 0 : Int32.Parse(request.AnioNacimiento),
                FechaDeCreacion = now
            };
            if (!request.Colores.IsNullOrEmpty() && request.Colores != null)
            {
                string[] colores = request.Colores.Split(",");
                mascota.Colores = new List<ColorPorMascota>();
                foreach (var color in colores)
                {
                    mascota.Colores.Add(new ColorPorMascota { ExternalId = Guid.NewGuid().ToString(), Nombre = color, FechaDeCreacion = now });
                }
            }

            if (clienteId != null)
                mascota.DuenioRef = clienteId.Value;

            return mascota;
        }

        public static MascotaResponse MapToResponse(this Mascota entity)
        {
            string colores = string.Empty;
            string peso = string.Empty;
            string ultimaConsulta = string.Empty;

            var consulta = entity.Consultas?.OrderByDescending(x => x.FechaAplicacion).FirstOrDefault();
            var consultaPeso = entity.Consultas?.OrderByDescending(x => x.FechaAplicacion).Where(x => x.Peso.HasValue).FirstOrDefault();
            if (consulta != null)
            {
                ultimaConsulta = GetFecha(consulta.FechaAplicacion.Date.Day, consulta.FechaAplicacion.Date.Month, consulta.FechaAplicacion.Date.Year);
            }
            if (consultaPeso != null)
            {
                peso = consultaPeso.Peso.HasValue ? $"{consultaPeso.Peso.Value}Kg, ({GetFecha(consultaPeso.FechaAplicacion.Date.Day, consultaPeso.FechaAplicacion.Date.Month, consultaPeso.FechaAplicacion.Date.Year)})" : string.Empty;
            }


            if (entity.Colores != null)
            {
                colores = String.Join(", ", entity.Colores.Select(x => x.Nombre).ToList().ToArray());
            }


            MascotaResponse response = new()
            {
                Id = entity.ExternalId,
                Nombre = entity.Nombre,
                Genero = entity.Genero,
                Especie = entity.Especie,
                Raza = entity.Raza,
                Edad = GetEdad(entity.AnioNacimiento),
                FechaDeNacimiento = GetFecha(entity.DiaNacimiento, entity.MesNacimiento, entity.AnioNacimiento),
                VacunasCount = 0,
                Peso = peso,
                DuenioNombre = entity.Duenio?.GetNombreCompleto(),
                DuenioId = entity.Duenio?.ExternalId,
                FechaDeCreacion = entity.FechaDeCreacion,
                Colores = colores,
                FechaUltimaConsulta = ultimaConsulta
            };
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
