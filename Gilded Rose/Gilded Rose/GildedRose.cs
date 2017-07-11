using System.Collections.Generic;
using System.Data.Odbc;

namespace GildedRose
{
    public class ItemData
    {
        public enum ItemCase
        {
            Default,
            AgedBrie,
            Sulfuras,
            BackstagePasses,
        }

        public enum ItemModifier
        {
            Default = 1,
            DoubleChange = 2,
            QuadrupleChange = 4
        }

        public ItemCase Case { get; set; }
        public ItemModifier Modifier { get; set; }

        public static ItemData ParseItem(Item item)
        {
            bool itemIsConjured;
            bool itemIsExpired;

            ItemCase itemCase;
            ItemModifier itemModifier;

            string unmodifiedName;

            if (item.Name.Substring(0, 8) == "Conjured")
            {
                itemIsConjured = true;
                unmodifiedName = item.Name.Substring(9);
            }
            else
            {
                itemIsConjured = false;
                unmodifiedName = item.Name;
            }

            if (item.SellIn < 0)
            {
                itemIsExpired = true;
            }
            else
            {
                itemIsExpired = false;
            }

            if (itemIsConjured)
            {
                if (itemIsExpired)
                {
                    itemModifier = ItemModifier.QuadrupleChange;
                }
                else
                {
                    itemModifier = ItemModifier.DoubleChange;
                    ;
                }
            }
            else
            {
                if (itemIsExpired)
                {
                    itemModifier = ItemModifier.DoubleChange;
                }
                else
                {
                    itemModifier = ItemModifier.Default;
                }
            }

            if (unmodifiedName == "Aged Brie")
            {
                itemCase = ItemCase.AgedBrie;
            }
            else if (unmodifiedName == "Sulfuras, Hand of Ragnaros")
            {
                itemCase = ItemCase.Sulfuras;
            }
            else if (unmodifiedName == "Backstage passes to a TAFKAL80ETC concert")
            {
                itemCase = ItemCase.BackstagePasses;
            }
            else
            {
                itemCase = ItemCase.Default; ;
            }

            return new ItemData
            {
                Case = itemCase,
                Modifier = itemModifier
            };
        }
    }

	class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items) 
		{
			this.Items = Items;
		}

		public void UpdateQuality()
		{
			for (var i = 0; i < Items.Count; i++)
			{
			    var itemData = ItemData.ParseItem(Items[i]);

			    switch (itemData.Case)
			    {
			        case ItemData.ItemCase.AgedBrie:
			            Items[i].Quality += (int)itemData.Modifier;
			            --Items[i].SellIn;
                        break;
                    case ItemData.ItemCase.Sulfuras:
                        break;
                    case ItemData.ItemCase.BackstagePasses:
                        if (Items[i].SellIn > 10)
                        {
                            Items[i].Quality += (int)itemData.Modifier;
                        }
                        else if (Items[i].SellIn > 5)
                        {
                            Items[i].Quality += 2 * (int)itemData.Modifier;
                        }
                        else if (Items[i].SellIn > 0)
                        {
                            Items[i].Quality += 3 * (int)itemData.Modifier;
                        }
                        else
                        {
                            Items[i].Quality = 0;
                        }
                        --Items[i].SellIn;
                        break;
                    default:
                        Items[i].Quality -= (int) itemData.Modifier;
                        --Items[i].SellIn;
                        break;
                }

			    if (itemData.Case != ItemData.ItemCase.Sulfuras)
			    {
			        if (Items[i].Quality < 0)
			        {
			            Items[i].Quality = 0;
                    }
                    else if (Items[i].Quality > 50)
			        {
			            Items[i].Quality = 50;
			        }
                }
           
     
                /*
			    bool isConjured;
			    string unmodifiedName;
			    if (Items[i].Name.Substring(0, 8) == "Conjured")
			    {
			        isConjured = true;
			        unmodifiedName = Items[i].Name.Substring(9);
			    }
			    else
			    {
			        isConjured = false;
			        unmodifiedName = Items[i].Name;
			    }

			    var changeModifier = isConjured ? 2 : 1;

                if (unmodifiedName != "Aged Brie" && unmodifiedName != "Backstage passes to a TAFKAL80ETC concert")
			    {
			        if (Items[i].Quality > 0)
			        {
			            if (unmodifiedName != "Sulfuras, Hand of Ragnaros")
			            {
			                Items[i].Quality = Items[i].Quality - changeModifier;
			            }
			        }
			    }
			    else
			    {
			        if (Items[i].Quality < 50)
			        {
			            Items[i].Quality = Items[i].Quality + changeModifier;

			            if (unmodifiedName == "Backstage passes to a TAFKAL80ETC concert")
			            {
			                if (Items[i].SellIn < 11)
			                {
			                    if (Items[i].Quality < 50)
			                    {
			                        Items[i].Quality = Items[i].Quality + changeModifier;
			                    }
			                }

			                if (Items[i].SellIn < 6)
			                {
			                    if (Items[i].Quality < 50)
			                    {
			                        Items[i].Quality = Items[i].Quality + changeModifier;
			                    }
			                }
			            }
			        }
			    }

			    if (unmodifiedName != "Sulfuras, Hand of Ragnaros")
			    {
			        Items[i].SellIn = Items[i].SellIn - 1;
			    }

			    if (Items[i].SellIn < 0)
			    {
			        if (unmodifiedName != "Aged Brie")
			        {
			            if (unmodifiedName != "Backstage passes to a TAFKAL80ETC concert")
			            {
			                if (Items[i].Quality > 0)
			                {
			                    if (unmodifiedName != "Sulfuras, Hand of Ragnaros")
			                    {
			                        Items[i].Quality = Items[i].Quality - changeModifier;
			                    }
			                }
			            }
			            else
			            {
			                Items[i].Quality = Items[i].Quality - Items[i].Quality;
			            }
			        }
			        else
			        {
			            if (Items[i].Quality < 50)
			            {
			                Items[i].Quality = Items[i].Quality + changeModifier;
			            }
			        }
			    }
                */
            }
		}
	}
	
	public class Item
	{
		public string Name { get; set; }
		
		public int SellIn { get; set; }
		
		public int Quality { get; set; }
	}
	
}
