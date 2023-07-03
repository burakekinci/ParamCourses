using AutoMapper;
using ParamApi.Data.Reposityory.Abstract;
using ParamApi.Data.UnitOfWork.Abstract;

namespace ParamApi.Service
{
    public abstract class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity>
        where TDto : class
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IGenericRepository<TEntity> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

    }
}
