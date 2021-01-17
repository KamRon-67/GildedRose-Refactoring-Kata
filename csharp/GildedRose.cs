using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public IList<Item> _Items;

        public GildedRose()
        {
            _Items = populateList();
        }

        public GildedRose(IList<Item> Items)
        {
            _Items = populateList();

            if(Items.Count != 0)
            foreach (var x in Items)
            {
                _Items.Add(x);
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _Items.Count; i++)
            {
                if (_Items[i].Name != "Aged Brie" && _Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (_Items[i].Quality > 0)
                    {
                        if (_Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            _Items[i].Quality = _Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (_Items[i].Quality < 50)
                    {
                        _Items[i].Quality = _Items[i].Quality + 1;

                        if (_Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_Items[i].SellIn < 11)
                            {
                                if (_Items[i].Quality < 50)
                                {
                                    _Items[i].Quality = _Items[i].Quality + 1;
                                }
                            }

                            if (_Items[i].SellIn < 6)
                            {
                                if (_Items[i].Quality < 50)
                                {
                                    _Items[i].Quality = _Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (_Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    _Items[i].SellIn = _Items[i].SellIn - 1;
                }

                if (_Items[i].SellIn < 0)
                {
                    if (_Items[i].Name != "Aged Brie")
                    {
                        if (_Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_Items[i].Quality > 0)
                            {
                                if (_Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    _Items[i].Quality = _Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _Items[i].Quality = _Items[i].Quality - _Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (_Items[i].Quality < 50)
                        {
                            _Items[i].Quality = _Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        public IList<Item> populateList()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            return Items;
        }
    }
}
