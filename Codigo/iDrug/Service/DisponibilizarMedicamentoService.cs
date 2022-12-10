using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DisponibilizarMedicamentoService : IDisponibilizarMedicamentoService
    {

        private readonly DBContext __context;

        public DisponibilizarMedicamentoService(DBContext context)
        {
            __context = context;
        }

        /// <summary>
        /// Insere uma nova disponibilização de medicamento na base de dados
        /// </summary>
        /// <param name="medicamento">dados do medicamento</param>
        /// <returns></returns>
        public int Inserir(Medicamentodisponivel medicamento)
        {
            __context.Add(medicamento);
            __context.SaveChanges();
            return medicamento.IdDisponibilizacaoMedicamento;
        }


        /// <summary>
        /// Atualiza os dados do medicamento na base de dados
        /// </summary>
        /// <param name="medicamento">dados do medicamento</param>
        public void Editar(Medicamentodisponivel medicamento)
        {
            __context.Update(medicamento);
            __context.SaveChanges();
        }


        /// <summary>
        /// Remove um medicamento da base de dados
        /// </summary>
        /// <param name="idDisponibilizacaoMedicamento">identificando a disponibilização do medicamento</param>
        public void Remover(int idDisponibilizacaoMedicamento)
        {
            var __medicamentodisponivel = __context.Medicamentodisponivel.Find(idDisponibilizacaoMedicamento);
            __context.Medicamentodisponivel.Remove(__medicamentodisponivel);
            __context.SaveChanges();
        }


        /// <summary>
        /// Consulta genérica aos dados da disponibilização do medicamento
        /// </summary>
        /// <return></return>
        private IQueryable<Medicamentodisponivel> GetQuery()
        {
            IQueryable<Medicamentodisponivel> Farmacia = __context.Medicamentodisponivel;
            var query = from medicamento in Farmacia select medicamento;
            return query;
        }


        /// <summary>
        /// Obtém todos os medicamentos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Medicamentodisponivel> ObterTodos()
        {
            return GetQuery();
        }



        /// <summary>
        /// Retorna o número de medicamentos cadastrados
        /// </summary>
        /// <returns></returns>
        public int GetNumeroMedicamentos()
        {
            return __context.Medicamentodisponivel.Count();
        }


        /// <summary>
        /// Obtém os dados do primeiro medicamento cadastrado na base de dados
        /// </summary>
        /// <returns></returns>
        public Medicamentodisponivel Obter(int idDisponibilizacaoMedicamento)
        {
            IEnumerable<Medicamentodisponivel> disponibilizacoes = GetQuery().Where(disponibilizarMedicamentoModel => disponibilizarMedicamentoModel.IdDisponibilizacaoMedicamento.Equals(idDisponibilizacaoMedicamento));
            return disponibilizacoes.ElementAtOrDefault(0);
        }


        /// <summary>
        /// Obtém medicamentos que iniciam com o nome
        /// </summary>
        /// <param name="medicamento">nome a ser buscado</param>
        /// <returns></returns>
         /*public IEnumerable<Medicamentodisponivel> ObterPorNome(string nome)
        {
            IEnumerable<Medicamentodisponivel> medicamentos = GetQuery().Where(disponibilizarMedicamentoModel => disponibilizarMedicamentoModel.Nome.StartsWith(nome));
            return medicamentos;
        }


       public IEnumerable<DisponibilizarMedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Medicamentodisponivel> Farmacia = __context.Medicamentodisponivel;
            var query = from medicamento in Farmacia
                        where nome.StartsWith(nome)
                        orderby medicamento.descending
                        select new DisponibilizarMedicamentoDTO
                        {
                            Nome = medicamento.Nome
                        };
            return query;
        }*/
    }
}
