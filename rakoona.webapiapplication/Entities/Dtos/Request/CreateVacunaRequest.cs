using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace rakoona.webapiapplication.Entities.Dtos.Request
{
    public class CreateVacunaRequest
    {
        [JsonProperty("nombre", Required = Required.Always)]
        public string? Nombre { get; set; }
    }
}
