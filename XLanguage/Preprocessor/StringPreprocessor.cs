using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XLanguage.Interfaces;

namespace XLanguage.Preprocessor
{
    public class StringPreprocessor : ITextPreprocessor
    {
        private SortedDictionary<float,ExpressionComponent> components;

        public StringPreprocessor()
        {
            Components = new SortedDictionary<float,ExpressionComponent>();
        }

        public SortedDictionary<float,ExpressionComponent> Components { get => components; set => components = value; }
        public string Process(string rawText)
        {
            string result = ""; //"w 1 \"Hello\" ( )"
            int anchor = -1;
            for (int i = 0; i < rawText.Length; i++)
            {
                if (rawText[i] == '"')
                {
                    if (i > 0 && rawText[i - 1] == '\\')
                    {
                        result += Preprocessor.TagCat.STRING;
                        continue;
                    }
                    if (anchor == -1)
                    {
                        anchor = i;
                    }
                    else
                    {
                        components.Add(anchor, new Operands.StringOperand(rawText.Substring(anchor + 1, i - anchor - 1), i - anchor - 1, anchor));
                        anchor = -1;
                    }
                    result += Preprocessor.TagCat.STRING;
                }
                else
                {
                    if (anchor != -1)
                    {
                        result += Preprocessor.TagCat.STRING;
                    }
                    else
                    {
                        result += Preprocessor.TagCat.NTH;
                    }
                }
            }
            return result;
        }

        public string Process(string beforeResult, string rawText)
        {
            return Process(rawText);
        }
    }
}
