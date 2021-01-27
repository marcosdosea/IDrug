﻿using System;
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
        [Required(ErrorMessage = "Código da Farmacia é obrigatório")]
        public int IdUsuario { get; set; }

        [Display(Name = "Código Farmacia")]
        [Required(ErrorMessage = "Código da Farmacia é obrigatório")]
        public int IdFarmacia { get; set; }

        public string TipoUsuario { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(12, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(13, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(1, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Sexo { get; set; }

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
        [StringLength(30, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(12, ErrorMessage = "Todos os campos devem ser preenchidos")]
        public string Senha { get; set; }

    }
}