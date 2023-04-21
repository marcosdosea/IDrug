using Core;
using Core.Service;

namespace Service
{
    public class SolicitacaoMedicamentoService : ISolicitacaoMedicamentoService
    {
        private readonly DBContext _dbContext;

        public SolicitacaoMedicamentoService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<Solicitacaomedicamento> GetQuery()
        {
            IQueryable<Solicitacaomedicamento> tb_solicitacao = _dbContext.Solicitacaomedicamento;
            var query = from solicitacao in tb_solicitacao select solicitacao;
            return query;
        }

        public void Editar(Solicitacaomedicamento solicitacao)
        {
            _dbContext.Update(solicitacao);
            _dbContext.SaveChanges();
        }

        public int Inserir(Solicitacaomedicamento solicitacao)
        {
            _dbContext.Add(solicitacao);
            _dbContext.SaveChanges();
            return solicitacao.IdSolicitacaoMedicamento;
        }

        public Solicitacaomedicamento Obter(int idSolicitacao)
        {
            IEnumerable<Solicitacaomedicamento> solicitacaomedicamentos = GetQuery().Where(solicitacaoModel => solicitacaoModel.IdSolicitacaoMedicamento.Equals(idSolicitacao));
            return solicitacaomedicamentos.ElementAtOrDefault(0);
        }

        public IEnumerable<Solicitacaomedicamento> ObterPorCPF(string cpf)
        {
            IEnumerable<Solicitacaomedicamento> solicitacaomedicamentos = GetQuery().Where(SolicitacaoMedicamentoModel => SolicitacaoMedicamentoModel.Cpf.StartsWith(cpf));
            return solicitacaomedicamentos;
        }

        public IEnumerable<Solicitacaomedicamento> ObterTodos()
        {
            return GetQuery();
        }

        public void Remover(int idsolicitacao)
        {
            var _solicitacao = _dbContext.Solicitacaomedicamento.Find(idsolicitacao);
            _dbContext.Solicitacaomedicamento.Remove(_solicitacao);
            _dbContext.SaveChanges();
        }
    }
}
