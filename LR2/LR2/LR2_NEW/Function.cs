using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LR2_NEW
{


    class Function
    {

        public static void ShowTopPhones(List<Phone> phones)
        {
            Console.WriteLine("Введите марку телефона (Samsung, Iphone, Xiaomi): ");
            string brand = Console.ReadLine();

            Dictionary<string, int> modelSales = new Dictionary<string, int>();
            foreach (Phone phone in phones)
            {
                if (phone.brand == brand)
                {
                    if (modelSales.ContainsKey(phone.model))
                    {
                        modelSales[phone.model] += phone.countSell;
                    }
                    else
                    {
                        modelSales.Add(phone.model, phone.countSell);
                    }
                }
            }

            if (modelSales.Count == 0)
            {
                Console.WriteLine("Такого бренда нету в магазине");
                return;
            }

            string[] modelName = new string[modelSales.Count];
            modelSales.Keys.CopyTo(modelName, 0);

            for (int i = 0; i < modelName.Length - 1; i++)
            {
                for (int j = 0; j < modelName.Length - 1 - i; j++)
                {
                    double sales1 = (double)modelSales[modelName[j]] / 4;
                    double sales2 = (double)modelSales[modelName[j + 1]] / 4;

                    if (sales1 < sales2)
                    {
                        string temp = modelName[j];
                        modelName[j] = modelName[j + 1];
                        modelName[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine($"Модели бренда {brand}: ");
            for (int i = 0; i < modelName.Length; i++)
            {
                double average = (double)modelSales[modelName[i]] / 4;
                Console.WriteLine($"{modelName[i]} , {average} шт");
            }
        }
    }
}

