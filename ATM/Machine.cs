using System;
using System.IO;

namespace ATM
{
    public class Machine
    {
        private string status = @"statusFilePath";


        public void transactionExecution(User user, Machine machine) 
        {
            if (user.checkData())
            {
                Console.WriteLine("Wellcome! Your current balance is {0} \n Please select next action:\n Press 1 to pay in, Press2 to pay out:", statusRead());

                int commandRead = userOptionInput();


                    if (commandRead == 1)
                    {
                        Console.WriteLine("Set amount to pay in: ");
                        machine.payIn();
                        Console.WriteLine("Success! Your balance has been increased! New balance: {0}", statusRead());

                    }
                    else if (commandRead == 2)
                    {
                        Console.WriteLine("Set amount to pay out: ");
                        machine.payOut();
                        Console.WriteLine("Your new balance : {0}",statusRead());

                    }
                    else Console.WriteLine("Unknown command! Choose 1 for pay in, choose 2 for pay out option. ");
                
            }
            else
            {
                Console.WriteLine("Wrong login data! Please try again later. Thank you!");
            }
        }


        private void payIn()
        {
            decimal statusOld = statusRead();
            decimal statusNew = statusOld + userInput();
            statusUpdate(statusNew);
        }

        private void payOut()
        {
            decimal statusOld = statusRead();
            decimal userInputValue = userInput();
            while (true) 
            {
                if (statusOld < userInputValue)
                {
                    Console.WriteLine("Unable to complete action! Insuficient funds!");
                    userInputValue = userInput();
                }
                else
                {
                    decimal statusNew = statusOld - userInputValue;
                    statusUpdate(statusNew);
                    Console.WriteLine("Successfull payout! Thanks for using our service!");
                    break;
                }
            }
            
            
        }

        private decimal statusRead() 
        {
            decimal statusOld = decimal.Parse(File.ReadAllText(status));
            return statusOld;
        }
        private decimal userInput() 
        {
            decimal amount = decimal.Parse(Console.ReadLine());
            return amount;
        }
        private void statusUpdate(decimal statusNew) 
        {
            File.WriteAllText(status, statusNew.ToString());
        }

        private int userOptionInput()
        {
            string input = Console.ReadLine();
            int inputValue;
            bool correctValue = int.TryParse(input, out inputValue);
            bool validValue = correctValue && inputValue <= 2 && inputValue >=1;
            while (!validValue)
            {
                Console.WriteLine("Invalid Input. Please enter a valid option! ");
                input = Console.ReadLine();
                correctValue = int.TryParse(input, out inputValue);
                validValue = correctValue && inputValue <= 2 && inputValue >= 1;
            }
            return inputValue;
        }
    }
}
