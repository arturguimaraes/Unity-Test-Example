using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS {

    public class BankAccount {

        private string name;
        private double balance;

        // class under test 
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";


        private BankAccount() {

        }

        public BankAccount(string name, double balance) {
            this.name = name;
            this.balance = balance;
        }

        public string CustomerName {
            get { return this.name; }
        }

        public double Balance {
            get { return this.balance; }
        }

        public void Debit(double amount) {
            if(amount > this.balance)
                throw new ArgumentOutOfRangeException("Amount",amount,DebitAmountExceedsBalanceMessage);
            if(amount < 0)
                throw new ArgumentOutOfRangeException("Amount",amount,DebitAmountLessThanZeroMessage);
            this.balance -= amount;
        }

        public void Credit(double amount) {
            if(amount < 0)
                throw new ArgumentOutOfRangeException("Amount",amount,DebitAmountLessThanZeroMessage);
            this.balance += amount;
        }

        public static void Main() {
            BankAccount ba = new BankAccount("José da Silva",29.45);

            ba.Credit(0.55);
            ba.Debit(10);
            Console.WriteLine("Your current balance is ${0}.",ba.balance);
        }

    }

}
