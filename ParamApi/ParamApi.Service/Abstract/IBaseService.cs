using ParamApi.Base;

namespace ParamApi.Service
{
    public interface IBaseService<TDto, TEntity>
    {
        Task<BaseResponse<TDto>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<TDto>>> GetAllAsync();
        Task<BaseResponse<TDto>> InsertAsync(TDto insertResource);
        Task<BaseResponse<TDto>> UpdateAsync(int id, TDto insertResource);
        Task<BaseResponse<TDto>> RemoveAsync(int id);

    }
}
