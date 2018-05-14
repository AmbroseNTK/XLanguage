using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLanguage
{
    /// <summary>
    /// Expression
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// Raw text of expression
        /// </summary>
        private string raw;
        /// <summary>
        /// A map of expression component
        /// </summary>
        private string map;
        /// <summary>
        /// Expression components list
        /// </summary>
        private SortedDictionary<float, ExpressionComponent> components;

        public Expression()
        {
            Raw = "";
           
        }
        public Expression(string raw)
        {
            Raw = raw;
            
        }

        public string Raw {
            get => raw;
            set
            {
                raw = value;
                this.Preprocessing();
            }
        }
        public string Map { get => map; }
        public SortedDictionary<float, ExpressionComponent> Components { get => components; }

        /// <summary>
        /// Preprocessing raw text to expression components
        /// </summary>
        public void Preprocessing()
        {
            Preprocessor.StringPreprocessor stringPreprocessor = new Preprocessor.StringPreprocessor();
            Preprocessor.NumberPreprocessor numberPreprocessor = new Preprocessor.NumberPreprocessor();
            string processString = stringPreprocessor.Process(raw);
            numberPreprocessor.Components = stringPreprocessor.Components;
            map = numberPreprocessor.Process(processString, raw);
            components = numberPreprocessor.Components;
        }

    }
}
