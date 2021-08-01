using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryProject.Concreate;

namespace LibraryProject.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        public Task AddComment(TEntity entity);
        public Task Delete(TEntity entity);
        public Task<TEntity>  GetEntitiesById(int id);
        public Task<IReadOnlyList<TEntity>> GetEntities();
    }   
}
