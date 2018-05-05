using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using XLanguage;

namespace XLanguage.Test
{
 
    [TestClass]
    public class PreprocessorTest
    {
        XLanguage.Preprocessor.StringPreprocessor stringPreprocessor;
        [TestInitialize]
        public void Setup()
        {
            stringPreprocessor = new Preprocessor.StringPreprocessor();
        }

        [TestMethod]
        public void GetStringFromCode()
        {
            string nth = Preprocessor.TagCat.NTH;
            string str = Preprocessor.TagCat.STRING;

            Assert.AreEqual(nth + nth + nth + nth + str + str + str + str + str + str + str + nth + nth + nth + nth,
                stringPreprocessor.Process("w 1 \"Hello\" ( )"));
            
        }
    }
}
