using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Models
{
    public class FarmaciaModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da Farmácia é obrigatório")]
        public int IdFarmacia { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, ErrorMessage = "Nome da farmácia deve ter entre 5 e 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(14, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(13, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(6, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(2, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(25, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(25, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(7, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Status { get; set; }

    }
}
