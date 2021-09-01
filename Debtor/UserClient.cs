using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Debtor.Core;

namespace Debtor
{
    class UserClient
    {
        public bool QuitProgram { get; set; } = false;
        DebtorsData debtorsData = new DebtorsData();
        public string FilePath = "MojaLista.txt";
        public void Introduce()
        {
            Console.WriteLine("Program służy do zapisywania długów.");
            ReadFromFile();
        }

        public void ShowOptions()
        {
            Console.WriteLine("Wybierz opcję: \n" +
                "1. Dodaj dłużnika. \n" +
                "2. Usuń dłużnika z listy. \n" +
                "3. Wyświetl listę dłużników.\n" +
                "4. Wyświetl całkowity dług.\n" +
                "5. Usuń część długu.\n" +
                "6. Wyjdź z programu."
                );
        }

        public void SelectOption()
        {
            var succededChoice = int.TryParse(Console.ReadLine(), out int selectedOption);
            if (!succededChoice)
            {
                Console.WriteLine("Wprowadź poprawny numer");
                SelectOption();
            }
            else 
            {
                if (selectedOption == 1)
                {
                    debtorsData.AddDebtor();
                    return;
                }
                else if (selectedOption == 2)
                {
                    debtorsData.RemoveDebtor();
                    return;
                }
                else if (selectedOption == 3)
                {
                    debtorsData.ShowDebtorsList();
                    return;
                }
                else if (selectedOption == 4)
                {
                    ShowAllDebt();
                    return;
                }
                else if (selectedOption == 5)
                {
                    RemoveDebtPartially();
                    return;
                }
                else if (selectedOption == 6)
                {
                    QuitProgram = true;
                }
                else
                {
                    Console.WriteLine("Wprowadź poprawny numer");
                    SelectOption();
                }
            }
        }

        public void ShowDebtorsList()
        {
            debtorsData.ShowDebtorsList();

            
        }

        public void SaveToFile()
        {

            TextWriter writer = new StreamWriter(FilePath);

            foreach (var borrower in debtorsData.DebtorsList)
            {
                writer.WriteLine(borrower.ToString());
            }

            writer.Close();

            
            
        }

        public void ReadFromFile()
        {
            var lines = File.ReadLines(FilePath);
            foreach (var line in lines)
            {
                string[] values = line.Split(';');
                var name = values[0];
                var amount = decimal.Parse(values[1]);
                var date = values[2];

                Borrower borr = new Borrower(name, amount, DateTime.Parse(date));
                debtorsData.DebtorsList.Add(borr);
            }
        }

        /// <summary>
        /// Shows sum of all debt
        /// </summary>
        public void ShowAllDebt() 
        {
            decimal sum = 0;
            foreach (var debtor in debtorsData.DebtorsList)
            {
                sum += debtor.Debt;
            }

            Console.WriteLine($"Suma długów wynosi {sum}");
        }
        /// <summary>
        /// Removes just a part of debt 
        /// </summary>
        public void RemoveDebtPartially()
        {
            Console.WriteLine("Kto spłacił część długu?");
            var debtorName = Console.ReadLine();

            Console.WriteLine("Ile zapłacił?");
            var succededDebt = decimal.TryParse(Console.ReadLine(), out decimal paidMoney);
            while (!succededDebt)
            {
                Console.WriteLine("Podano nieprawidłową liczbę, podaj jeszcze raz.");
                var a = Console.ReadLine();
                succededDebt = decimal.TryParse(a, out paidMoney);
            }
            debtorsData.RemovePartOfDebt(debtorName, paidMoney);
        }

        /// <summary>
        /// Adds 10% interest every month
        /// </summary>
        public void AddInterest()
        {
            foreach (var debtor in debtorsData.DebtorsList)
            {
                if ((DateTime.Now - debtor.Date).TotalDays > 30)
                {
                    debtor.Debt = debtor.Debt + decimal.Multiply(debtor.Debt, (decimal)0.1);
                }
            }
        }
       
    
    }
}
