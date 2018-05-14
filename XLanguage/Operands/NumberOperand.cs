using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLanguage.Operands
{
    /// <summary>
    /// Number type
    /// </summary>
    public class NumberOperand : ExpressionComponent
    {
        /// <summary>
        /// Create new number operand
        /// </summary>
        public NumberOperand() : this(0d) { }
        /// <summary>
        /// Create new number from a number
        /// </summary>
        /// <param name="num">New value</param>
        public NumberOperand(double num)
        {
            this.value = num;
        }
        /// <summary>
        /// Create new number from a text number
        /// </summary>
        /// <param name="textNum">New number in text type</param>
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
        /// <summary>
        /// Return itself
        /// </summary>
        /// <returns></returns>
        public override ExpressionComponent Process()
        {
            return this;
        }
    }
}
