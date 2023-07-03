using ParamApi.Data.Context;
using ParamApi.Data.Model;
using ParamApi.Data.Reposityory.Abstract;
using ParamApi.Data.Reposityory.Concrete;
using ParamApi.Data.UnitOfWork.Abstract;

namespace ParamApi.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _appDbContext;
        private bool _disposed;

        public IGenericRepository<Account> AccountRepository { get; private set; }
        public IGenericRepository<Person> PersonRepository { get; private set; }


        public UnitOfWork(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;

            AccountRepository = new GenericRepository<Account>(appDbContext);
            PersonRepository = new GenericRepository<Person>(appDbContext);
        }


        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    _appDbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    //logging
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
