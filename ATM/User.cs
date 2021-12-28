using System;
using System.IO;

namespace ATM
{
    public class User 
    {
        private string name;
        private string password;
        private string logData = @"logDataFilePath";



        public User()
        { 
            Console.WriteLine("Please input your name and password: ");

            Console.WriteLine("name : ");
            this.name = Console.ReadLine();

            Console.WriteLine("password : ");
            this.password = Console.ReadLine();
        }


        public bool checkData() 
        {
            string[] readData = File.ReadAllLines(logData);
            if (readData[0]== "name : " + name && readData[1] == "password : " + password)
            {
                return true;
            }
            else return false;
        }

    }
}
