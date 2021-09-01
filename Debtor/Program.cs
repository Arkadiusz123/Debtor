using System;
using Debtor.Core;

namespace Debtor
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new UserClient();
            var debtorsData = new DebtorsData();

            Console.WriteLine(DateTime.Now);

            client.Introduce();
            client.AddInterest();

            while (client.QuitProgram == false)
            {
                client.ShowOptions();
                client.SelectOption();
            }

            client.SaveToFile();
            //pod spodem testy
            /*debtorsData.AddDebtor();
            debtorsData.AddDebtor();
            
            debtorsData.ShowDebtorsList();
            debtorsData.RemoveDebtor();
            debtorsData.ShowDebtorsList();*/
         
        }
    }
}
