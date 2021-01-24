﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Models
{
    public class DisponibilizarMedicamentoModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da disponibilização é obrigatório")]
        public int IdDisponibilizacaoMedicamento { get; set; }

        [Display(Name = "Data Início Disponibilização")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicioDisponibilizacao { get; set; }

        [Display(Name = "Data Fim Disponibilização")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFimDisponibilizacao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Lote deve conter entre 5 e 45 caracteres")]
        public string Lote { get; set; }
        public string Quantidade { get; set; }

        [Display(Name = "Validade - Mês")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:MM}", ApplyFormatInEditMode = true)]
        public DateTime ValidadeMes { get; set; }

        [Display(Name = "Validade - Ano")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidadeAno { get; set; }

        public string Status { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }

        public int QuantidadeReservada { get; set; }

        public int QuantidadeEntregue{ get; set; }

        public int QuantidadeDisponivel { get; set; }

        //imagem
    }
}