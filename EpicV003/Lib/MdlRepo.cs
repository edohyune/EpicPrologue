using DevExpress.Utils.MVVM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EpicV003.Lib
{
    public class MdlRepo
    {
        public virtual List<T> Open<T>()
        {
            return new List<T>();
        }

        public virtual void Save<T>(List<T> dataList)
        {
            Common.gLog = "저장 완료";
        }
    }
}
