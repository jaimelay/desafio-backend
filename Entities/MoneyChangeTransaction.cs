namespace desafio
{
  public class MoneyChangeTransaction
  {
    public long Id { get; set; }

    public decimal Price { get; set; }

    public decimal Paid { get; set; }

    public decimal MoneyChange { get; set; }

    public DateTime CreatedAt { get; set; }
  }
}