using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Smartphone
    {
        string Marka { get; set; }
        string Model { get; set; }
        int Price { get; set; }
    
    public Smartphone(string marka, string model, int price)
        {
            Marka = marka;
            Model = model;
            Price = price;
        }
    } }
