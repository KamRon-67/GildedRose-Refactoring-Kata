using NUnit.Framework;
using csharp;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void SellIn_When_Not_Sulfuras_Hand_Of_Ragnaros()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
        }

        [Test]
        public void Quality_When_Not_Sulfuras_Hand_Of_Ragnaros()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
        }

        [Test]
        public void Quality_Greater_than_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 49, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].Quality);
        }

        [Test]
        public void Once_The_Sell_By_Date_Has_Passed_Quality_Degrades_Twice_As_Fast()
        {
        }

        [Test]
        public void The_Quality_Of_An_item_Is_Never_Negative()
        {
        }

        [Test]
        public void Aged_Brie_Actually_Increases_In_Quality_The_Older_It_Gets()
        {
        }

        [Test]
        public void The_Quality_Of_An_Item_Is_Never_More_Than_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Not Aged Brie", SellIn = 0, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            for (int i = 0; i < 50; i++)
            {
                // Here you can give each person a custom name based on a number
                Items.Add(new Item { Name = "Not Aged Brie" + (i + 1), SellIn = 0, Quality = 0 });
            }
            app.UpdateQuality();
        }

        [Test]
        public void Sulfuras_Will_Not_Decreases_In_Quality()
        {
        }
    }
}
