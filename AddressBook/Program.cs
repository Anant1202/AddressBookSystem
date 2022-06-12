using System;

namespace AddressBook
{
    public class Program
    {
        public static Dictionary<string, List<AddDetails>> addressBook = new Dictionary<string, List<AddDetails>>();
        public static Dictionary<string, List<AddDetails>> City = new Dictionary<string, List<AddDetails>>();
        public static Dictionary<string, List<AddDetails>> State = new Dictionary<string, List<AddDetails>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System Program");
            Console.WriteLine("Enter the number of address books: ");
            int noOfAddressBook = Convert.ToInt32(Console.ReadLine());
            int noOfBooks = 0;
            while (noOfBooks < noOfAddressBook)
            {
                Console.WriteLine("Enter the address book name : ");
                string addressbookname = Console.ReadLine();
                AddDetails addrBook = new AddDetails();
                Console.WriteLine("Enter the no of contacts in the address book: ");
                int noOfContact = Convert.ToInt32(Console.ReadLine());

                while (noOfContact > 0)
                {
                    Console.WriteLine("Enter the details of contact to be added: ");

                    Console.Write("Enter First Name: ");
                    string FirstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string LastName = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    string PhoneNumber = Console.ReadLine();

                    Console.Write("Enter Address : ");
                    string Addresses = Console.ReadLine();

                    Console.Write("Enter City : ");
                    string City = Console.ReadLine();

                    Console.Write("Enter State : ");
                    string State = Console.ReadLine();

                    Console.Write("Enter ZipCode: ");
                    string ZipCode = Console.ReadLine();

                    Console.Write("Enter EmailId: ");
                    string EmailId = Console.ReadLine();
                    addrBook.GetUserInfo(FirstName, LastName, PhoneNumber, Addresses, City, State, ZipCode, EmailId);
                    noOfContact--;
                    //addressBook.Add(addressbookname, addrBook.people);
                    Console.WriteLine(" ");
                    addrBook.ListingPeople();
                }
                Console.WriteLine("1.To modify the details");
                Console.WriteLine("2.To remove the details");
                Console.WriteLine("3.city or state");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addrBook.EditInfo();
                        Console.WriteLine(" ");
                        addrBook.ListingPeople();
                        break;
                    case 2:
                        addrBook.DeleteInfo();
                        Console.WriteLine(" ");
                        addrBook.ListingPeople();
                        break;
                    case 3:
                        Console.WriteLine("Enter 1-To Search a person through a City");
                        Console.WriteLine("Enter 2-To Search a person through a State");
                        Console.WriteLine("Enter 3-To view a person by state list or city list");
                        Console.WriteLine("Enter 4-Sort Contact People");
                        Console.WriteLine("Enter 5-Sort based on city");
                        Console.WriteLine("Enter 6-Sort based on State");
                        Console.WriteLine("Enter 7-Sort based on zipcode");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {

                            case 1:
                                SearchAddress(opt);
                                break;
                            case 2:
                                SearchAddress(opt);
                                break;
                            case 3:
                                AddDetails.DisplayCityorState();
                                break;
                            case 4:
                                AddDetails.Sorting(addressBook);
                                break;
                            case 5:
                                AddDetails.SortBasedOnCity(addressBook);
                                break;
                            case 6:
                                AddDetails.SortBasedOnState(addressBook);
                                break;
                            case 7:
                                AddDetails.SortBasedOnZipCode(addressBook);
                                break;
                            default:
                                Console.WriteLine("Invalid Option!");
                                break;
                        }
                        break;
                }
                if (addressBook.ContainsKey(addressbookname))
                {
                    Console.WriteLine("Existing address book name");
                    return;
                }
                else
                {
                    addressBook.Add(addressbookname, addrBook.people);
                }
                noOfBooks++;
                foreach (KeyValuePair<string, List<AddDetails>> addr in addressBook)
                {
                    Console.WriteLine("The address Books are:{0}", addr.Key);

                }
            }
            static void SearchAddress(int option)
            {
                string city, state;
                if (option == 1)
                {
                    Console.WriteLine("Enter the City Name");
                    city = Console.ReadLine();
                    foreach (KeyValuePair<string, List<AddDetails>> kvp in addressBook)
                    {
                        AddDetails.StoreCityList(kvp.Key, kvp.Value, city);

                    }
                    if (option == 2)
                    {
                        Console.WriteLine("Enter the City Name");
                        state = Console.ReadLine();
                        foreach (KeyValuePair<string, List<AddDetails>> kvp in addressBook)
                        {
                            AddDetails.StoreStateList(kvp.Key, kvp.Value, state);
                        }
                    }
                }
            }
        }
    }
}

