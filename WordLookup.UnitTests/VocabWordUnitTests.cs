using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordLookup.UnitTests
{
    [TestClass]
    public class VocabWordTests
    {
        [TestMethod]
        public void ReturnsWordProperty()
        {
            WordLookup.VocabWord TestWord = new VocabWord("TestName");

            Assert.AreEqual("TestName", TestWord.Word);
        }

        [TestMethod]
        public void ReturnsDefaultDefinition()
        {
            var TestWord = new VocabWord("TestName");

            Assert.AreEqual("Not Defined", TestWord.Definition);
        }

        [TestMethod]
        public void DefaultDefinitionListHasZeroCount()
        {
            var TestWord = new VocabWord("TestName");

            Assert.IsNotNull(TestWord.Definitions);
            Assert.IsTrue(TestWord.Definitions.Count == 0);
        }

        [TestMethod]
        public void ReturnsDefinitionFromIndexZeroIfNotChanged()
        {
            var TestWord = new VocabWord("TestName");

            TestWord.Definitions.Add("Test Definition");
            TestWord.Definitions.Add("Test Definition 2");

            Assert.AreEqual(TestWord.Definition, "Test Definition");
        }
    }
}
