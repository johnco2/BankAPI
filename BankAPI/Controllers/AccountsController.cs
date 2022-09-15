using BankAPI.Repository;
using BankAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _account;

        public AccountsController(IAccountRepository Account)
        {
            _account = Account ?? throw new ArgumentNullException(nameof(Account));
        }

        [HttpGet]
        [Route("GetAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(await _account.GetAccounts());
        }

        [HttpGet]
        [Route("GetAccountsById/{id}")]
        public async Task<IActionResult> GetAccountsById(int id)
        {
            return Ok(await _account.GetAccountById(id));
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<IActionResult> InsertAnAccount(VMAccount account)
        {
            return Ok(await _account.InsertAccount(VMAccount.ToEntity(account)));
        }

        [HttpDelete]
        [Route("DeleteAccount")]
        public JsonResult DeleteAnAccount(int id)
        {
            _account.DeleteAccount(id);
            return new JsonResult("Eliminado Exitosamente");    
        }

    }
}
