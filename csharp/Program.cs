using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new GildedRose();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                foreach(var gildedRoseItem in app._Items)
                {
                    Console.WriteLine(gildedRoseItem.ToString());
                }
                Console.WriteLine("");

                app.UpdateQuality();
            }
        }
    }
}
