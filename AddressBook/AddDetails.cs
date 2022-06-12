using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public interface IAddressBook
    {
        //void GetUserInfo();
        void ListingPeople();
        void DeleteInfo();
    }
    public class AddDetails : IAddressBook
    {
        public static Dictionary<string, List<AddDetails>> City = new Dictionary<string, List<AddDetails>>();
        public static Dictionary<string, List<AddDetails>> State = new Dictionary<string, List<AddDetails>>();
        public List<AddDetails> stateList;
        public List<AddDetails> cityList;
        public List<AddDetails> people;
        public AddDetails()
        {
            people = new List<AddDetails>();
        }
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public string zipCode;
        public string phoneNum;
        public string emailId;
        public AddDetails(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zip;
            this.phoneNum = phoneNumber;
            this.emailId = email;

        }
        //Getting the user details
        public void GetUserInfo(string firstName, string lastName, string phoneNum, string address, string city, string state, string zipCode, string emailId)
        {

            AddDetails person = new AddDetails(firstName, lastName, phoneNum, address, city, state, zipCode, emailId);
            if (people.Count == 0)
            {
                people.Add(person);
            }
            else
            {
                AddDetails people = this.people.Find(a => a.firstName.Equals(firstName));
                if (people == null)
                {
                    AddDetails p = new AddDetails(firstName, lastName, address, city, state, phoneNum, zipCode, emailId);
                    this.people.Add(p);
                }
                else
                {
                    Console.WriteLine("-------Record is already exists-------");
                    Console.WriteLine("Modify the details which has duplicate name");
                    EditInfo();
                }
            }
        }


        //Print the details
        public void PrintCustomer(AddDetails person)
        {
            Console.WriteLine("First Name: " + person.firstName);
            Console.WriteLine("Last Name: " + person.lastName);
            Console.WriteLine("Phone Number: " + person.phoneNum);
            Console.WriteLine("Address : " + person.address);
            Console.WriteLine("City : " + person.city);
            Console.WriteLine("State : " + person.state);
            Console.WriteLine("ZipCode : " + person.zipCode);
            Console.WriteLine("Email Id: " + person.emailId);
            Console.WriteLine("-------------------------------------------");
        }
        //Modify the details
        public void EditInfo()
        {
            if (people.Count != 0)
            {
                Console.WriteLine("Enter the contact to modify:");
                string Modified = Console.ReadLine();
                foreach (var person in people)
                {
                    if (person.firstName.ToUpper() == Modified.ToUpper())
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
                            int Check = Convert.ToInt32(Console.ReadLine());
                            switch (Check)
                            {
                                case 1:
                                    Console.WriteLine("Enter the New First Name: ");
                                    person.firstName = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the New Last Name: ");
                                    person.lastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Enter the New Phone Number: ");
                                    person.phoneNum = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Enter the New Address: ");
                                    person.address = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Enter the New City: ");
                                    person.city = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Enter the New State: ");
                                    person.state = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("Enter the New Pin Code: ");
                                    person.zipCode = Console.ReadLine();
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
                PrintCustomer(person);
            }
            return;
            //Console.WriteLine("\nPress any key to continue.");

            //Console.ReadKey();

        }
        //Removing the field using Lambda Function
        public void DeleteInfo()
        {
            Console.WriteLine("Enter the first name of the person you would like to remove.");
            string firstName = Console.ReadLine();
            AddDetails person = people.FirstOrDefault(x => x.firstName.ToUpper() == firstName.ToUpper());
            if (person == null)
            {
                Console.WriteLine("That person could not be found..");

                return;
            }
            Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
            //  PrintCustomer(person);

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                people.Remove(person);
                Console.WriteLine("\nPerson removed ");

            }
        }
        //Display Person names found in given City
        public static void StoreCityList(string key, List<AddDetails> cityList, string city)
        {
            List<AddDetails> CityList = cityList.FindAll(a => a.city.ToLower() == city);
            foreach (var i in CityList)
            {
                Console.WriteLine("Found person \"{0}\" in Address Book \"{1}\" , residing in City {2}", i.firstName, key, i.city);
            }
        }
        //Display Person names found in given State
        public static void StoreStateList(string key, List<AddDetails> stateList, string state)
        {
            List<AddDetails> StateList = stateList.FindAll(x => x.state.ToLower() == state);
            foreach (var i in StateList)
            {
                Console.WriteLine("Found person \"{0}\" in Address Book \"{1}\" , residing in State {2}", i.firstName, key, i.state);
            }
        }
    }
}
