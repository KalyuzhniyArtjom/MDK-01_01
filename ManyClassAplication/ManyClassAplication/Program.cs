using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyClassAplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            Goods car1 = new Goods();
            car1.SetName("Mercedes-Benz");
            car1.SetPrice(1200000);
            Goods car2 = new Goods();
            car2.SetName("УАЗ");
            car2.SetPrice(10000000);

            Warehouse storage = new Warehouse();
            storage.SetIdentifier(1);
            storage.SetLocation("Торжок, Студенческая 3.");
            storage.SetProductCount(car1, 2);
            storage.SetProductCount(car2, 5);

            Console.WriteLine("Адрес склада: " + storage.GetLocation());
            Console.WriteLine("Идентификатор склада: " + storage.GetIdentifier());

            Console.Write("Сумма всех товаров на складе: "); storage.CalculateMoney();

            Console.WriteLine();
            Console.WriteLine("Название, количество, цена.");

            Report report = new Report();
            ReportRow row1 = new ReportRow
            {
                Product = "Йогурт",
                Quantity = 9,
                Price = 70
            };

            ReportRow row2 = new ReportRow
            {
                Product = "Сырок",
                Quantity = 11,
                Price = 40
            };

            ReportRow row3 = new ReportRow
            {
                Product = "Творог",
                Quantity = 3,
                Price = 120
            };

            report.AddReport(row1);
            report.AddReport(row2);
            report.AddReport(row3);

            report.PrintReport();
        }
    }
}
