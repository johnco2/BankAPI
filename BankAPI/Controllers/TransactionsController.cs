using BankAPI.Repository;
using BankAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transaction;

        public TransactionsController(ITransactionRepository Transaction)
        {
            _transaction = Transaction ?? throw new ArgumentNullException(nameof(Transaction));
        }

        [HttpGet]
        [Route("GetTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            return Ok(await _transaction.GetTransactions());
        }

        [HttpGet]
        [Route("GetTransactionsById/{id}")]
        public async Task<IActionResult> GetTransactionsById(int id)
        {
            return Ok(await _transaction.GetTransactionById(id));
        }

        [HttpPost]
        [Route("AddTransaction/{id}")]
        public async Task<IActionResult> InsertATransaction(VMTransaction vMTransaction, int id)
        {
            return Ok(await _transaction.InsertTransaction(id, VMTransaction.ToEntity(vMTransaction)));
        }

        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> UpdateATransaction(VMTransaction vMTransaction)
        {
            return Ok(await _transaction.UpdateTransaction(VMTransaction.ToEntity(vMTransaction)));
        }

        [HttpDelete]
        [Route("DeleteTransaction")]
        public JsonResult DeleteTransaction(int id)
        {
            _transaction.DeleteTransaction(id);
            return new JsonResult("Eliminado Exitosamente");
        }
    }
}
