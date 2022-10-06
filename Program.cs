using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_5oct
{
    public delegate void mydelegate();
    public class Bank
    {
        public double accountbalance;
        public double totalbalance;
        public event mydelegate lowbalance;
        public event mydelegate unsufficientbalance;
        public Bank(double accountbalance)
        {
            this.accountbalance = accountbalance;
            Console.WriteLine($"current account balance is Rs.{accountbalance}");
        }
        public void Credit(double creditAmount)
        {
            totalbalance = accountbalance + creditAmount;
            Console.WriteLine($"Your total Balance is Rs.{totalbalance}");
        }
        public void Debit(double wa)
        {
            if(wa > totalbalance)
            {
                lowbalance();
            }
            else if (totalbalance-wa<5000)
            {
                unsufficientbalance();
            }
            else
            {
                double amountleft = totalbalance - wa;
                Console.WriteLine($"Remaining Amount is Rs.{amountleft}");
            }
        }
    }
    public class DelegateExample
    {
        static void Lowbalance()
        {
            Console.WriteLine("Your Account Balance is Low");
        }
        static void unsufficientbal()
        {
            Console.WriteLine("min ammount limit reached");
        }
        static void Main()
        {
            Bank bank = new Bank(1000);
            bank.lowbalance += new mydelegate(Lowbalance);
            bank.unsufficientbalance+=new mydelegate(unsufficientbal);
            Console.WriteLine("Enter the amount to debit");
            double credit=Convert.ToDouble(Console.ReadLine());
            bank.Credit(credit);
            Console.WriteLine("Enter the amount to debit");
            double debit=Convert.ToDouble(Console.ReadLine());  
            bank.Debit(debit);  
        }
    }
    
}
