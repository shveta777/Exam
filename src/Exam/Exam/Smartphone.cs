using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Smartphone
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }

        public Smartphone(string marka, string model, int price)
        {
            Marka = marka;
            Model = model;
            Price = price;

        }
        //public override string ToString() => $"{Marka},{Model},{Price}";
        //File.WriteAllText(filename, string.Join(n / n / n, stringData));
    }
}
