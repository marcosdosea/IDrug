using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class FarmaciaService : IFarmaciaService
    {
        private readonly DBContext _context;

        public FarmaciaService(DBContext context)
        {
            _context = context;
        }


        /// <summary>
		/// Atualiza os dados da farmacia na base de dados
		/// </summary>
		/// <param name="farmacia">dados da farmácia</param>

        public void Editar(Farmacia farmacia)
        {
            //throw new NotImplementedException();
            _context.Update(farmacia);
            _context.SaveChanges();
        }

        /// <summary>
		/// Consulta genérica aos dados da farmacia
		/// </summary>
		/// <returns></returns>
		private IQueryable<Farmacia> GetQuery()
        {
            IQueryable<Farmacia> tb_farmacia = _context.Farmacia;
            var query = from farmacia in tb_farmacia
                        select farmacia;
            return query;
        }

        /// <summary>
        /// Obtém todos os farmacias
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Farmacia> ObterTodos()
        {
            return GetQuery();
        }
        /// <summary>
        /// REtorna o número de farmacias cadastrados
        /// </summary>
        /// <returns></returns>
        public int GetNumeroFarmacias()
        {
            return _context.Farmacia.Count();
        }

        /// <summary>
        /// Obtém os dados do primeiro farmacia cadastrado na base de dados.
        /// </summary>
        /// <returns></returns>
        public Farmacia ObterPrimeiraFarmacia()
        {
            Farmacia _tbfarmacia = _context.Farmacia.FirstOrDefault();
            Farmacia farmacia = new Farmacia();
            if (_tbfarmacia != null)
            {
                farmacia.IdFarmacia = _tbfarmacia.IdFarmacia;
                farmacia.Status = _tbfarmacia.Status;
                farmacia.Nome = _tbfarmacia.Nome;
                farmacia.Telefone = _tbfarmacia.Telefone;
            }
            return farmacia;
        }

        /// <summary>
		/// Obtém pelo identificado do farmacia
		/// </summary>
		/// <param name="idFarmacia"></param>
		/// <returns></returns>
        public Farmacia Obter(int idFarmacia)
        {
            IEnumerable<Farmacia> farmacias = GetQuery().Where(farmaciaModel => farmaciaModel.IdFarmacia.Equals(idFarmacia));

            return farmacias.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Insere uma nova farmácia na base de dados
        /// </summary>
        /// <param name="farmacia">dados da farmacia</param>
        /// <returns></returns>
        public int Inserir(Farmacia farmacia)
        {

            _context.Add(farmacia);
            _context.SaveChanges();
            return farmacia.IdFarmacia;

        }

        /// <summary>
		/// Remover farmacia pelo id
		/// </summary>
		/// <returns></returns>
        public void Remover(int idFarmacia)
        {
            var __farmacia = _context.Farmacia.Find(idFarmacia);
            _context.Farmacia.Remove(__farmacia);
            _context.SaveChanges();
        }

        /// <summary>
        /// Insere um novo usuario na base de dados
        /// </summary>
        /// <param name="usuario">dados da usuario</param>
        /// <returns></returns>
        public int InserirUsuario(Usuario usuario)
        {

            _context.Add(usuario);
            _context.SaveChanges();
            return usuario.IdUsuario;
        }

        /// <summary>
		/// Consulta por nome aos dados da farmacia
		/// </summary>
		/// <returns></returns>
        public IEnumerable<Farmacia> ObterPorNome(string nome)
        {
            IEnumerable<Farmacia> farmacia = GetQuery().Where(FarmaciaModel => FarmaciaModel.Nome.StartsWith(nome));
            return farmacia;
        }

        /// <summary>
		/// Consulta por nome aos dados da farmacia com ordem decrecente
		/// </summary>
		/// <returns></returns>
        public IEnumerable<FarmaciaDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

    }
}
