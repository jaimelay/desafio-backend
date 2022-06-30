using Microsoft.AspNetCore.Mvc;

namespace desafio
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoneyChangeTransactionController : ControllerBase
  {
    private readonly ILogger<MoneyChangeTransactionController> _logger;

    public MoneyChangeTransactionController(ILogger<MoneyChangeTransactionController> logger)
    {
      _logger = logger;
    }

    [HttpPost]
    public ActionResult<String> save([FromBody] MoneyChangeTransactionDTO moneyChangeTransactionDTO)
    {
      return "Hello World";
    }
  }
}