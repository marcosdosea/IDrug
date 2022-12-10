using System.ComponentModel.DataAnnotations;

namespace IdrugWeb.Models
{
    public class UsuarioModel
    {

        public string TipoUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string IdUsuario { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string IdFarmacia { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Por favor, todos os campos devem ser preenchidos")]
        public string Senha { get; set; }

    }
}