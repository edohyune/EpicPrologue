using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class Person : MdlBase
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

    }
}
