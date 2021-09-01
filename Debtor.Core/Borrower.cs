using System;
using System.Collections.Generic;
using System.Text;

namespace Debtor.Core
{
   public class Borrower
    {
        public string Name { get; set; }
        public decimal Debt { get; set; }
        public DateTime Date { get; set; }

        public Borrower(string name, decimal debt, DateTime date)
        {
            Name = name;
            Debt = debt;
            Date = date;
        }

        public override string ToString()
        {
            return Name+';'+Debt+';'+Date;
        }

        public string BorrowerToString()
        {
            return $"{Name} jest winny {Debt}. Został zapisany w dniu {Date.Day}-{Date.Month}-{Date.Year}";
        }
    }
}
