using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frms.Models.GridSet
{
    public class TESTG10 : Lib.MdlBase
    {
        private int _ID;
        public int ID
        {
            get => _ID;
            set => Set(ref _ID, value);
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private int _Age;
        public int Age
        {
            get => _Age;
            set => Set(ref _Age, value);
        }

        private int _PID;
        public int PID
        {
            get => _PID;
            set => Set(ref _PID, value);
        }
    }

    public class G20
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PID { get; set; }
    }
}
