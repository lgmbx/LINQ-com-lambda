using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_com_lambda {
    class Program {

        static void Print<T>(string message, IEnumerable<T> collection) {
            Console.WriteLine(message);
            foreach(T item in collection) {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args) {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computer", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> list = new List<Product>() {
                new Product() { Id = 1,  Name = "Computer",  Price = 1100.0, Category = c2 },
                new Product() { Id = 2,  Name = "Hammer",    Price = 90.0,   Category = c1 },
                new Product() { Id = 3,  Name = "TV",        Price = 1700.0, Category = c3 },
                new Product() { Id = 4,  Name = "Notebook",  Price = 1300.0, Category = c2 },
                new Product() { Id = 5,  Name = "Saw",       Price = 80.0,   Category = c1 },
                new Product() { Id = 6,  Name = "Tablet",    Price = 700.0,  Category = c2 },
                new Product() { Id = 7,  Name = "Camera",    Price = 700.0,  Category = c3 },
                new Product() { Id = 8,  Name = "Printer",   Price = 350.0,  Category = c3 },
                new Product() { Id = 9,  Name = "MacBook",   Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0,  Category = c3 },
                new Product() { Id = 11, Name = "Level",     Price = 70.0,   Category = c1 }
            };


            Console.WriteLine("\n");
            var r1 = list.Where(x => x.Category.Tier == 1 && x.Price < 900);
            Print("TIER 1 AND PRICE < 900:", r1);

            Console.WriteLine("\n");
            var r2 = list.Where(x => x.Category.Name.Equals("Tools")).Select(x => x.Name);
            Print("Name of products from tools:", r2);

            Console.WriteLine("\n");
            var r3 = list.Where(x => x.Name[0].Equals('C'))
                         .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("Products that starts with the C letter, returning anonymous object ", r3);

            Console.WriteLine("\n");
            var r4 = list.Where(x => x.Category.Tier.Equals(1))
                        .OrderBy(p => p.Price)
                        .ThenBy(p => p.Name);
            Print("Tier 1 ordered by price, then by name", r4);

            Console.WriteLine("\n");
            var r5 = r4.Skip(2).Take(4);
            Print("same as the last one, skipping 2 products then taking the next 4", r5);
            
            Console.WriteLine("\n");
            var r6 = list.First();
            Console.WriteLine($"First or default test 1>> {r6}");

            
            Console.WriteLine("\n");
            var r7 = list.Where(p => p.Price > 3000).FirstOrDefault();
            Console.WriteLine($"First or default test 2>> {r7}");


            Console.WriteLine("\n");
            var r8 = list.Where(x => x.Id == 3).SingleOrDefault();
            Console.WriteLine($"Single or default test 1>> {r8}");

            Console.WriteLine("\n");
            var r9 = list.Where(x => x.Id == 30).SingleOrDefault();
            Console.WriteLine($"Single or default test 2>> {r9}");

            Console.WriteLine("\n");
            var r10 = list.Max(p => p.Price);
            Console.WriteLine($"max price {r10}");

            Console.WriteLine("\n");
            var r11 = list.Min(p => p.Price);
            Console.WriteLine($"min price {r11}");

            Console.WriteLine("\n");
            var r12 = list.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine($"Category 1 sum price {r12}");

            Console.WriteLine("\n");
            var r13 = list.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine($"Category 1 average price {r13}");

            Console.WriteLine("\n");
            var r14 = list.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine($"default if empty average price {r14}");

            Console.WriteLine("\n");
            var r15 = list.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine($"Category 1 aggregate sum {r15}");

            Console.WriteLine("\n");
            var r16 = list.GroupBy(p => p.Category);
            foreach(IGrouping<Category, Product> group in r16) {
                Console.WriteLine($"Category: {group.Key.Name}");
                foreach(Product p in group) {
                    Console.WriteLine(p);
                }
                Console.WriteLine("\n");
            }




        }
    }
}
