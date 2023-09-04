using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICliente.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo Nome deve conter de 3 a 60 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "O campo Email deve conter de 6 a 60 caracteres")]
        public string Email { get; set; } = string.Empty;

        public string Logotipo { get; set; } = string.Empty;

        [ForeignKey("Logradouro")]
        public int  LogradouroId{ get; set; }
        public virtual Logradouro? Logradouro { get; set; }
    }
}
