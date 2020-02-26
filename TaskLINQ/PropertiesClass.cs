using System;
using System.Collections.Generic;

namespace TaskLINQ
{
    public class User1
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public Profile Profile { get; set; }
        public List<Article> Articles { get; set; }

    }

    public class Profile
    {
        public string Full_name { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Phones { get; set; }
    }

    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Published_at { get; set; }
    }

    public class User2
    {
        public string Order_id { get; set; }
        public DateTime Created_at { get; set; }
        public Customer Customer { get; set; }
        public List<Items> Items { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }


    public class User3
    {
        public int Inventory_id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Purchased_at { get; set; }
        public Placement Placement { get; set; }
    }

    public class Placement
    {
        public string Name { get; set; }
        public int Room_id { get; set; }
    }

    public class User4
    {
        public int Inventory_id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Tags { get; set; }
        public int Purchased_at { get; set; }
        public Placement Placement { get; set; }
    }
}
