using System;

namespace hangman.view
{
    public class loginview
    {
        public (string username, string password) getlogincredentials()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            return (username, password);
        }

        public (string username, string password) getnewregistration()
        {
            Console.WriteLine("Register a new account:");
            Console.Write("Enter new username: ");
            string newusername = Console.ReadLine();
            Console.Write("Enter new password: ");
            string newpassword = Console.ReadLine();
            return (newusername, newpassword);
        }

        public bool askforregistration()
        {
            Console.WriteLine("User not found. Do you want to register? (y/n)");
            string choice = Console.ReadLine().ToLower();
            return choice == "y";
        }

        public void showmessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
