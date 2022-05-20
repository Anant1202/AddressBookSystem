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

            //Add is used to add the information
            Person.Add(per);
        }
    

            public static void PrintDetails(User per)
        {
            Console.WriteLine("First Name: " + per.FirstName);
            Console.WriteLine("Last Name: " + per.LastName);
            Console.WriteLine("Address : " + per.Address);
            Console.WriteLine("City : " + per.City);
            Console.WriteLine("State : " + per.State);
            Console.WriteLine("ZipCode : " + per.ZipCode);
            Console.WriteLine("Phone Number: " + per.PhoneNumber);
            Console.WriteLine("EmailId: " + per.Email);
            Console.WriteLine("-------------------------------------------");
        }
        public static void EditInfo()
        {
            Console.WriteLine("Enter the first name of the person you would like to modify:");
            string edit = Console.ReadLine();
            foreach (var per in Person)
            {
                if (per.FirstName == edit)
                {
                    while (true)
                    {
                        Console.WriteLine("Enter the option to modify the property: ");
                        Console.WriteLine("Enter 1 to Change First name ");
                        Console.WriteLine("Enter 2 to Change Last name ");
                        Console.WriteLine("Enter 3 to Change Address ");
                        Console.WriteLine("Enter 4 to Change City ");
                        Console.WriteLine("Enter 5 to Change State ");
                        Console.WriteLine("Enter 6 to Change Zipcode ");
                        Console.WriteLine("Enter 7 to Change Phone Number ");
                        Console.WriteLine("Enter 8 to Change Email ID ");
                        Console.WriteLine("Enter 9 to Exit ");
                        int Check = Convert.ToInt32(Console.ReadLine());
                        switch (Check)
                        {
                            case 1:
                                Console.WriteLine("Enter the New First Name: ");
                                per.FirstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter the New Last Name: ");
                                per.LastName = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Enter the New Address: ");
                                per.Address = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Enter the New City: ");
                                per.City = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Enter the New State: ");
                                per.State = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Enter the New Zip Code: ");
                                per.ZipCode = Console.ReadLine();
                                break;
                            case 7:
                                Console.WriteLine("Enter the New Phone Number: ");
                                per.PhoneNumber = Console.ReadLine();
                                break;
                            case 8:
                                Console.WriteLine("Enter the New Email ID: ");
                                per.Email = Console.ReadLine();
                                break;
                            case 9:
                                return;
                        }

                    }
                }
            }
        }
        public static void DeleteInfo()
        {
            Console.WriteLine("Enter the first name of the person you would like to remove.");
            string Delete = Console.ReadLine();
            foreach (var per in Person)
            {
                if (per.FirstName== Delete)
                {
                    //Remove is used to Remove or delete the information
                    Person.Remove(per);
                    Console.WriteLine("Contact is deleted");
                    return;
                }
                else
                {
                    Console.WriteLine("Contact is not present");
                    return;
                }
            }
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
