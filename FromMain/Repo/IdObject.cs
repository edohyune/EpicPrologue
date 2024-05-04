using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class IdObject
    {
        public string Txt { get; set; }
        public object Val { get; set; }

        public override string ToString()
        {
            return Txt;
        }
    }
}
