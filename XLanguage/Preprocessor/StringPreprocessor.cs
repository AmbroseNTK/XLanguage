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
        public string Process(string rawText)
        {
            string result = ""; //"w 1 \"Hello\" ( )"
            int anchor = -1;
            for (int i = 0; i < rawText.Length; i++)
            {
                if (rawText[i] == '"')
                {
                    if (anchor == -1)
                    {
                        anchor = i;
                    }
                    else
                    {
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
    }
}
