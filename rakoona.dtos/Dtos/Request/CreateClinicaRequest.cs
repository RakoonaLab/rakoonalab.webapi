using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace rakoona.services.Dtos.Request
{
    public class CreateClinicaRequest
    {
        [JsonProperty("nombre", Required = Required.Always)]
        public string? Nombre { get; set; }

        [JsonProperty("direccion", Required = Required.AllowNull)]
        public string? Direccion { get; set; }

        [JsonProperty("telefono", Required = Required.AllowNull)]
        public string? Telefono { get; set; }
    }
}
