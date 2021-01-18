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
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Nome da farmácia deve ter entre 5 e 60 caracteres")]
        public string Nome { get; set; }


        public string Cnpj { get; set; }

        public string Telefone { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Status { get; set; }


    }
}
