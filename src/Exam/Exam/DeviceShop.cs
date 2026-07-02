using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class DeviceShop
    {
        private List<Smartphone> smartphones = new();

       
        public void AddSmartphone(Smartphone smartphone)
        {
            smartphones.Add(smartphone);
        }

        public List<Smartphone> GetSortedByPriceAndMarka()
        {
            return smartphones
                .OrderBy(s => s.Price)          
                .ThenBy(s => s.Marka)         
                .ToList();
            
        }

        public List<Smartphone> GetOriginal()
        {
            
            return new List<Smartphone>(smartphones);
        }
    }
}