using System;

namespace ATM
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var machine = new Machine();
            var user = new User();
            machine.transactionExecution(user, machine);

        }
    }
}
