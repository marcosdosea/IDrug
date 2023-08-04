using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using System.IO;
using System.Data.Common;

namespace Service
{
    public class DisponibilizarMedicamentoService : IDisponibilizarMedicamentoService
    {

        private readonly DBContext __context;
        private MySqlConnection connection;


        public DisponibilizarMedicamentoService(DBContext context)
        {
            __context = context;
            connection = new MySqlConnection("server=localhost;port=3306;user=root;password=123456;database=bd_idrug");
        }

        /// <summary>
        /// Insere uma nova disponibilização de medicamento na base de dados
        /// </summary>
        /// <param name="medicamento">dados do medicamento</param>
        /// <returns></returns>
        /// 
        //ANOTAÇÂO: Aqui ele está chegando com os bytes da imagem, porem esses bytes não estão sendo inseridos
        public int Inserir(Medicamentodisponivel medicamento)
        {
            __context.Add(medicamento);
            __context.SaveChanges();

            //Salvando imagem

            
                connection.Open();

                string query = $"UPDATE bd_idrug.medicamentodisponivel set imagem = @blobData where idDisponibilizacaoMedicamento = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@blobData", medicamento.Imagem);
                    command.Parameters.AddWithValue("@id", medicamento.IdDisponibilizacaoMedicamento);
                    command.ExecuteNonQuery();
                }

                connection.Close();


        

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


        private byte[] getImageFromId(int id)
        {
            string query = $"SELECT imagem FROM bd_idrug.medicamentodisponivel where idDisponibilizacaoMedicamento = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
            {
                //Console.WriteLine(rdr[0]+" -- "+rdr[1]);
            }

                return (byte[])rdr[0];
            }
        }

        /// <summary>
        /// Consulta genérica aos dados da disponibilização do medicamento
        /// </summary>
        /// <return></return>
        private IQueryable<Medicamentodisponivel> GetQuery()
        {
            IQueryable<Medicamentodisponivel> Farmacia = __context.Medicamentodisponivel;
            var query = from medicamento in Farmacia select medicamento;
            connection.Open();

            query.ForEachAsync(item =>
            {
                item.Imagem = getImageFromId(item.IdDisponibilizacaoMedicamento);
            });

            connection.Close();

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
