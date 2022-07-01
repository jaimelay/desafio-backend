namespace desafio
{
  public class MoneyChangeTransactionDTO
  {
    public decimal Price { get; set; }

    public decimal Paid { get; set; }

    public decimal MoneyChange
    {
      get
      {
        return Paid - Price;
      }
    }

    public DateTime CreatedAt { get; } = DateTime.Now;
  }
}