using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class InputDetails
    {
        public void Details()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Address : ");
            string Addresses = Console.ReadLine();

            Console.Write("Enter City : ");
            string city = Console.ReadLine();

            Console.Write("Enter State : ");
            string state = Console.ReadLine();

            Console.Write("Enter ZipCode: ");
            string zipCode = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter EmailId: ");
            string Email = Console.ReadLine();


            //List<string> Person = new List<string>();
            //Person.Add(firstName);
            //Person.Add(lastName);
            //Person.Add(city);
            //Person.Add(state);
            //Person.Add(zipCode);
            //Person.Add(phoneNumber);
            //Person.Add(Email);
            //foreach (string element in Person)
            //{
            //    Console.WriteLine(element);
            //}
        }
    }
}
