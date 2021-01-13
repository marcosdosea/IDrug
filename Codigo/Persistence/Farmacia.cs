using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Farmacia
    {
        public Farmacia()
        {
            Medicamentodisponivel = new HashSet<Medicamentodisponivel>();
            Usuario = new HashSet<Usuario>();
        }

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

        public virtual ICollection<Medicamentodisponivel> Medicamentodisponivel { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
