using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace TaskLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Soal1.PhoneNumber();
            Soal1.hasArticles();
            Soal1.hasAnnis();
            Soal1.year2020();
            Soal1.Born86();
            Soal1.hasTips();
            Soal1.publish2019();
            Soal2.madeInFeb();
            Soal2.purchaseAri();
            Soal2.lowerThan();
            Soal3.MeetingRoom();
            Soal3.electronicDevice();
            Soal3.furnitures();
            Soal3.purchased();
            Soal3.brownColor();


        }
    }

    public class Database1
    {
        protected static string json1 = File.ReadAllText(@"/Users/user/Projects/Task3_BootcampRefactory/Task3_BootcampRefactory/Satuu.json");
        protected static List<User1> data1 = JsonConvert.DeserializeObject<List<User1>>(json1);
    }

    public class Soal1 : Database1
    {

        public static void PhoneNumber()
        {
            var hasil = data1.Where(k => k.Profile.Phones.Count == 0).Select(k => k.Profile.Full_name);

            Console.WriteLine("User who doesn't have any phone numbers : ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }

        public static void hasArticles()
        {
            var hasil = data1.Where(k => k.Articles.Count != 0).Select(k => k.Profile.Full_name);

            Console.WriteLine("User who have articles : ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }

        public static void hasAnnis()
        {
            var hasil = data1.Where(k => k.Profile.Full_name.ToLower().Contains("annis")).Select(k => k.Profile.Full_name);

            Console.WriteLine("User who have 'Annis' on their name : ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }

        public static void year2020()
        {
            var hasil = data1.Where(k => k.Articles.Any(l => l.Published_at.Year == 2020)).Select(k => k.Profile.Full_name);

            Console.WriteLine("User who have articles on 2020: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }

        public static void Born86()
        {
            var hasil = data1.Where(k => k.Profile.Birthday.Year == 1986).Select(k => k.Profile.Full_name);

            Console.WriteLine("User who are born on 1986 : ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }

        public static void hasTips()
        {
            var hasil = data1.Where(k => k.Articles.Any(l => l.Title.ToLower().Contains("tips"))).SelectMany(k => k.Articles.Select(l => l.Title));

            Console.WriteLine("Articles that contain 'tips' on the title: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }

        public static void publish2019()
        {
            var hasil = data1.Where(k => k.Articles.Any(l => l.Published_at.Year == 2019 && l.Published_at.Month < 8)).SelectMany(k => k.Articles.Select(l => l.Title));
            var hasil1 = data1.Where(k => k.Articles.Any(l => l.Published_at.Year < 2019)).SelectMany(k => k.Articles.Select(l => l.Title));

            Console.WriteLine("Articles that published before August 2019: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(String.Join("\n", hasil1));
            Console.WriteLine(" ");
        }

    }

    public class Database2
    {
        protected static string json2 = File.ReadAllText(@"/Users/user/Projects/Task3_BootcampRefactory/Task3_BootcampRefactory/Dua.json");
        protected static List<User2> data2 = JsonConvert.DeserializeObject<List<User2>>(json2);
    }

    public class Soal2 : Database2
    {
        public static void madeInFeb()
        {
            var hasil = data2.Where(k => k.Created_at.Month == 2).Select(k => k.Order_id);

            Console.WriteLine("Order id that purchases made in February : ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }

        public static void purchaseAri()
        {
            var grandTotal = data2.Where(k => k.Customer.Name == "Ari").Sum(k => k.Items.Sum(l => l.Price * l.Qty));

            Console.WriteLine("Total purchases made by Ari: ");
            Console.WriteLine(grandTotal);
            Console.WriteLine(" ");
        }

        public static void lowerThan()
        {
            var hasil = data2.GroupBy(k => k.Customer.Name)
                .Select(k => new { name = k.First().Customer.Name, total = k.Select(l => l.Items.Sum(m => m.Price * m.Qty)).Sum() })
                .Where(k => k.total < 300000);

            Console.WriteLine("People who have purchases with total lower than 300000: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");
        }
    }

    public class Database3
    {
        protected static string json3 = File.ReadAllText(@"/Users/user/Projects/Task3_BootcampRefactory/Task3_BootcampRefactory/Tiga.json");
        protected static List<User3> data3 = JsonConvert.DeserializeObject<List<User3>>(json3);
    }

    public class Soal3 : Database3
    {
        public static void MeetingRoom()
        {
            var hasil = data3.Where(k => k.Placement.Name == "Meeting Room").Select(k => k.Name);

            Console.WriteLine("Items in Meeting Room: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");

            var MRFile = JsonConvert.SerializeObject(hasil);
            File.WriteAllText(@"/Users/user/Projects/Task14_BootcampRefactory/TaskLINQ/item.json", MRFile);


        }

        public static void electronicDevice()
        {
            var hasil = data3.Where(k => k.Type == "electronic").Select(k => k.Name);

            Console.WriteLine("All electronic devices: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");

            var EDFile = JsonConvert.SerializeObject(hasil);
            File.WriteAllText(@"/Users/user/Projects/Task14_BootcampRefactory/TaskLINQ/electronics.json", EDFile);
        }

        public static void furnitures()
        {
            var hasil = data3.Where(k => k.Type == "furniture").Select(k => k.Name);

            Console.WriteLine("All furnitures: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");

            var furniFile = JsonConvert.SerializeObject(hasil);
            File.WriteAllText(@"/Users/user/Projects/Task14_BootcampRefactory/TaskLINQ/furnitures.json", furniFile);
        }

        public static void purchased()
        {
            var hasil = data3.Where(k => k.Purchased_at.Day == 16).Select(k => k.Name);

            Console.WriteLine("Items that was purchases at 16 january 2020: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");

            var purchFile = JsonConvert.SerializeObject(hasil);
            File.WriteAllText(@"/Users/user/Projects/Task14_BootcampRefactory/TaskLINQ/purchased-at-2020-01-16.json", purchFile);
        }

        public static void brownColor()
        {
            var hasil = data3.Where(k => k.Tags.Contains("brown")).Select(k => k.Name);

            Console.WriteLine("Items with brown color: ");
            Console.WriteLine(String.Join("\n", hasil));
            Console.WriteLine(" ");

            var BCFile = JsonConvert.SerializeObject(hasil);
            File.WriteAllText(@"/Users/user/Projects/Task14_BootcampRefactory/TaskLINQ/all-browns.json", BCFile);
        }

    }
}