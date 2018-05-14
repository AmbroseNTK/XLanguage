using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLanguage.Operands
{
    /// <summary>
    /// String type
    /// </summary>
    public class StringOperand : ExpressionComponent
    {
        /// <summary>
        /// Create string
        /// </summary>
        public StringOperand() : this("") { }
        /// <summary>
        /// Create a string with value
        /// </summary>
        /// <param name="value">New string</param>
        public StringOperand(string value) : this(value, 0) { }
        /// <summary>
        /// Create a string
        /// </summary>
        /// <param name="value">New value</param>
        /// <param name="rawLength">Its length be in the map</param>
        public StringOperand(string value, int rawLength) : this(value,rawLength,0) { }
        /// <summary>
        /// Create a string
        /// </summary>
        /// <param name="value">New value</param>
        /// <param name="rawLength">Its length be in the map</param>
        /// <param name="index">Start position of this string in the map</param>
        public StringOperand(string value, int rawLength, int index)
        {
            this.value = value;
            this.StartIndex = index;
            this.RawLength = rawLength;
        }
        /// <summary>
        /// Return itself
        /// </summary>
        /// <returns>This string</returns>
        public override ExpressionComponent Process()
        {
            return this;
        }
    }
}
