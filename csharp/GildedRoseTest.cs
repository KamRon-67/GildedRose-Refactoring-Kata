using NUnit.Framework;
using csharp;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        [TestCase("foo", "foo")]
        public void foo(string name, string answer)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].Name);
        }

        [Test]
        [TestCase(0, 0, "foo", -1)]
        [TestCase(10, 10, "foo", 9)]
        [TestCase(20, 20, "Sulfuras, Hand of Ragnaros", 20)]
        //Hand_Of_Ragnaros
        public void SellIn_Sulfuras_Hand_Of_Ragnaros(int sellIn, int quality, string name, int answer)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].SellIn);
        }

        [Test]
        [TestCase(0, 0, "foo", -1)]
        [TestCase(10, 10, "foo", 9)]
        public void Quality_When_Not_Sulfuras_Hand_Of_Ragnaros(int sellIn, int quality, string name, int answer)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].SellIn);
        }

        [Test]
        [TestCase(49, 0, "Aged Brie", 1)]
        [TestCase(51, 0, "Aged Brie", 1)]
        [TestCase(49, 0, "Not Aged Brie", 0)]
        [TestCase(51, 0, "Not Aged Brie", 0)]
        public void Quality_Greater_than_50(int sellIn, int quality, string name, int answer)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].Quality);
        }

        [Test]
        [TestCase(0, 8, "Not Aged Brie", 6)]
        [TestCase(0, 6, "Not Aged Brie", 4)]
        [TestCase(0, 8, "Aged Brie", 10)]
        public void Once_The_Sell_By_Date_Has_Passed_Quality_Degrades_Twice_As_Fast(int sellIn, int quality, string name, int answer)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].Quality);
        }

        [Test]
        [TestCase(0, 0, "Not Aged Brie", 0)]
        [TestCase(0, 0, "Aged Brie", 2)]
        public void The_Quality_Of_An_item_Is_Never_Negative(int sellIn, int quality, string name, int answer)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].Quality);
        }

        [Test]
        [TestCase(10, 0, "Aged Brie", 1)]
        [TestCase(10, 10, "Aged Brie", 11)]
        [TestCase(10, 0, "Not Aged Brie", 0)]
        [TestCase(10, 10, "Not Aged Brie", 9)]
        public void Aged_Brie_Actually_Increases_In_Quality_The_Older_It_Gets(int sellIn, int quality, string name, int answer)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].Quality);
        }

        [Test]
        public void Aged_Brie_Actually_Increases_In_Quality_The_Older_It_Gets_SellIn_At_Zero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
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
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].Quality);
        }

        [Test]
        [TestCase(10, 10, "Backstage passes to a TAFKAL80ETC concert", 12)]
        [TestCase(5, 10, "Backstage passes to a TAFKAL80ETC concert", 13)]
        [TestCase(0, 10, "Backstage passes to a TAFKAL80ETC concert", 0)]

        public void Increases_In_Quality_As_Its_SellIn_Value_Approaches(int sellIn, int quality, string name, int answer) 
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(answer, Items[0].Quality);
        } 

        [Test]
        public void Conjured_Items_Degrade_In_Quality_Twice_As_Fast_As_Normal_Items()
        {

        }
    }

}
