using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public interface IAddressBook
    {
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
        //ToString Method-Used for printing the details
        public override string ToString()
        {
            return "FirstName: " + this.firstName + " Last Name: " + this.lastName + " Address: " + this.address + "  City: " + this.city + " State: " + this.state + " Pincode: " + this.zipCode + " Phone Number: " + this.phoneNum + " Email Id: " + this.emailId;
        }
        //Getting the user details
        public void GetUserInfo(string firstName, string lastName, string phoneNum, string address, string city, string state, string zipCode, string emailId)
        {
            int contact = 0;
            AddDetails person = new AddDetails(firstName, lastName, phoneNum, address, city, state, zipCode, emailId);
            if (contact == 0)
            {

                people.Add(person);
                if (State.ContainsKey(state))
                {
                    List<AddDetails> existing = State[state];
                    existing.Add(person);

                }
                else
                {
                    stateList = new List<AddDetails>();
                    stateList.Add(person);
                    State.Add(state, stateList);

                }
                if (City.ContainsKey(city))
                {
                    List<AddDetails> existing = City[city];
                    existing.Add(person);

                }
                else
                {
                    cityList = new List<AddDetails>();
                    cityList.Add(person);
                    City.Add(city, cityList);

                }
                contact++;
            }
            else if (contact != 0)
            {
                //Checking duplicates
                AddDetails addressBookSystems = people.Find(x => x.firstName.Equals(firstName));
                if (addressBookSystems == null)
                {
                    person = new AddDetails(firstName, lastName, address, city, state, zipCode, phoneNum, emailId);
                    people.Add(person);
                    if (State.ContainsKey(state))
                    {
                        List<AddDetails> existing = State[state];
                        existing.Add(person);

                    }
                    else
                    {
                        stateList = new List<AddDetails>();
                        stateList.Add(person);
                        State.Add(state, stateList);

                    }
                    if (City.ContainsKey(city))
                    {
                        List<AddDetails> existing = City[city];
                        existing.Add(person);

                    }
                    else
                    {
                        cityList = new List<AddDetails>();
                        cityList.Add(person);
                        City.Add(city, cityList);

                    }
                    contact++;
                }
                else
                {
                    Console.WriteLine("This person already exists in your AddressBook!");
                }

            }
        }
        //Print the details
        public void PrintDetails(AddDetails person)
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
                PrintDetails(person);
            }
            return;

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
        public static void DisplayCityorState()
        {
            Console.WriteLine("Enter 1-To view City list\n Enter 2-To view State list");
            int citystate = Convert.ToInt32(Console.ReadLine());
            if (citystate == 1)
            {
                foreach (var i in City)
                {
                    Console.WriteLine("Display List for City: {0}\n", i.Key);
                    foreach (var j in i.Value)
                    {
                        Console.WriteLine("Found person \"{0} {1}\" , residing in City {2}", j.firstName, j.lastName, j.city);
                    }


                }
            }
            else
            {
                foreach (var a in State)
                {
                    Console.WriteLine("Display List for State: {0}\n", a.Key);
                    foreach (var b in a.Value)
                    {
                        Console.WriteLine("Found person \"{0} {1}\" , residing in State {2}", b.firstName, b.lastName, b.state);
                    }

                }
            }

        }
        public static void Sorting(Dictionary<string, List<AddDetails>> addressBook)
        {
            SortedList<string, AddDetails> sorted;
            foreach (KeyValuePair<string, List<AddDetails>> element in addressBook)
            {
                Console.WriteLine("\n--------Displaying sorted Contact Person Details in address book: {0}-------\n", element.Key);
                sorted = new SortedList<string, AddDetails>();
                foreach (var member in element.Value)
                {
                    sorted.Add(member.firstName, member);
                }
                foreach (var member in sorted)
                {
                    Console.WriteLine(member.Value.ToString());
                }
            }
        }
        //Sort based on city name
        public static void SortBasedOnCity(Dictionary<string, List<AddDetails>> addressBook)
        {

            SortedList<string, AddDetails> sorted;
            foreach (KeyValuePair<string, List<AddDetails>> kvp in addressBook)
            {
                Console.WriteLine("\n--------Displaying Sorted contact based on city  in address book: {0}-------\n", kvp.Key);
                sorted = new SortedList<string, AddDetails>();
                foreach (var member in kvp.Value)
                {
                    sorted.Add(member.city, member);
                }
                foreach (var member in sorted)
                {
                    Console.WriteLine(member.Value.ToString());
                }
            }
        }
        //Sort based on State name
        public static void SortBasedOnState(Dictionary<string, List<AddDetails>> addressBook)
        {
            SortedList<string, AddDetails> sorted;
            foreach (KeyValuePair<string, List<AddDetails>> kvp in addressBook)
            {
                Console.WriteLine("\n--------Displaying Sorted contact based on State  in address book: {0}-------\n", kvp.Key);
                sorted = new SortedList<string, AddDetails>();
                foreach (var member in kvp.Value)
                {
                    sorted.Add(member.state, member);
                }
                foreach (var member in sorted)
                {
                    Console.WriteLine(member.Value.ToString());
                }
            }
        }
        //Sort based on zipcode
        public static void SortBasedOnZipCode(Dictionary<string, List<AddDetails>> addressBook)
        {
            SortedList<string, AddDetails> sorted;
            foreach (KeyValuePair<string, List<AddDetails>> kvp in addressBook)
            {
                Console.WriteLine("\n--------Displaying Sorted contact based on State  in address book: {0}-------\n", kvp.Key);
                sorted = new SortedList<string, AddDetails>();
                foreach (var member in kvp.Value)
                {
                    sorted.Add(member.zipCode, member);
                }
                foreach (var member in sorted)
                {
                    Console.WriteLine(member.Value.ToString());
                }
            }
        }
    }
}
