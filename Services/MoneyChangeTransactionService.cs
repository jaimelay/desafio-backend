namespace desafio
{
  public class MoneyChangeTransactionService : IMoneyChangeTransactionService
  {
    private readonly IMoneyChangeTransactionRepository _moneyChangeTransactionRepository;

    public MoneyChangeTransactionService(IMoneyChangeTransactionRepository moneyChangeTransactionRepository)
    {
      _moneyChangeTransactionRepository = moneyChangeTransactionRepository;
    }

    public String Save(MoneyChangeTransactionDTO moneyChangeTransactionDTO)
    {
      MoneyChangeTransaction moneyChangeTransaction = new()
      {
        Price = moneyChangeTransactionDTO.Price,
        Paid = moneyChangeTransactionDTO.Paid,
        MoneyChange = moneyChangeTransactionDTO.MoneyChange,
        CreatedAt = moneyChangeTransactionDTO.CreatedAt,
      };
      _moneyChangeTransactionRepository.Save(moneyChangeTransaction);
      return GetMoneyChange(moneyChangeTransactionDTO);
    }

    public String GetMoneyChange(MoneyChangeTransactionDTO moneyChangeTransactionDTO)
    {
      List<decimal> allowedBillsAndCents = new List<decimal>(){
        100.00m,
        50.00m,
        20.00m,
        10.00m,
        0.50m,
        0.10m,
        0.05m,
        0.01m,
      };

      if (moneyChangeTransactionDTO.MoneyChange < 0.0m)
      {
        throw new Exception("");
      }

      return MoneyUtil.GetMoneyChangeTotalAndInBillsAndCentsToString(moneyChangeTransactionDTO.MoneyChange, allowedBillsAndCents);
    }
  }
}