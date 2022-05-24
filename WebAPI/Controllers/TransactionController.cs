using Business.Abstract;
using Entities;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Transaction transaction=new Transaction();
            var result=_transactionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllByOwnerId")]
        public IActionResult GetAllByOwnerId(int id)
        {
            var result = _transactionService.GetAllByOwnerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("accountWithDraw")]
        public IActionResult AccountWithDraw(AccountWithDrawDto accountWithDrawDto)
        {
            var result=_transactionService.WithDraw(accountWithDrawDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
