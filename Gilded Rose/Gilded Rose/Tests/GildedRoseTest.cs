using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
	[TestFixture()]
	public class GildedRoseTest
    { 
        [Test]
        public void DefaultItemDecreasesQualityByOne()
        {
            // Arrange
            var items = new List<Item> {
                new Item { Name = "Default Item", SellIn = 10, Quality = 10 },
            };
            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Default Item", items[0].Name);
            Assert.AreEqual(9, items[0].SellIn);
            Assert.AreEqual(9, items[0].Quality);
        }

        [Test]
        public void ExpiredDefaultItemDecreasesQualityByTwo()
        {
            // Arrange
            var items = new List<Item> {
                new Item { Name = "Expired Default Item", SellIn = -10, Quality = 10 }
            };
            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Expired Default Item", items[0].Name);
            Assert.AreEqual(-11, items[0].SellIn);
            Assert.AreEqual(8, items[0].Quality);
        }

        [Test]
        public void AgedBrieIncreasesQualityByOne()
        {
            // Arrange
            var items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 },
            };
            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(9, items[0].SellIn);
            Assert.AreEqual(11, items[0].Quality);
        }

        [Test]
        public void ExpiredAgedBrieIncreasesQualityByTwo()
        {
            // Arrange
            var items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = -10, Quality = 10 },
            };
            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(-11, items[0].SellIn);
            Assert.AreEqual(12, items[0].Quality);
        }

        [Test]
        public void SulfurasDoesNotChangeQualityOrSaleTime()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }
            };
            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", items[0].Name);
            Assert.AreEqual(80, items[0].Quality);
            Assert.AreEqual(10, items[0].SellIn);
        }

        [Test]
        public void BackstagePassChangesForEachCase()
        {
            // Backstage passes to a TAFKAL80ETC concert
            // Increase quality by 2 if sellin is less than or equal to 10
            // Increase quality by 3 if sellin is less than or equal to 5
            // If sellin is 0 or negative, then quality is 0

            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.AreEqual(14, items[0].SellIn);
            Assert.AreEqual(11, items[0].Quality);
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[1].Name);
            Assert.AreEqual(9, items[1].SellIn);
            Assert.AreEqual(12, items[1].Quality);
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[2].Name);
            Assert.AreEqual(4, items[2].SellIn);
            Assert.AreEqual(13, items[2].Quality);
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", items[2].Name);
            Assert.AreEqual(-1, items[3].SellIn);
            Assert.AreEqual(0, items[3].Quality);
        }

        [Test]
        public void ConjuredDefaultItemDecreasesQualityByTwo()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Conjured Default Item", SellIn = 10, Quality = 10 },
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Conjured Default Item", items[0].Name);
            Assert.AreEqual(9, items[0].SellIn);
            Assert.AreEqual(8, items[0].Quality);
        }

        [Test]
        public void ConjuredExpiredDefaultItemDecreasesQualityByFour()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Conjured Expired Default Item", SellIn = -10, Quality = 10 },
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Conjured Expired Default Item", items[0].Name);
            Assert.AreEqual(-11, items[0].SellIn);
            Assert.AreEqual(6, items[0].Quality);
        }

        [Test]
        public void ConjuredAgedBrieIncreasesQualityByTwo()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Conjured Aged Brie", SellIn = 10, Quality = 10 },
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Conjured Aged Brie", items[0].Name);
            Assert.AreEqual(9, items[0].SellIn);
            Assert.AreEqual(12, items[0].Quality);
        }

        [Test]
        public void ConjuredExpiredAgedBrieIncreasesQualityByFour()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Conjured Aged Brie", SellIn = -10, Quality = 10 },
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Conjured Aged Brie", items[0].Name);
            Assert.AreEqual(-11, items[0].SellIn);
            Assert.AreEqual(14, items[0].Quality);
        }

        [Test]
        public void ConjuredSulfurasDoesNotChangeQualityOrSaleTime()
        {
            // Nothing should change here

            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Conjured Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 },
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Conjured Sulfuras, Hand of Ragnaros", items[0].Name);
            Assert.AreEqual(10, items[0].SellIn);
            Assert.AreEqual(80, items[0].Quality);
        }

        [Test]
        public void ConjuredBackstagePassChangesForEachCase()
        {
            // Conjured Backstage passes to a TAFKAL80ETC concert
            // Increase quality by 2 if sellin is less than or equal to 10
            // Increase quality by 3 if sellin is less than or equal to 5
            // If sellin is 0 or negative, then quality is 0

            // Arrange
            var items = new List<Item>
            {
                new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 },
                new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            Assert.AreEqual("Conjured Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.AreEqual(14, items[0].SellIn);
            Assert.AreEqual(12, items[0].Quality);
            Assert.AreEqual("Conjured Backstage passes to a TAFKAL80ETC concert", items[1].Name);
            Assert.AreEqual(9, items[1].SellIn);
            Assert.AreEqual(14, items[1].Quality);
            Assert.AreEqual("Conjured Backstage passes to a TAFKAL80ETC concert", items[2].Name);
            Assert.AreEqual(4, items[2].SellIn);
            Assert.AreEqual(16, items[2].Quality);
            Assert.AreEqual("Conjured Backstage passes to a TAFKAL80ETC concert", items[3].Name);
            Assert.AreEqual(-1, items[3].SellIn);
            Assert.AreEqual(0, items[3].Quality);
        }

        [Test]
        public void QualityRestrictionUpperAndLowerSatisfied()
        {
            // All items (except Sulfuras) should never increase beyond 50 quality, or 0 quality

            // Arrange
            var items = new List<Item> {
                new Item { Name = "Default Item", SellIn = 10, Quality = 0 },
                new Item { Name = "Expired Default Item", SellIn = -10, Quality = 0 },
                new Item { Name = "Conjured Default Item", SellIn = 10, Quality = 0 },
                new Item { Name = "Conjured Expired Default Item", SellIn = -10, Quality = 0 },
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = -10, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 },
                new Item { Name = "Conjured Aged Brie", SellIn = 10, Quality = 50 },
                new Item { Name = "Conjured Aged Brie", SellIn = -10, Quality = 50 },
                new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 },
                new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 },
                new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 },
            };

            var tester = new GildedRose(items);

            // Act
            tester.UpdateQuality();

            // Assert
            for (int i = 0; i < 4; ++i)
            {
                Assert.AreEqual(0, items[i].Quality);
            }
            for (int i = 4; i < 14; ++i)
            {
                Assert.AreEqual(50, items[i].Quality);
            }
        }
    }
}

