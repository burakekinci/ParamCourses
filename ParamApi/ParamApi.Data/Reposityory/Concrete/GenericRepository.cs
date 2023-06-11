using Microsoft.EntityFrameworkCore;
using ParamApi.Data.Context;
using ParamApi.Data.Reposityory.Abstract;

namespace ParamApi.Data.Reposityory.Concrete
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly AppDbContext _appDbContext;
        private DbSet<Entity> _entities;

        public GenericRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
            this._entities = _appDbContext.Set<Entity>();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int entityId)
        {
            //return await _entities.FindAsync(entityId);
            return await _entities.AsNoTracking().Where(e => EF.Property<int>(e, "Id").Equals(entityId)).SingleOrDefaultAsync();
        }

        public async Task InsertAsync(Entity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void RemoveAsync(Entity entity)
        {
            //_entities.Remove(entity);
            _entities.GetType().GetProperty("IsDeleted").SetValue(entity, true); //Soft Delete
        }

        public void Update(Entity entity)
        {
            _entities.Update(entity);
        }
    }
}
