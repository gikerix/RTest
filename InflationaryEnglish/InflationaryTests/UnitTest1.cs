using Microsoft.VisualStudio.TestTools.UnitTesting;
using InflationaryEnglishCore;
using System.Collections.Generic;

namespace InflationaryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOne()
        {
            PhraseConverter converter = new PhraseConverter();            
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("ten", "eleven");
            dict.Add("nine", "ten");
            dict.Add("eight", "nine");
            dict.Add("seven", "eight");
            dict.Add("six", "seven");
            dict.Add("five", "six");
            dict.Add("four", "five");
            dict.Add("three", "four");
            dict.Add("two", "three");
            dict.Add("one", "two");
            dict.Add("once", "twice");
            foreach (var item in dict)
                Assert.AreEqual(converter.Convert(item.Key), item.Value);
        }
    }
}
