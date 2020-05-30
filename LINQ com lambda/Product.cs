using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_com_lambda {
    class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }


        public override string ToString() {
            return $"ID:{Id}, {Name}, Price:{Price:F2}, Category:{Category.Name}, Tier:{Category.Tier}.";
        }

    }
}
