using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2001200257_LuuHoangThuong
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
        };

            int capacity = 50;

            double maxValue = GreedyKnapsack(capacity, items);
            Console.WriteLine("Maximum value in Knapsack = " + maxValue);
            //-----------------------
            int[] coinValues = { 1, 5, 10, 25, 50 }; // Các giá trị đồng tiền
            int amount = 87; // Số tiền cần đổi

            int minCoins = CoinChange(coinValues, amount);
            Console.WriteLine("Minimum number of coins needed = " + minCoins);
            Console.ReadLine();
        }
        public class Item
        {
            public int Value { get; set; }
            public int Weight { get; set; }
            public double Ratio { get { return (double)Value / Weight; } }
        }
        public static double GreedyKnapsack(int capacity, List<Item> items)
        {
            // Sort items by value-to-weight ratio in descending order
            items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

            double totalValue = 0;
            int currentWeight = 0;

            foreach (var item in items)
            {
                if (currentWeight + item.Weight <= capacity)
                {
                    currentWeight += item.Weight;
                    totalValue += item.Value;
                }
                else
                {
                    int remainingWeight = capacity - currentWeight;
                    totalValue += item.Value * ((double)remainingWeight / item.Weight);
                    break;
                }
            }

            return totalValue;
        }
        public static int CoinChange(int[] coinValues, int amount)
        {
            Array.Sort(coinValues, (x, y) => y.CompareTo(x)); // Sắp xếp đồng tiền giảm dần
            int coinCount = 0;

            foreach (int coin in coinValues)
            {
                if (amount == 0)
                    break;

                // Số lượng đồng tiền hiện tại cần sử dụng
                int numCoins = amount / coin;
                if (numCoins > 0)
                {
                    coinCount += numCoins;
                    amount -= numCoins * coin;
                }
            }

            return coinCount;
        }


    }
    
}
