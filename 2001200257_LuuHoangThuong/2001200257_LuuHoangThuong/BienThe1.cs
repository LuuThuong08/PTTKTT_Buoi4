using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2001200257_LuuHoangThuong
{
    class BienThe1
    {
        static void Main(string[] args)
        {
            int[] coinValues = { 1, 5, 10, 25, 50 }; // Các giá trị đồng tiền
            int amount = 87; // Số tiền cần đổi

            int minCoins = CoinChange(coinValues, amount);
            Console.WriteLine("Số lượng đồng tiền cần ít nhất = " + minCoins);
            Console.ReadLine();
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
