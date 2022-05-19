using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook.AddDetails.GetUserInfo();
            AddressBook.AddDetails.EditInfo();
            AddressBook.AddDetails.ListingPeople();
            AddressBook.AddDetails.DeleteInfo();
            AddressBook.AddDetails.ListingPeople();

            //InputDetails ob1 = new InputDetails();
            //ob1.Details();
        }
    }
}

