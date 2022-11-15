using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_2
{   
    class Taxi838
    {
        public static void MakeOrder(string begin, string end)
        {
            Console.WriteLine($"begin: {begin}, end: {end}");
        }
    }
    class MoYoTaxi
    {
        public static void MakeOrderBegin(string detail, string begin)
        {
            if (detail == "begin")
            {
                Console.WriteLine($"begin: {begin}");
            }
        }

        public static void MakeOrderEnd(string detail, string end)
        {
            if (detail == "end")
            {
                Console.WriteLine($"end: {end}");
            }
        }
    }
    class Bolt
    {
        public static void MakeOrder(string begin, string end, DateTime date)
        {
            Console.WriteLine($"begin: {begin}, end: {end}, time: {date}");
        }
    }
    class TaxiFacade
    {
        public static void MakeOrder(string taxi, string begin, string end)
        {
            switch (taxi)
            {
                case "Taxi838":
                    Taxi838.MakeOrder(begin, end);
                    break;
                case "MoYoTaxi":
                    MoYoTaxi.MakeOrderEnd("end", end);
                    MoYoTaxi.MakeOrderBegin("begin", begin);
                    break;
                case "Bolt":
                    Bolt.MakeOrder(begin, end, DateTime.Now);
                    break;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiFacade.MakeOrder("Taxi838", "вул. Василя Стуса", "Пузата хата");
            Console.WriteLine();
            TaxiFacade.MakeOrder("MoYoTaxi", "Набережна незалежності", "ЇжДвіж");
            Console.WriteLine();
            TaxiFacade.MakeOrder("Bolt", "Проспект Свободи", "Араґві");
            Console.WriteLine();
        }
    }
}
