using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_NEW
{
    class Program
    {
        static void Main(string[] args)
        {
            // ВАРИАНТ 12
            
            List<Phone> sales = new List<Phone>();
            sales.Add(new Phone { brand = "Samsung", model = "S25 ULTRA", week = 1, countSell = 1 });
            sales.Add(new Phone { brand = "Samsung", model = "S25 ULTRA", week = 2, countSell = 0 });
            sales.Add(new Phone { brand = "Samsung", model = "S25 ULTRA", week = 3, countSell = 3 });
            sales.Add(new Phone { brand = "Samsung", model = "S25 ULTRA", week = 4, countSell = 4 });
            sales.Add(new Phone { brand = "Samsung", model = "A55", week = 1, countSell = 0 });
            sales.Add(new Phone { brand = "Samsung", model = "A55", week = 2, countSell = 0 });
            sales.Add(new Phone { brand = "Samsung", model = "A55", week = 3, countSell = 2 });
            sales.Add(new Phone { brand = "Samsung", model = "A55", week = 4, countSell = 3 });
            sales.Add(new Phone { brand = "Samsung", model = "S24 FE", week = 1, countSell = 2 });
            sales.Add(new Phone { brand = "Samsung", model = "S24 FE", week = 2, countSell = 0 });
            sales.Add(new Phone { brand = "Samsung", model = "S24 FE", week = 3, countSell = 3 });
            sales.Add(new Phone { brand = "Samsung", model = "S24 FE", week = 4, countSell = 4 });



            sales.Add(new Phone { brand = "Iphone", model = "17 PRO MAX", week = 1, countSell = 1 });
            sales.Add(new Phone { brand = "Iphone", model = "17 PRO MAX", week = 2, countSell = 0 });
            sales.Add(new Phone { brand = "Iphone", model = "17 PRO MAX", week = 3, countSell = 0 });
            sales.Add(new Phone { brand = "Iphone", model = "17 PRO MAX", week = 4, countSell = 2 });
            sales.Add(new Phone { brand = "Iphone", model = "13 PRO", week = 1, countSell = 1 });
            sales.Add(new Phone { brand = "Iphone", model = "13 PRO", week = 2, countSell = 3 });
            sales.Add(new Phone { brand = "Iphone", model = "13 PRO", week = 3, countSell = 2 });
            sales.Add(new Phone { brand = "Iphone", model = "13 PRO", week = 4, countSell = 4 });
            sales.Add(new Phone { brand = "Iphone", model = "12 MINI", week = 1, countSell = 2 });
            sales.Add(new Phone { brand = "Iphone", model = "12 MINI", week = 2, countSell = 5 });
            sales.Add(new Phone { brand = "Iphone", model = "12 MINI", week = 3, countSell = 0 });
            sales.Add(new Phone { brand = "Iphone", model = "12 MINI", week = 4, countSell = 1 });
            sales.Add(new Phone { brand = "Iphone", model = "12 MINI", week = 4, countSell = 1 });
            sales.Add(new Phone { brand = "Iphone", model = "11 PRO", week = 2, countSell = 3 });
            sales.Add(new Phone { brand = "Iphone", model = "11 PRO", week = 3, countSell = 5 });


            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi note 13 pro+ 5g", week = 1, countSell = 6 });
            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi note 13 pro+ 5g", week = 2, countSell = 2 });
            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi note 13 pro+ 5g", week = 3, countSell = 3 });
            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi note 13 pro+ 5g", week = 4, countSell = 0 });
            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi 14 PRO", week = 1, countSell = 1 });
            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi 14 PRO", week = 2, countSell = 2 });
            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi 14 PRO", week = 3, countSell = 0 });
            sales.Add(new Phone { brand = "Xiaomi", model = "Redmi 14 PRO", week = 4, countSell = 0 });
            sales.Add(new Phone { brand = "Xiaomi", model = "POCO X7", week = 1, countSell = 1 });
            sales.Add(new Phone { brand = "Xiaomi", model = "POCO X7", week = 2, countSell = 1 });
            sales.Add(new Phone { brand = "Xiaomi", model = "POCO X7 PRO", week = 3, countSell = 2 });
            sales.Add(new Phone { brand = "Xiaomi", model = "POCO X7 PRO", week = 4, countSell = 3 });

            Function.ShowTopPhones(sales);


        }
    }
}
