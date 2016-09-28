using WordLookup;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordLookup.Tests
{
    [TestClass()]
    public class VocabWordUnitTests
    {
        [TestMethod()]
        public void VocabWord_ConstructorSetsWordProperty()
        {
            //Arrange
            string constructorWord = "test";
            
            //Action
            VocabWord testWord = new VocabWord(constructorWord);
            string outputWord = testWord.Word;

            //Assert
            Assert.AreEqual(constructorWord,outputWord);
        }

        [TestMethod()]
        public void WordTest1()
        {
            Assert.Fail();
        }
    }
}

namespace WordLookup.UnitTests
{
    [TestClass]
    public class VocabWordTests
    {
        
        [TestMethod]
        public void VocabWord_DefaultDefinitionReturned()
        {
            //Arrange
            string constructorWord = "TestName";
            string output = "Not Defined";
            //Act
            var TestWord = new VocabWord(constructorWord);

            //Assert
            Assert.AreEqual(output, TestWord.Definition);
        }

        [TestMethod]
        public void VocabWord_DefaultDefinitionListHasZeroCount()
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
