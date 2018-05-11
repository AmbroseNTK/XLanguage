using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLanguage.Operands
{
    public class StringOperand : ExpressionComponent
    {
        public StringOperand() : this("") { }
        public StringOperand(string value) : this(value, 0) { }
        public StringOperand(string value, int rawLength) : this(value,rawLength,0) { }
        public StringOperand(string value, int rawLength, int index)
        {
            this.value = value;
            this.StartIndex = index;
            this.RawLength = rawLength;
        }
        public override ExpressionComponent Process()
        {
            return this;
        }
    }
}
