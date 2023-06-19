using Microsoft.AspNetCore.Mvc;
using ParamApi.Data.Model;
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

        [HttpGet("GetByIdQuery")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var account = await unitOfWork.AccountRepository.GetByIdAsync(id);

            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            account.CreatedAt = DateTime.UtcNow;
            account.CreatedBy = "SystemUser";

            await unitOfWork.AccountRepository.InsertAsync(account);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction("GetById", new { account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Account account)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var item = await unitOfWork.AccountRepository.GetByIdAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            item.Name = account.Name;
            item.UserName = account.UserName;
            item.Email = account.Email;

            item.LastActivity = DateTime.UtcNow;

            unitOfWork.AccountRepository.Update(item);
            await unitOfWork.CompleteAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var item = await unitOfWork.AccountRepository.GetByIdAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            unitOfWork.AccountRepository.RemoveAsync(item);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }

    }
}
