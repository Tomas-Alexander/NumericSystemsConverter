using System;
using System.Collections.Generic;
using System.Text;

namespace NSConverter.DataManager
{
    public enum NumericSystem
    {
        Binary = 2,
        Octal = 8,
        Decimal = 10,
        Hexadecimal = 16
    }

    public class DataStruct
    {
        public NumericSystem From { get; set; }
        public NumericSystem To { get; set; }
        public string Value { get; set; }
        public string Result { get; set; }
    }
}
