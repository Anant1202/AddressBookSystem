using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public interface IAddressBook
    {
        void GetUserInfo();
        void ListingPeople();
        void DeleteInfo();
    }
    public class AddDetails : IAddressBook
    {
        public LinkedList<User> people;
        public AddDetails()
        {
            people = new LinkedList<User>();
        }
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Addresses { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string PhoneNum { get; set; }
            public string EmailId { get; set; }
        }
        //Getting details from the user 
        public void GetUserInfo()
        {
            User per = new User();
            Console.Write("Enter First Name: ");
            per.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            per.LastName = Console.ReadLine();

            Console.Write("Enter Address : ");
            per.Addresses = Console.ReadLine();

            Console.Write("Enter City : ");
            per.City = Console.ReadLine();

            Console.Write("Enter State : ");
            per.State = Console.ReadLine();

            Console.Write("Enter ZipCode: ");
            per.ZipCode = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            per.PhoneNum = Console.ReadLine();

            Console.Write("Enter EmailId: ");
            per.EmailId = Console.ReadLine();

            people.AddLast(per);
        }
        //Printing the details
        public void PrintDetails(User per)
        {
            Console.WriteLine("First Name: " + per.FirstName);
            Console.WriteLine("Last Name: " + per.LastName);
            Console.WriteLine("Phone Number: " + per.PhoneNumber);
            Console.WriteLine("Address : " + per.Addresses);
            Console.WriteLine("City : " + per.City);
            Console.WriteLine("State : " + per.State);
            Console.WriteLine("ZipCode : " + per.ZipCode);
            Console.WriteLine("Phone Number: " + per.PhoneNum);
            Console.WriteLine("Email Id: " + per.EmailId);
            Console.WriteLine("-------------------------------------------");
        }
        //Modify the details
        public void EditInfo()
        {
            if (people.Count != 0)
            {
                Console.WriteLine("Enter the first name of the user contact to modify:");
                string Modified = Console.ReadLine();
                foreach (var person in people)
                {
                    if (person.FirstName.ToUpper() == Modified.ToUpper())
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter the option to modify the property: ");
                            Console.WriteLine("Enter 1 to Change First name ");
                            Console.WriteLine("Enter 2 to Change Last name ");
                            Console.WriteLine("Enter 3 to Change Phone Number ");
                            Console.WriteLine("Enter 4 to Change Address ");
                            Console.WriteLine("Enter 5 to Change City ");
                            Console.WriteLine("Enter 6 to Change State ");
                            Console.WriteLine("Enter 7 to Change Pincode ");
                            Console.WriteLine("Enter 8 to Exit ");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Enter the New First Name: ");
                                    person.FirstName = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the New Last Name: ");
                                    person.LastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Enter the New Phone Number: ");
                                    person.PhoneNum = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Enter the New Address: ");
                                    person.Addresses = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Enter the New City: ");
                                    person.City = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Enter the New State: ");
                                    person.State = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("Enter the New Pin Code: ");
                                    person.ZipCode = Console.ReadLine();
                                    break;
                                case 8:
                                    return;

                            }

                        }

                    }
                    else
                    {
                        Console.WriteLine("Enter the valid name!");
                    }

                }


            }
        }
        //Listing the user entered details or modified details
        public void ListingPeople()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("Your address book is empty.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Here are the current people in your address book:\n");
            foreach (var person in people)
            {
                PrintDetails(person);
            }
            return;
            Console.WriteLine("\nPress any key to continue.");

            Console.ReadKey();

        }
        //Removing the field using Lambda Function
        public void DeleteInfo()
        {
            Console.WriteLine("Enter the first name of the user you would like to remove.");
            string firstName = Console.ReadLine();
            User person = people.FirstOrDefault(x => x.FirstName.ToUpper() == firstName.ToUpper());
            if (person == null)
            {
                Console.WriteLine("That person could not be found..");

                return;
            }
            Console.WriteLine("Are you sure you want to remove this user from your address book? (Y/N)");
            //  PrintDetails(per);

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                people.Remove(person);
                Console.WriteLine("\nPerson removed ");

            }
        }
    }
}
