using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLanguage
{
    public abstract class ExpressionComponent
    {
        protected object value;
        private int rawLength;
        private int startIndex;

        public int RawLength { get => rawLength; set => rawLength = value; }
        public int StartIndex { get => startIndex; set => startIndex = value; }

        public abstract ExpressionComponent Process();
        public object GetValue() => value;
    }
}
