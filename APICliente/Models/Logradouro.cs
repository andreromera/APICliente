using System.ComponentModel.DataAnnotations;

namespace APICliente.Models
{
    public class Logradouro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "O campo Cidade deve conter de 4 a 60 caracteres")]
        public string Rua { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo NumeroResidencial é obrigatório")]
        public int NumeroResidencial { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "O campo Bairro deve conter de 2 a 60 caracteres")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O campo Cidade deve conter de 3 a 40 caracteres")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo Estado deve conter 2 caracteres")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O campo Cep deve conter 8 caracteres")]
        public string Cep { get; set; } = string.Empty;
    }
}
