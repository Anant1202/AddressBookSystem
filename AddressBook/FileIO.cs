using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class FileIO
    {
        public static void StreamReaderandWriter(Dictionary<string, List<AddDetails>> addressbooknames)
        {
            string path = @"C:\Bridgelabz-Regular batch\AddressBook\AddressBook\Data.txt";
            using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (KeyValuePair<string, List<AddDetails>> kvPair in addressbooknames)
                    {
                        writer.WriteLine("{0}: {1}", kvPair.Key, kvPair.Value);
                    }
                    writer.Close();
                    Console.WriteLine("File is written");
                }
            }
            StreamReader file1 = new StreamReader(@"C:\Bridgelabz-Regular batch\AddressBook\AddressBook\Data.txt");
            Console.WriteLine("Content of the file");
            string str1 = file1.ReadLine();
            while (str1 != null)
            {
                Console.WriteLine(str1);

                str1 = file1.ReadLine();
            }
            file1.Close();
            
        }
    }
}