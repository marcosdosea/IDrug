using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Models
{
    public class UsuarioModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código do usuario é obrigatório")]

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome de usuário Obrigatório")]
        public string NomeUsuario { get; set; }

    }
}