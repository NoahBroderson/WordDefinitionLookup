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
        public void VocabWord_DefaultDefinitionListHasCountOfOne()
        {
            //Arrange
            string constructorWord = "TestName";

            //Act
            var TestWord = new VocabWord(constructorWord);

            //Assert
            Assert.IsNotNull(TestWord.Definitions);
            Assert.IsTrue(TestWord.Definitions.Count == 1);
        }

        [TestMethod]
        public void VocabWord_ReturnsDefinitionFromIndexZeroIfNotChanged()
        {
            //Arrange
            var TestWord = new VocabWord("TestName");
            TestDictionary Dictionary = new TestDictionary();

            //Act
            TestWord.Definitions = Dictionary.GetDefinitions(TestWord.Word);
        
            //Assert
            Assert.AreEqual("Definition1",TestWord.Definition);
        }

        [TestMethod]
        public void CountOfDefinitionListIsTwoAfterAddingTwoItems()
        {
            //Arrange
            var TestWord = new VocabWord("TestName");
            var Dictionary = new TestDictionary();
            
            //Act
            TestWord.Definitions = Dictionary.GetDefinitions(TestWord.Word);

            //Assert
            Assert.AreEqual(2, TestWord.Definitions.Count);
        }

        [TestMethod]
        public void CountOfDefinitionListIsOneAfterAddingTwoItemsAndDeletingOne()
        {
            var TestWord = new VocabWord("TestName");

            TestWord.Definitions.Add("Test Definition");
            TestWord.Definitions.Add("Test Definition 2");
            TestWord.Definitions.Remove("Test Definition");

            Assert.AreEqual(1, TestWord.Definitions.Count);
        }
    }
}
