using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Usuario
    {
        public Usuario()
        {
            Solicitacaomedicamento = new HashSet<Solicitacaomedicamento>();
        }

        public int IdUsuario { get; set; }
        public int IdFarmacia { get; set; }
        public string TipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string Logradouro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Farmacia IdFarmaciaNavigation { get; set; }
        public virtual ICollection<Solicitacaomedicamento> Solicitacaomedicamento { get; set; }
    }
}
