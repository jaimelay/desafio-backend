using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace desafio.Tests
{
  public class MoneyChangeTransactionControllerTest
  {

    private readonly Random rand = new();

    private readonly Mock<IMoneyChangeTransactionService> _mockService;

    public MoneyChangeTransactionControllerTest()
    {
      _mockService = new Mock<IMoneyChangeTransactionService>();
    }

    [Fact]
    public void GetReturnStatusCodeEqual200()
    {
      var moneyChangeTransactionRandom = CreateRandomMoneyChangeTransactionDTO();
      var sut = new MoneyChangeTransactionController(_mockService.Object);
      var result = Assert.IsType<OkObjectResult>(sut.Save(moneyChangeTransactionRandom).Result);
      Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void GetReturnStatusNotNull()
    {
      var moneyChangeTransactionRandom = CreateRandomMoneyChangeTransactionDTO();
      var sut = new MoneyChangeTransactionController(_mockService.Object);
      var result = Assert.IsType<OkObjectResult>(sut.Save(moneyChangeTransactionRandom).Result);
      Assert.NotNull(result);
    }

    [Fact]
    public void GetReturnValueTypeString()
    {
      var moneyChangeTransactionRandom = CreateRandomMoneyChangeTransactionDTO();

      _mockService.Setup(service => service.Save(moneyChangeTransactionRandom)).Returns("");

      var sut = new MoneyChangeTransactionController(_mockService.Object);
      var result = sut.Save(CreateRandomMoneyChangeTransactionDTO());

      Assert.IsType<String>(result.Value);
    }

    [Fact]
    public void GetSuccessOnCallMoneyChangeTransactionServiceOnce()
    {
      var moneyChangeTransactionRandom = CreateRandomMoneyChangeTransactionDTO();

      _mockService.Setup(service => service.Save(moneyChangeTransactionRandom)).Returns("");

      var sut = new MoneyChangeTransactionController(_mockService.Object);
      var result = sut.Save(CreateRandomMoneyChangeTransactionDTO());

      _mockService.Verify(service => service.Save(moneyChangeTransactionRandom), Times.Once());
    }

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