using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddDetails
    {
        public static List<User> Person = new List<User>();
        public class User 
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PhoneNumber { get; set; }
            public string ZipCode { get; set; }
            public string Email { get; set; }

        }
        public static void GetUserInfo()
        {
            User per = new User();

            Console.Write("Enter First Name: ");
            per.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            per.LastName = Console.ReadLine();

            Console.Write("Enter Address : ");
            per.Address = Console.ReadLine();

            Console.Write("Enter City : ");
            per.City = Console.ReadLine();

            Console.Write("Enter State : ");
            per.State = Console.ReadLine();

            Console.Write("Enter Phone Number : ");
            per.PhoneNumber = Console.ReadLine();

            Console.Write("Enter ZipCode: ");
            per.ZipCode = Console.ReadLine();

            Console.Write("Enter Email Id: ");
            per.Email = Console.ReadLine();
            Person.Add(per);
        }
        public static void PrintDetails(User per)
        {
            Console.WriteLine("First Name: " + per.FirstName);
            Console.WriteLine("Last Name: " + per.LastName);
            Console.WriteLine("Phone Number: " + per.PhoneNumber);
            Console.WriteLine("Address : " + per.Address);
            Console.WriteLine("City : " + per.City);
            Console.WriteLine("State : " + per.State);
            Console.WriteLine("ZipCode : " + per.ZipCode);
            Console.WriteLine("Phone Number: " + per.PhoneNumber);
            Console.WriteLine("EmailId: " + per.Email);
            Console.WriteLine("-------------------------------------------");
        }
        public static void ListingPeople()
        {
            if (Person.Count == 0)
            {
                Console.WriteLine("Your address book is empty.");
                return;
            }
            Console.WriteLine("Current people in your address book:");
            foreach (var element in Person)
            {
                PrintDetails(element);
            }
        }
    }
}
