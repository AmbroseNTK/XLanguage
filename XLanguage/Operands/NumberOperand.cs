using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLanguage.Operands
{
    public class NumberOperand : ExpressionComponent
    {
        public NumberOperand() : this(0d) { }
        public NumberOperand(double num)
        {
            this.value = num;
        }
        public NumberOperand(string textNum)
        {
            double num = 0d;
            if (double.TryParse(textNum, out num))
            {
                this.value = num;
            }
            else
            {
                //Error
            }
        }
        public override ExpressionComponent Process()
        {
            return this;
        }
    }
}
