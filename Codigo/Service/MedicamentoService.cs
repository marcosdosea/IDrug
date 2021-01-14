using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly DBContext __context;

        public MedicamentoService(DBContext context)
        {
            __context = context;
        }

        
        /// <summary>
        /// Insere um novo medicamento na base de dados
        /// </summary>
        /// <param name="medicamento">dados do medicamento</param>
        /// <returns></returns>
        public int Inserir(Medicamento medicamento)
        {
            __context.Add(medicamento);
            __context.SaveChanges();
            return medicamento.IdMedicamento;
        }


        /// <summary>
        /// Atualiza os dados do medicamento na base de dados
        /// </summary>
        /// <param name="medicamento">dados do medicamento</param>
        public void Editar(Medicamento medicamento)
        {
            __context.Update(medicamento);
            __context.SaveChanges();
        }


        /// <summary>
        /// Remove um medicamento da base de dados
        /// </summary>
        /// <param name="idMedicamento">identificando o medicamento</param>
        public void Remover(int idMedicamento)
        {
            var __medicamento = __context.Medicamento.Find(idMedicamento);
            __context.Medicamento.Remove(__medicamento);
            __context.SaveChanges();
        }


        /// <summary>
        /// Consulta genérica aos dados do medicamento
        /// </summary>
        /// <return></return>
        private IQueryable<Medicamento> GetQuery()
        {
            IQueryable<Medicamento> Farmacia = __context.Medicamento;
            var query = from medicamento in Farmacia select medicamento;
            return query;
        }


        /// <summary>
        /// Obtém todos os medicamentos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Medicamento> ObterTodos()
        {
            return GetQuery();
        }
        

        
        /// <summary>
        /// Retorna o número de medicamentos cadastrados
        /// </summary>
        /// <returns></returns>
        public int GetNumeroMedicamentos()
        {
            return __context.Medicamento.Count();
        }


        /// <summary>
        /// Obtém os dados do primeiro medicamento cadastrado na base de dados
        /// </summary>
        /// <returns></returns>
        public Medicamento Obter(int idMedicamento)
        {
            IEnumerable<Medicamento> medicamentos = GetQuery().Where(medicamentoModel => medicamentoModel.IdMedicamento.Equals(idMedicamento));
            return medicamentos.ElementAtOrDefault(0);
        }


        /// <summary>
        /// Obtém medicamentos que iniciam com o nome
        /// </summary>
        /// <param name="medicamento">nome a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<Medicamento> ObterPorNome(string nome)
        {
            IEnumerable<Medicamento> medicamentos = GetQuery().Where(medicamentoModel => medicamentoModel.Nome.StartsWith(nome));
            return medicamentos;
        }


        public IEnumerable<MedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Medicamento> Farmacia = __context.Medicamento;
            var query = from medicamento in Farmacia
                        where nome.StartsWith(nome)
                        orderby medicamento.Nome descending
                        select new MedicamentoDTO
                        {
                            Nome = medicamento.Nome
                        };
            return query;
         }

    }
}
