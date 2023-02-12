using System.ComponentModel.DataAnnotations;

namespace IdrugWeb.Models
{
    public class FarmaciaModel
    {
        [Display(Name = "Código:")]
        [Key]
        [Required(ErrorMessage = "Código da Farmácia é obrigatório")]
        public int IdFarmacia { get; set; }

        [Display(Name = "Nome da Farmácia:")]
        [Required(ErrorMessage = "Nome da Faramácia requerido")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Nome da farmácia deve ter entre 5 e 60 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ:")]
        [Required(ErrorMessage = "CNPJ requerido")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessage = "Digite um CNPJ válido")]
        public string Cnpj { get; set; }

        [Display(Name = "Telefone:")]
        [Required(ErrorMessage = "Telefone requerido")]
        [RegularExpression(@"^(\([1-9]{2}\)|[1-9]{2}) ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Exemplo de numero de telefone: (12)12345-6789")]
        public string Telefone { get; set; }

        [Display(Name = "CEP:")]
        [Required(ErrorMessage = "CEP requerido")]
        [StringLength(6, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cep { get; set; }

        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "Endereço requerido")]
        [StringLength(60, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Logradouro { get; set; }

        [Display(Name = "Estado:")]
        [Required(ErrorMessage = "Estado requerido")]
        [StringLength(2, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Estado { get; set; }

        [Display(Name = "Cidade:")]
        [Required(ErrorMessage = "Cidade requerido")]
        [StringLength(25, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cidade { get; set; }


        [Display(Name = "Bairro:")]
        [Required(ErrorMessage = "Bairro requerido")]
        [StringLength(25, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Bairro { get; set; }

        [Display(Name = "Status:")]
        public string? Status { get; set; }

    }
}
