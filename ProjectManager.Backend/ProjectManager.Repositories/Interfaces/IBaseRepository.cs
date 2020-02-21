using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Lista todos os registro do banco
        /// </summary>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// Busca determinado registro no banco
        /// </summary>
        /// <param name="id"> id do registro ser buscado </param>
        /// <returns> Retorna o registro do banco</returns>
        Task<T> Get(object id);

        /// <summary>
        /// Persite uma entidade no banco
        /// </summary>
        /// <param name="entity"> Entidade a ser persisitido </param>
        /// <returns>Retorna a entidade já persistida no banco</returns>
        Task<T> Save(T entity);

        /// <summary>
        /// Atualiza um registro no banco
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        Task Update(T entity);

        /// <summary>
        /// Atualiza um range de registros no banco
        /// </summary>
        /// <param name="entity">Lista de Entidades a serem atualizadas</param>
        Task UpdateRange(List<T> entity);

        /// <summary>
        /// Remove um registro no banco
        /// </summary>
        /// <param name="id">Id da entidade a ser removida</param>
        Task Delete(long id);

        /// <summary>
        /// Remove um range de registros no banco
        /// </summary>
        /// <param name="entity">Lista de Entidades a serem atualizadas</param>
        Task DeleteRange(List<T> entity);
    }
}