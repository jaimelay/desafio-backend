using Microsoft.AspNetCore.Mvc;

namespace desafio
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoneyChangeTransactionController : ControllerBase
  {
    private readonly IMoneyChangeTransactionService _moneyChangeTransactionService;

    public MoneyChangeTransactionController(IMoneyChangeTransactionService moneyChangeTransactionService)
    {
      _moneyChangeTransactionService = moneyChangeTransactionService;
    }

    [HttpPost]
    public ActionResult<String> Save([FromBody] MoneyChangeTransactionDTO moneyChangeTransactionDTO)
    {
      return Ok(_moneyChangeTransactionService.Save(moneyChangeTransactionDTO));
    }
  }
}