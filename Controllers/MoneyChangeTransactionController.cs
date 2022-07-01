using Microsoft.AspNetCore.Mvc;

namespace desafio
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoneyChangeTransactionController : ControllerBase
  {
    private readonly ILogger<MoneyChangeTransactionController> _logger;

    private readonly IMoneyChangeTransactionService _moneyChangeTransactionService;

    public MoneyChangeTransactionController(ILogger<MoneyChangeTransactionController> logger, IMoneyChangeTransactionService moneyChangeTransactionService)
    {
      _logger = logger;
      _moneyChangeTransactionService = moneyChangeTransactionService;
    }

    [HttpPost]
    public ActionResult<String> save([FromBody] MoneyChangeTransactionDTO moneyChangeTransactionDTO)
    {
      return Ok(_moneyChangeTransactionService.Save(moneyChangeTransactionDTO));
    }
  }
}