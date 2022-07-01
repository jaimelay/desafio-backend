using System.Data;
using Npgsql;

namespace desafio
{
  public class DataContext : DbContext
  {
    private IDbConnection connection;

    public IDbConnection Connection
    {
      get
      {
        if (connection == null)
        {
          connection = new NpgsqlConnection(Database.GetDbConnection().ConnectionString);
        }

        if (connection.State == ConnectionState.Closed)
        {
          connection.Open();
        }

        return connection;
      }
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<MoneyChangeTransaction> MoneyChangeTransactions { get; set; }
  }
}