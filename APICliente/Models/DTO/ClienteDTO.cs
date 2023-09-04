using System.Text.Json.Serialization;

namespace APICliente.Models.DTO
{
    public class ClienteDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Logotipo { get; set; }
        public int LogradouroId { get; set; }
    }
}
