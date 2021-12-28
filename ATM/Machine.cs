using System;
using System.IO;

namespace ATM
{
    public class Machine
    {
        private string status = @"C:\Moji Dokumenti\Za skolu\DataPrograming\Status.txt";


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
         
            }
            else
            {
                Console.WriteLine("Wrong login data! Please try again later. Thank you!");
            }
        }


        private void payIn()
        {
            decimal statusOld = statusRead();
            decimal userInputValue = userInput();
            while (true) 
            {
                if(userInputValue <= 0) 
                {
                    Console.WriteLine("Unable to complete action! Please enter valid amount! ");
                    userInputValue = userInput();
                }
                else
                {
                    decimal statusNew = statusOld + userInputValue;
                    statusUpdate(statusNew);
                    break;
                }
            }
            
        }

        private void payOut()
        {
            decimal statusOld = statusRead();
            decimal userInputValue = userInput();
            while (true) 
            {
                if (statusOld < userInputValue)
                {
                    Console.WriteLine("Unable to complete action! Please enter valid amount! ");
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
            decimal amount;
            bool correctAmount = decimal.TryParse(Console.ReadLine(), out amount);
            while (!correctAmount || amount <= 0) 
            {
                Console.WriteLine("Invalid Input. Please enter a valid amount! ");
                correctAmount = decimal.TryParse(Console.ReadLine(),out amount);
            }
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
