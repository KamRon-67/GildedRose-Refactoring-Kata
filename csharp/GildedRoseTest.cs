using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void TestOne()
        {
            var Items = new List<Item>();
            var app = new GildedRose();
            Assert.IsNotEmpty(app._Items);
        }
        
        [Test]
        public void TestTwo()
        {
            var Items = new List<Item> { new Item { Name = "testTwo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(Items);
            Assert.That(app._Items, Has.Exactly(1).Matches<Item>(p => p.Name == "testTwo"));
        }
    }
}
