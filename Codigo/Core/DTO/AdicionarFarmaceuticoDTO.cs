using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class AdicionarFarmaceuticoDTO
    {
        public int IdUsuario { get; set; }
        public int IdFarmacia { get; set; }
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
