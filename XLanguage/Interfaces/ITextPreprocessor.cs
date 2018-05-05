using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLanguage.Interfaces
{
    public interface ITextPreprocessor
    {
        string Process(string rawText);
    }
}
