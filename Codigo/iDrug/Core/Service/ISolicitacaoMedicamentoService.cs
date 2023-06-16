namespace Core.Service;

public interface ISolicitacaoMedicamentoService
{
    public void Editar(Solicitacaomedicamento solicitacao);

    public int Inserir(Solicitacaomedicamento solicitacao);

    public Solicitacaomedicamento Obter(int idSolicitacao);

    public IEnumerable<Solicitacaomedicamento> ObterPorCPF(string nome);

    public IEnumerable<Solicitacaomedicamento> ObterTodos();

    public void Remover(int idsolicitacao);
}
