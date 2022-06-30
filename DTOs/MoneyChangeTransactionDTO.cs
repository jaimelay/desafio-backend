namespace desafio
{
  public class MoneyChangeTransactionDTO
  {
    public long Id { get; set; }

    public decimal Price { get; set; }

    public decimal Paid { get; set; }

    public decimal MoneyChange { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}