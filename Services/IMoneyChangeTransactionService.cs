namespace desafio
{
  public interface IMoneyChangeTransactionService
  {
    String Save(MoneyChangeTransactionDTO moneyChangeTransactionDTO);

    String GetMoneyChange(MoneyChangeTransactionDTO moneyChangeTransactionDTO);
  }
}