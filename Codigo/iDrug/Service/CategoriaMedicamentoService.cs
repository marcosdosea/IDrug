using Core;
using Core.DTO;
using Core.Service;

namespace Service
{
    public class CategoriaMedicamentoService : ICategoriaMedicamentoService
    {
        private readonly DBContext __context;

        public CategoriaMedicamentoService(DBContext context)
        {
            __context = context;
        }


        /// <summary>
        /// Insere uma categoria de medicamento na base de dados
        /// </summary>
        /// <param name="categoria medicamento">dados do medicamento</param>
        /// <returns></returns>
        public int Inserir(Categoriamedicamento categoriaMedicamento)
        {
            __context.Add(categoriaMedicamento);
            __context.SaveChanges();
            return categoriaMedicamento.IdCategoriaMedicamento;
        }


        /// <summary>
        /// Atualiza os dados de uma categoria de medicamento na base de dados
        /// </summary>
        /// <param name="categoria medicamento">dados do medicamento</param>
        public void Editar(Categoriamedicamento categoriaMedicamento)
        {
            __context.Update(categoriaMedicamento);
            __context.SaveChanges();
        }


        /// <summary>
        /// Remove uma categoria de medicamento da base de dados
        /// </summary>
        /// <param name="idCategoriaMedicamento">identificando o medicamento</param>
        public void Remover(int idCategoriaMedicamento)
        {
            var __categoriaMedicamento = __context.Categoriamedicamento.Find(idCategoriaMedicamento);
            __context.Categoriamedicamento.Remove(__categoriaMedicamento);
            __context.SaveChanges();
        }


        /// <summary>
        /// Consulta genérica a todas as categorias de medicamento
        /// </summary>
        /// <return></return>
        private IQueryable<Categoriamedicamento> GetQuery()
        {
            IQueryable<Categoriamedicamento> Categoriamedicamento = __context.Categoriamedicamento;
            var query = from categoriaMedicamento in Categoriamedicamento select categoriaMedicamento;
            return query;
        }


        /// <summary>
        /// Obtém todas as categorias de medicamentos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoriamedicamento> ObterTodos()
        {
            return GetQuery();
        }



        /// <summary>
        /// Retorna o número de categoria de medicamentos cadastrados
        /// </summary>
        /// <returns></returns>
        public int GetNumeroMedicamentos()
        {
            return __context.Categoriamedicamento.Count();
        }


        /// <summary>
        /// Obtém os dados da primeira categoria de medicamento cadastrada na base de dados
        /// </summary>
        /// <returns></returns>
        public Categoriamedicamento Obter(int idCategoriaMedicamento)
        {
            IEnumerable<Categoriamedicamento> categoriaMedicamento = GetQuery().Where(categoriaMedicamentoModel => categoriaMedicamentoModel.IdCategoriaMedicamento.Equals(idCategoriaMedicamento));
            return categoriaMedicamento.ElementAtOrDefault(0);
        }


        /// <summary>
        /// Obtém categoria medicamento que iniciam com o nome
        /// </summary>
        /// <param name="categoria medicamento">nome a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<Categoriamedicamento> ObterPorNome(string nome)
        {
            IEnumerable<Categoriamedicamento> categoriaMedicamento = GetQuery().Where(categoriaMedicamentoModel => categoriaMedicamentoModel.NomeCategoria.StartsWith(nome));
            return categoriaMedicamento;
        }


        public IEnumerable<CategoriaMedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Categoriamedicamento> Categoriamedicamento = __context.Categoriamedicamento;
            var query = from categoriaMedicamento in Categoriamedicamento
                        where nome.StartsWith(nome)
                        orderby categoriaMedicamento.NomeCategoria descending
                        select new CategoriaMedicamentoDTO
                        {
                            Nome = categoriaMedicamento.NomeCategoria
                        };
            return query;
        }
    }
}
