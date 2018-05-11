using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using XLanguage.Interfaces;

namespace XLanguage.Preprocessor
{
    public class NumberPreprocessor : ITextPreprocessor
    {
        private SortedDictionary<float,ExpressionComponent> components;

        public NumberPreprocessor()
        {
            components = new SortedDictionary<float,ExpressionComponent>();
        }

        public SortedDictionary<float,ExpressionComponent> Components { get => components; set => components = value; }

        public string Process(string rawText)
        {
            string result = "";
            for(int i = 0; i < rawText.Length; i++)
            {
                result += TagCat.NTH;
            }
            return Process(result, rawText);
        }

        public string Process(string beforeResult, string rawText)
        {
            string result = "";
            List<string> resultList = new List<string>();
            for(int i = 0; i < beforeResult.Length; i++)
            {
                resultList.Add(beforeResult[i].ToString());
            }
            MatchCollection collection = Regex.Matches(rawText, "[-]?\\d+(?:\\.\\d+)*");
            foreach(Match match in collection)
            {
                if (resultList[match.Index] != TagCat.STRING)
                {
                    components.Add(match.Index, new Operands.NumberOperand(match.Value));
                }
                for (int i = match.Index; i < match.Length + match.Index; i++)
                {
                    if (resultList[i] != TagCat.STRING)
                    {
                        resultList[i] = TagCat.NUM;
                    }
                }
            }
            for(int i = 0; i < resultList.Count; i++)
            {
                result += resultList[i];
            }
            return result;
        }
    }
}
