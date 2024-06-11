using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ER000.Lib;

namespace ER000.Interface
{
    public interface IWorkSet
    {
        /// <summary>
        /// 워크셋 데이터를 조회합니다.
        /// </summary>
        void Open();

        /// <summary>
        /// 워크셋 데이터를 저장합니다.
        /// </summary>
        void Save();

        /// <summary>
        /// 워크셋 데이터를 삭제합니다.
        /// </summary>
        void Delete();

        /// <summary>
        /// 워크셋 데이터를 삭제합니다.
        /// </summary>
        void New();
    }
}
