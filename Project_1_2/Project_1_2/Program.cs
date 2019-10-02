using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    /*
     * Name: Nick Egner
     * Date: 10.2.2019
     * Homework 01-2
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] OPTIONS = { "Create a Friend / Family entry", "Create  a Business Contact Entry", "Quit" };
            int selectNumber;

            for (int i = 0; i < OPTIONS.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {OPTIONS[i]}");
            }
            Console.WriteLine(" ");
            Console.Write("Choose item 1, 2, or 3: ");
            selectNumber = Convert.ToInt32(Console.ReadLine());

            while(selectNumber != 1 && selectNumber != 2 && selectNumber != 3)
            {
                Console.Write("Please enter a valid number");
                selectNumber = Convert.ToInt32(Console.ReadLine());
            }

            while (selectNumber == 1 || selectNumber == 2 || selectNumber == 3)
            {
                if (selectNumber == 1)
                {
                    FriendFamily();

                    Console.Write("Choose item 1, 2, or 3: ");
                    selectNumber = Convert.ToInt32(Console.ReadLine());
                }
                else if (selectNumber == 2)
                {
                    Company();

                    Console.Write("Choose item 1, 2, or 3: ");
                    selectNumber = Convert.ToInt32(Console.ReadLine());
                }
             
                else if (selectNumber == 3)
                {
                    Console.Write("Thanks for using the program");
                    Environment.Exit(0);
                }

            }



        }//end of main method

        static void FriendFamily()
        {
            string[] RelationshipChoices = { "(I) Immediate family", "(S) Sibling/In-law", "(P) Parent/In-law", "(C) Cousin/Aunt/Uncle/etc", "(Enter) Other" };
            string monthString;
            Contact contact = new Contact();
            FamilyFriends friend = new FamilyFriends();


            Console.Write("First name (req'd): ");
            contact.firstName = Console.ReadLine();
            while (contact.firstName == "")
            {
                Console.Write("A name must me entered: ");
                contact.firstName = Console.ReadLine();
            }

            Console.Write("Last name (req'd): ");
            contact.lastName = Console.ReadLine();
            while (contact.lastName == "")
            {
                Console.Write("A name must me entered: ");
                contact.lastName = Console.ReadLine();
            }

            Console.Write("Address (req'd): ");
            contact.address = Console.ReadLine();
            while (contact.address == "")
            {
                Console.Write("An address must be entered: ");
                contact.address = Console.ReadLine();
            }

            Console.Write("City (req'd): ");
            contact.city = Console.ReadLine();
            while (contact.city == "")
            {
                Console.Write("A city must be entered: ");
                contact.city = Console.ReadLine();
            }
            Console.Write("State (or enter if N/A): ");
            contact.state = Console.ReadLine();
            if (contact.state == "")
            {
                contact.state = "N/A";
            }
            Console.Write("Zip Code (or enter if no zipcode): ");
            contact.zipCode = Console.ReadLine();
            if (contact.zipCode == "")
            {
                contact.zipCode = "N/A";
            }
            if (contact.state == "N/A")
            {
                Console.Write("Country: ");
                contact.country = Console.ReadLine();
            }
            else
            {
                contact.country = "USA";
            }
            Console.Write("Phone Number - land line: ");
            contact.phoneLand = Console.ReadLine();
            if (contact.phoneLand == "")
            {
                contact.phoneLand = "N/A";
            }
            Console.Write("Phone number - cell phone: ");
            contact.phoneCell = Console.ReadLine();
            if (contact.phoneCell == "")
            {
                contact.phoneCell = "N/A";
            }
            for (int i = 0; RelationshipChoices.Length > i; i++)
            {
                Console.WriteLine("Relationship choices:");
                Console.WriteLine($"    {RelationshipChoices[i]}");
            }
            Console.Write("Relationship to you (Key in letter or Enter): ");
            friend.relationship = Console.ReadLine();
            if (friend.relationship == "")
            {
                friend.relationship = "N/A";
            }
            else if (friend.relationship == "I")
            {
                friend.relationship = RelationshipChoices[0];
            }
            else if (friend.relationship == "S")
            {
                friend.relationship = RelationshipChoices[1];
            }
            else if (friend.relationship == "P")
            {
                friend.relationship = RelationshipChoices[2];
            }
            else if (friend.relationship == "C")
            {
                friend.relationship = RelationshipChoices[3];
            }
            else
            {
                Console.Write("enter valid entry: ");
                friend.relationship = Console.ReadLine();
            }

            Console.Write("Month of birthday 1-12 (or enter if not entering a birthday): ");
            monthString = Console.ReadLine();
            if (monthString != "")
            {
                friend.birthdayMonth = Convert.ToInt32(monthString);
                while( friend.birthdayMonth > 12 || friend.birthdayMonth < 1)
                {
                    Console.Write("Please enter a valid month: ");
                    friend.birthdayMonth = Convert.ToInt32(Console.ReadLine());

                }
                string month = Convert.ToString(friend.birthdayMonth);
                if(month.Length == 1)
                {
                    month = "0" + month;
                }

                Console.Write("Day of birthday, between 1-31 (req'd): ");
                friend.birthdayDay = Convert.ToInt32(Console.ReadLine());
                while(friend.birthdayDay < 1 || friend.birthdayDay > 31)
                {
                    Console.Write("Please enter a valid day: ");
                    friend.birthdayDay = Convert.ToInt32(Console.ReadLine());
                }
                string day = Convert.ToString(friend.birthdayDay);
                if(day.Length == 1)
                {
                    day = "0" + day;
                }
                Console.Write("4-digit Year of Birthday (req'd)");
                friend.birthdayYear = Convert.ToInt32(Console.ReadLine());
                while(friend.birthdayYear > 2020 || friend.birthdayYear < 1900)
                {
                    Console.Write("Please enter a valid year: ");
                    friend.birthdayYear = Convert.ToInt32(Console.ReadLine());
                }
                string year = Convert.ToString(friend.birthdayYear);



                string date = year + month + day;
                int dateInt = Convert.ToInt32(date);
                DateTime yourDateTime = DateTime.ParseExact(dateInt.ToString(), "yyyyMMdd", null);
                friend.birthday = yourDateTime;
                DateTime tenDayReminder = friend.birthday.AddDays(-10);
                friend.tenDayReminder = tenDayReminder;
            }
            else
            {
                friend.birthdayMonth = 0;
                
            }
            
            FriendFamilyPrint(contact, friend);
            WriteToFileFriendFamily(contact, friend);




        }//end friendFamily method

        static void Company()
        {
            Contact contact = new Contact();
            CompanyCon company = new CompanyCon();

            Console.Write("First name (req'd): ");
            contact.firstName = Console.ReadLine();
            while (contact.firstName == "")
            {
                Console.Write("A name must me entered: ");
                contact.firstName = Console.ReadLine();
            }

            Console.Write("Last name (req'd): ");
            contact.lastName = Console.ReadLine();
            while (contact.lastName == "")
            {
                Console.Write("A name must me entered: ");
                contact.lastName = Console.ReadLine();
            }

            Console.Write("Address (req'd): ");
            contact.address = Console.ReadLine();
            while (contact.address == "")
            {
                Console.Write("An address must be entered: ");
                contact.address = Console.ReadLine();
            }

            Console.Write("City (req'd): ");
            contact.city = Console.ReadLine();
            while (contact.city == "")
            {
                Console.Write("A city must be entered: ");
                contact.city = Console.ReadLine();
            }
            Console.Write("State (or enter if N/A): ");
            contact.state = Console.ReadLine();
            if (contact.state == "")
            {
                contact.state = "N/A";
            }
            Console.Write("Zip Code (or enter if no zipcode): ");
            contact.zipCode = Console.ReadLine();
            if (contact.zipCode == "")
            {
                contact.zipCode = "N/A";
            }
            if (contact.state == "N/A")
            {
                Console.Write("Country: ");
                contact.country = Console.ReadLine();
            }
            else
            {
                contact.country = "USA";
            }
            Console.Write("Phone Number - land line: ");
            contact.phoneLand = Console.ReadLine();
            if (contact.phoneLand == "")
            {
                contact.phoneLand = "N/A";
            }
            Console.Write("Phone number - cell phone: ");
            contact.phoneCell = Console.ReadLine();
            if (contact.phoneCell == "")
            {
                contact.phoneCell = "N/A";
            }

            Console.Write("Company name (or Enter for ACME TNT Manufacture): ");
            company.company = Console.ReadLine();
            if (company.company == "")
            {
                company.company = "ACME TNT Manufacture";
            }
            Console.Write("Position (or Enter if N/A): ");
            company.position = Console.ReadLine();
            if (company.position == "")
            {
                company.position = "N/A";
            }
            if (company.company == "ACME TNT Manufacture")
            {
                string email = contact.lastName + contact.firstName + "@acme.com";
                company.email = email;
            } else
            {
                Console.Write("Email: ");
                company.email = Console.ReadLine();
            }

            ComapnyPrint(contact, company);
            WriteToFileCompany(contact, company);
             
        }//end company method
        static void WriteToFileCompany(Contact contact, CompanyCon company)
        {
            string pathProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
            string fileName = "ContactList.txt";
            string filePath = pathProfile + "\\" + fileName;
            FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);


            streamWriter.WriteLine("Company entry: ");
            streamWriter.WriteLine(" ");
            streamWriter.WriteLine($"Name: {contact.firstName} {contact.lastName}");
            streamWriter.WriteLine($"Address: {contact.address}");
            streamWriter.WriteLine($"City: {contact.city}");
            streamWriter.WriteLine($"State: {contact.state}");
            streamWriter.WriteLine($"Zip code: {contact.zipCode}");
            streamWriter.WriteLine($"Country: {contact.country}");
            streamWriter.WriteLine($"Land line number: {contact.phoneLand}");
            streamWriter.WriteLine($"Cell number: {contact.phoneCell}");
            streamWriter.WriteLine(" ");
            streamWriter.WriteLine($"Company: {company.company}");
            streamWriter.WriteLine($"Position: {company.position}");
            streamWriter.WriteLine($"Email: {company.email}");
            streamWriter.WriteLine("----------------------------------------------");

            streamWriter.Close();
            fileStream.Close();
        }

        static void ComapnyPrint(Contact contact, CompanyCon company)
        {
            Console.WriteLine("Company entry: ");
            Console.WriteLine(" ");
            Console.WriteLine($"Name: {contact.firstName} {contact.lastName}");
            Console.WriteLine($"Address: {contact.address}");
            Console.WriteLine($"City: {contact.city}");
            Console.WriteLine($"State: {contact.state}");
            Console.WriteLine($"Zip code: {contact.zipCode}");
            Console.WriteLine($"Country: {contact.country}");
            Console.WriteLine($"Land line number: {contact.phoneLand}");
            Console.WriteLine($"Cell number: {contact.phoneCell}");
            Console.WriteLine(" ");
            Console.WriteLine($"Company: {company.company}");
            Console.WriteLine($"Position: {company.position}");
            Console.WriteLine($"Email: {company.email}");
        }

        static void FriendFamilyPrint(Contact contact, FamilyFriends friends)
        {
            Console.WriteLine("Family-Friend entry: ");
            Console.WriteLine(" ");
            Console.WriteLine($"Name: {contact.firstName} {contact.lastName}");
            Console.WriteLine($"Address: {contact.address}");
            Console.WriteLine($"City: {contact.city}");
            Console.WriteLine($"State: {contact.state}");
            Console.WriteLine($"Zip code: {contact.zipCode}");
            Console.WriteLine($"Country: {contact.country}");
            Console.WriteLine($"Land line number: {contact.phoneLand}");
            Console.WriteLine($"Cell number: {contact.phoneCell}");
            Console.WriteLine(" ");
            Console.WriteLine($"Relationship: {friends.relationship}");
            if(friends.birthdayMonth != 0)
            {
                Console.WriteLine($"Birthday: {friends.birthday}");
                Console.WriteLine($"10 days before birthday: {friends.tenDayReminder}");
            }
            



        }//end FriendFamilyPrint method

        static void WriteToFileFriendFamily(Contact contact, FamilyFriends friends)
        {
            string pathProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
            string fileName = "ContactList.txt";
            string filePath = pathProfile + "\\" + fileName;
            FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);


            streamWriter.WriteLine("Family-Friend entry: ");
            streamWriter.WriteLine(" ");
            streamWriter.WriteLine($"Name: {contact.firstName} {contact.lastName}");
            streamWriter.WriteLine($"Address: {contact.address}");
            streamWriter.WriteLine($"City: {contact.city}");
            streamWriter.WriteLine($"State: {contact.state}");
            streamWriter.WriteLine($"Zip code: {contact.zipCode}");
            streamWriter.WriteLine($"Country: {contact.country}");
            streamWriter.WriteLine($"Land line number: {contact.phoneLand}");
            streamWriter.WriteLine($"Cell number: {contact.phoneCell}");
            streamWriter.WriteLine(" ");
            streamWriter.WriteLine($"Relationship: {friends.relationship}");
            if(friends.birthdayMonth != 0)
            {
                streamWriter.WriteLine($"Birthday: {friends.birthday}");
                streamWriter.WriteLine($"10 days before birthday: {friends.tenDayReminder}");
            }
            
            streamWriter.WriteLine("----------------------------------------------");

            streamWriter.Close();
            fileStream.Close();
        }

    }// end of class program
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string country { get; set; }
        public string phoneLand { get; set; }
        public string phoneCell { get; set; }
        
    }//end class Contact
    public class FamilyFriends
    {
        public string relationship { get; set; }
        public int birthdayMonth { get; set; }
        public int birthdayDay { get; set; }
        public int birthdayYear { get; set; }
        public DateTime birthday { get; set; }
        public DateTime tenDayReminder { get; set; }
    }

    public class CompanyCon
    {
        public string company { get; set; }
        public string position { get; set; }
        public string email { get; set; }
    }
}
    