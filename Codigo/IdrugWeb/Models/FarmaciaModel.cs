using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Models
{
    public class FarmaciaModel
    {
        [Display(Name = "Código:")]
        [Key]
        [Required(ErrorMessage = "Código da Farmácia é obrigatório")]
        public int IdFarmacia { get; set; }

        [Display(Name = "Nome da Farmácia:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Nome da farmácia deve ter entre 3 e 60 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(14, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cnpj { get; set; }

        [Display(Name = "Telefone:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(13, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Telefone { get; set; }

        [Display(Name = "CEP:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(6, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cep { get; set; }

        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Logradouro { get; set; }

        [Display(Name = "Estado:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(2, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Estado { get; set; }

        [Display(Name = "Cidade:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(25, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro:")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(25, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Bairro { get; set; }

        [Display(Name = "Status:")]
        public string Status { get; set; }

    }
}
