using Xunit;
using Moq;

namespace desafio.Tests
{
  public class MoneyChangeTransactionServiceTest
  {
    private Mock<IMoneyChangeTransactionRepository> _repository;

    private IMoneyChangeTransactionService _service;

    private readonly Random rand = new();

    public MoneyChangeTransactionServiceTest()
    {
      _repository = new Mock<IMoneyChangeTransactionRepository>();
      _service = new MoneyChangeTransactionService(_repository.Object);
    }

    [Fact]
    public void GetChangeMoneyTypeString()
    {
      var randomMoneyChangeTransaction = CreateRandomMoneyChangeTransactionDTO();
      var result = _service.GetMoneyChange(randomMoneyChangeTransaction);
      Assert.IsType<String>(result);
    }

    [Fact]
    public void GetChangeMoneyNotReturnsEmptyString()
    {
      var randomMoneyChangeTransaction = CreateRandomMoneyChangeTransactionDTO();
      var result = _service.GetMoneyChange(randomMoneyChangeTransaction);
      Assert.NotEqual(String.Empty, result);
    }

    [Fact]
    public void GetChangeMoneyReturnsCorrectBillsAndCoins() { }

    private MoneyChangeTransactionDTO CreateRandomMoneyChangeTransactionDTO()
    {
      var randomPrice = rand.Next(1000);
      var randomPaid = rand.Next(randomPrice, 2000);
      return new()
      {
        Price = randomPrice,
        Paid = randomPaid
      };
    }
  }
}