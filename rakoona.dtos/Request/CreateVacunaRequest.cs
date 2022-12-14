using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace rakoona.dtos.Request
{
    public class CreateVacunaRequest
    {
        [JsonProperty("nombre", Required = Required.Always)]
        public string? Nombre { get; set; }
    }
}
