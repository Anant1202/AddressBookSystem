using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("Welcome to Address Book Program");
            do
            {
                Console.WriteLine("1.Add the details");
                Console.WriteLine("2.Edit the details");
                Console.WriteLine("3.Delete the details");
                Console.WriteLine("4.Listing the Details");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddressBook.AddDetails.GetUserInfo();
                        break;
                    case 2:
                        AddressBook.AddDetails.EditInfo();
                        break;
                    case 3:
                        AddressBook.AddDetails.DeleteInfo();
                        break;
                    case 4:
                        AddressBook.AddDetails.ListingPeople();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }

            } while (choice != 5);
        }
    }
}

