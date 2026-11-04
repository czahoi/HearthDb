using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HearthDb.CardDefs;
using HearthDb.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HearthDb.Tests
{
    [TestClass]
    public class CardDefsLoadTest
    {
        [TestInitialize]
        public void Init()
        {
            Cards.LoadBaseData(new CardDefs.CardDefs { Entites = new List<Entity>() });
        }

        [TestCleanup]
        public void Cleanup()
        {
            Cards.LoadBaseData();
        }

        [TestMethod]
        public void LoadCards_CorrectlyAssemblesData()
        {
            using var fsBase = File.OpenRead("Data/TestCardDefs.base.xml");
            Cards.LoadBaseData(fsBase);

            Assert.AreEqual("Nutthapon Petchthai", Cards.All["AT_001"].ArtistName);
            Assert.AreEqual("Flame Lance", Cards.All["AT_001"].GetLocName(Locale.enUS));
            Assert.AreEqual(null, Cards.All["AT_001"].GetLocName(Locale.deDE));

            using var fsLocDe = File.OpenRead("Data/TestCardDefs.deDE.xml");
            Cards.LoadLocaleData(fsLocDe, Locale.deDE);

            Assert.AreEqual("Nutthapon Petchthai", Cards.All["AT_001"].ArtistName);
            Assert.AreEqual("Flame Lance", Cards.All["AT_001"].GetLocName(Locale.enUS));
            Assert.AreEqual("Flammenlanze", Cards.All["AT_001"].GetLocName(Locale.deDE));
        }

        [TestMethod]
        public void ParseCardDefs_SharesTagStringsAcrossEntities()
        {
            var cardDefs = Cards.GetBundledBaseData();

            var healthTags = cardDefs.Entites
                .Select(e => e.Tags.FirstOrDefault(t => t.EnumId == (int)GameTag.HEALTH))
                .Where(t => t != null)
                .Take(2)
                .ToList();

            Assert.AreEqual(2, healthTags.Count);
            Assert.AreNotSame(healthTags[0], healthTags[1]);
            Assert.AreSame(healthTags[0].Name, healthTags[1].Name);
            Assert.AreSame(healthTags[0].TypeString, healthTags[1].TypeString);
        }

        [TestMethod]
        public void HasValidETagData()
        {
            var bundled = Cards.GetBundledCardDefsETag();
            Assert.IsNotNull(bundled.ETag);
            Assert.IsTrue(DateTime.TryParse(bundled.LastModified, out _));
        }
    }
}