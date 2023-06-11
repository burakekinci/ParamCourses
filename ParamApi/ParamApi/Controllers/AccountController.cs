using Microsoft.AspNetCore.Mvc;
using ParamApi.Data.UnitOfWork.Abstract;

namespace ParamApi.Controllers
{
    [Route("param/api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await unitOfWork.AccountRepository.GetAllAsync();
            return Ok(accounts);
        }
    }
}
