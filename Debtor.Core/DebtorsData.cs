using System;
using System.Collections.Generic;
using System.Text;

namespace Debtor.Core
{
    public class DebtorsData
    {
        public List<Borrower> DebtorsList { get; set; } = new List<Borrower>();

        public void AddDebtor()
        {
            Console.WriteLine("Podaj imię nowego dłużnika.");
            var name = Console.ReadLine();

            Console.WriteLine("Wpisz kwotę, którą pożyczył.");
            var a = Console.ReadLine();


            bool correctDecimal = decimal.TryParse(a, out decimal result);

            while(!correctDecimal)
            {
                Console.WriteLine("Podaną nieprawidłową kwotę, podaj jeszcze raz");
                a = Console.ReadLine();
                correctDecimal = decimal.TryParse(a, out result);
            }

            var borrower = new Borrower(name, result, DateTime.Now);
            DebtorsList.Add(borrower);

        }

        public void RemoveDebtor()
        {
            Console.WriteLine("Podaj imię osoby, która spłaciła dług :).");
            var givenName = Console.ReadLine();
            foreach (var debtor in DebtorsList)
            {
                if (debtor.Name == givenName)
                {
                    DebtorsList.Remove(debtor);
                    return;
                }
            }

            Console.WriteLine("Nie było dłużnika o takim imieniu.");
            //dokończyć tą metodę
        }

        public void ShowDebtorsList()
        {
            foreach (var borrower in DebtorsList)
            {
                Console.WriteLine(borrower.BorrowerToString());
            }

            Console.WriteLine("###############################################");
        }

        public void RemovePartOfDebt(string borrowerName, decimal paidMoney)
        {
            foreach (var borrower in DebtorsList)
            {
                if (borrower.Name == borrowerName)
                {
                    borrower.Debt -= paidMoney;
                    return;
                }
                                              
                
            }
            Console.WriteLine("Nie znaleziono dłużnika o takim imieniu.");
        }
    }
}
