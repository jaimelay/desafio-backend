using System.Globalization;

namespace desafio
{
  public class MoneyUtil
  {
    private static List<Tuple<int, decimal>> GetMoneyChangeInBillsAndCentsList(decimal moneyChange, List<decimal> allowedBillsAndCents)
    {
      List<Tuple<int, decimal>> moneyChangeBillsAndCents = new List<Tuple<int, decimal>>();

      for (int i = 0; i < allowedBillsAndCents.Count; i++)
      {
        int quantityCurrentBillOrCent = 0;

        while (moneyChange >= allowedBillsAndCents[i])
        {
          moneyChange -= allowedBillsAndCents[i];
          quantityCurrentBillOrCent++;
        }

        if (quantityCurrentBillOrCent > 0)
        {
          moneyChangeBillsAndCents.Add(Tuple.Create(quantityCurrentBillOrCent, allowedBillsAndCents[i]));
        }
      }

      return moneyChangeBillsAndCents;
    }

    public static String GetMoneyChangeTotalAndInBillsAndCentsToString(decimal moneyChange, List<decimal> allowedBillsAndCents)
    {
      List<Tuple<int, decimal>> moneyChangeBillsAndCents = GetMoneyChangeInBillsAndCentsList(moneyChange, allowedBillsAndCents);
      String moneyChangeInBillsAndCentsToString = "";

      for (int i = 0; i < moneyChangeBillsAndCents.Count; i++)
      {
        int quantityBillsOrCents = moneyChangeBillsAndCents[i].Item1;
        decimal billsOrCents = moneyChangeBillsAndCents[i].Item2;
        moneyChangeInBillsAndCentsToString += quantityBillsOrCents == 1 ? (quantityBillsOrCents.ToString() + " nota de ") : (quantityBillsOrCents.ToString() + " notas de ");
        moneyChangeInBillsAndCentsToString += billsOrCents.ToString("C", new CultureInfo("pt-BR", false).NumberFormat) + "\n";
      }

      return "Valor do Troco: " + moneyChange.ToString("C", new CultureInfo("pt-BR", false).NumberFormat) + "\nValor do troco em cédulas e moedas:\n" + moneyChangeInBillsAndCentsToString;
    }
  }
}