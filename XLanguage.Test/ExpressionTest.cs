using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XLanguage.Test
{
    [TestClass]
    public class ExpressionTest
    {
        [TestInitialize]
        public void Setup()
        {

        }
        [TestMethod]
        public void GenerateExpressionMap()
        {
            string nth = XLanguage.Preprocessor.TagCat.NTH;
            string num = XLanguage.Preprocessor.TagCat.NUM;
            string str = XLanguage.Preprocessor.TagCat.STRING;
            XLanguage.Expression expression = new Expression("a bc 2-3 \"2+3\" and");

            Assert.AreEqual(nth + nth + nth + nth + nth + num + num + num + nth + str + str + str + str + str + nth + nth + nth + nth, expression.Map);
        }
        [TestMethod]
        public void ExtractExpressionComponents()
        {
            Expression expression = new Expression("2+3 - 5  \"Hello\" +7 /2");
            SortedDictionary<float, ExpressionComponent> sample = new SortedDictionary<float, ExpressionComponent>();
            sample.Add(0, new Operands.NumberOperand(2));
            sample.Add(2, new Operands.NumberOperand(3));
            sample.Add(6, new Operands.NumberOperand(-5));
            sample.Add(9, new Operands.StringOperand("Hello"));
            sample.Add(18, new Operands.NumberOperand(7));
            sample.Add(21, new Operands.NumberOperand(2));

            foreach(float key in expression.Components.Keys)
            {
                Assert.IsNotNull(sample[key]);
                
            }
        }
    }
}
