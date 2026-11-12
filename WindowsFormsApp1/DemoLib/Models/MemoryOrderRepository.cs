using System.Collections.Generic;

namespace DemoLib.Models
{
    public class MemoryOrderRepository : IOrderRepository
    {
        // Твой существующий метод Load() оставь как есть
        public List<Order> Load()
        {
            return new List<Order>();
        }

        // ДОБАВЬ ВОТ ЭТОТ МЕТОД:
        public List<Product> LoadProducts()
        {
            // Возвращаем пустой список, так как мы теперь используем базу данных
            return new List<Product>();
        }
    }
}