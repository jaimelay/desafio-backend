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
    public void ReturnErrorWhenMoneyChangeIsNegative()
    {
      var result = _service.Save(new()
      {
        Price = 100,
        Paid = 50
      });

      Assert.Equal("Valor pago menor que o preço", result);
    }

    [Fact]
    public void ReturnErrorWhenPriceIsNegative()
    {
      var result = _service.Save(new()
      {
        Price = -100,
        Paid = 200
      });

      Assert.Equal("O preço deve ser maior ou igual a 0", result);
    }

    [Fact]
    public void ReturnErrorWhenPaidIsNegative()
    {
      var result = _service.Save(new()
      {
        Price = 100,
        Paid = -50
      });

      Assert.Equal("Valor pago menor que o preço", result);
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