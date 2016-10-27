using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLookup.Tests
{
    [TestClass()]
    public class PearsonDictionaryTests
    {
        [TestMethod()]
        public void PearsonDictionary_LookupCar()
        {
            //Arrange
            var testWord = new VocabWord("car");
            var Dictionary = new PearsonDictionary();

            //Act
            testWord = Dictionary.Lookup(testWord);

            //Assert
            Assert.AreEqual("test", testWord.Definition);
        }
    }
}