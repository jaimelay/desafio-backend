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
      if (moneyChangeTransactionDTO.MoneyChange < 0.0m)
      {
        return "Valor pago menor que o preço";
        // throw new Exception();
      }

      if (moneyChangeTransactionDTO.Price < 0.0m)
      {
        return "O preço deve ser maior ou igual a 0";
        // throw new Exception();
      }

      if (moneyChangeTransactionDTO.Paid <= 0.0m)
      {
        return "O valor pago deve ser maior que 0";
        // throw new Exception();
      }

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

      return MoneyUtil.GetMoneyChangeTotalAndInBillsAndCentsToString(moneyChangeTransactionDTO.MoneyChange, allowedBillsAndCents);
    }
  }
}