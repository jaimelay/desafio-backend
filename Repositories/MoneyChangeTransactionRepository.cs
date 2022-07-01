using Dapper;

namespace desafio
{
  public class MoneyChangeTransactionRepository : IMoneyChangeTransactionRepository
  {
    private readonly DataContext _dataContext;

    public MoneyChangeTransactionRepository(DataContext dataContext)
    {
      _dataContext = dataContext;
    }

    public void Save(MoneyChangeTransaction moneyChangeTransaction)
    {
      _dataContext.Connection.Execute("insert into \"MoneyChangeTransactions\" (\"Price\", \"Paid\", \"MoneyChange\", \"CreatedAt\") values (@Price, @Paid, @MoneyChange, @CreatedAt)", moneyChangeTransaction);
    }
  }
}