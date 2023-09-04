using System.Text.Json.Serialization;

namespace APICliente.Models.DTO
{
    public class LogradouroDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Rua { get; set; }
        public int NumeroResidencial { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}
