using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseStudents
{
        public class Data
        {
            public Data(int intValue, string strValue)
            {
                IntegerData = intValue;
                StringData = strValue;
            IntegerData2 = 0;
            }
        public Data(int intValue1, int intValue2, string strValue)
        {
            IntegerData = intValue1;
            StringData = strValue;
            IntegerData2 = intValue2;
        }

        public int IntegerData { get; private set; }
        public int IntegerData2 { get; set; }
        public string StringData { get; private set; }
        public void SetInt2(int s)
        {
            IntegerData2 = s;
        }
        }
}
