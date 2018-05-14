using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using XLanguage;

namespace XLanguage.Test
{
 
    [TestFixture]
    public class PreprocessorTest
    {
        XLanguage.Preprocessor.StringPreprocessor stringPreprocessor;
        XLanguage.Preprocessor.NumberPreprocessor numberPreprocessor;
        

        [SetUp]
        public void Setup()
        {
            stringPreprocessor = new Preprocessor.StringPreprocessor();
            numberPreprocessor = new Preprocessor.NumberPreprocessor();
        }

        [TestCase]
        public void GetStringFromCode()
        {
            string nth = Preprocessor.TagCat.NTH;
            string str = Preprocessor.TagCat.STRING;

            Assert.AreEqual(nth + nth + nth + nth + str + str + str + str + str + str + str + str + str + nth + nth + nth + nth,
                stringPreprocessor.Process("w 1 \"Hel\\\"lo\" ( )"));
            
        }

        [TestCase]
        public void GetNumberFromCode()
        {
            string nth = Preprocessor.TagCat.NTH;
            string num = Preprocessor.TagCat.NUM;
            Assert.AreEqual(nth + nth + nth + nth + nth + nth + num + num + num + num + num + nth + num,
                numberPreprocessor.Process("a b c 5-3.5+2"));
        }
        [TestCase]
        public void DoNotGetNumberInString()
        {
            string nth = Preprocessor.TagCat.NTH;
            string num = Preprocessor.TagCat.NUM;
            string str = Preprocessor.TagCat.STRING;

            Assert.AreEqual(nth + nth + str + str + str + str + str + nth + num + nth + num + num + num + num,
                numberPreprocessor.Process(nth + nth + str + str + str + str + str + nth + nth + nth + nth + nth + nth + nth, "a \"2+3\" 4+3.14"));

        }
        [TestCase]
        public void GetStringComponent()
        {
            stringPreprocessor = new Preprocessor.StringPreprocessor();
            stringPreprocessor.Process("a \"bc\" \"Hello\" ");
            Assert.IsTrue(stringPreprocessor.Components.Count == 2);
            Assert.AreEqual("bc", stringPreprocessor.Components[2].GetValue().ToString());
            Assert.AreEqual(2, stringPreprocessor.Components[2].RawLength);
        }
    }
}
