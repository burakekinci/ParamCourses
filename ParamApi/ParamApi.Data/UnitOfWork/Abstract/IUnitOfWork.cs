﻿using ParamApi.Data.Model;
using ParamApi.Data.Reposityory.Abstract;

namespace ParamApi.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Account> AccountRepository { get; }

        Task CompleteAsync();
    }
}
