namespace desafio
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<MoneyChangeTransaction> MoneyChangeTransactions { get; set; }
  }
}