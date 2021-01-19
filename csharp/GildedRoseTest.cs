using NUnit.Framework;
using csharp;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void TestOne()
        {
            var app = new GildedRose();
            Assert.IsNotEmpty(app._Items);
        }
        
        [Test]
        public void TestTwo()
        {
            var Items = new List<Item> { new Item { Name = "testTwo", SellIn = 1, Quality = 2 } };
            var app = new GildedRose(Items);
            Assert.That(app._Items, Has.Exactly(1).Matches<Item>(p => p.Name == "testTwo" && p.SellIn == 1 && p.Quality == 2));
        }

        [Test]
        public void TestThree()
        {

        }
    }
}
