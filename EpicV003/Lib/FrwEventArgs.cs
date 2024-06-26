using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicV003.Lib
{
    public class DataChangedEventArgs : EventArgs
    {
        public string fldNm { get; }
        public dynamic newVal { get; }
        public DataChangedEventArgs(string fieldName, dynamic newValue)
        {
            fldNm = fieldName;
            newVal = newValue;
        }
    }
}
