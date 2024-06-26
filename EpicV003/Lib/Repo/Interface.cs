using DevExpress.Data.ChartDataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicV003.Lib.Repo
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

        /// <summary>
        /// 워크셋의 식별자입니다.
        /// </summary>
        string frwId { get; set; }
        string frmId { get; set; }
        string wrkId { get; set; }

        event EventHandler<DataChangedEventArgs> DataChanged;
        void OnDataChanged(DataChangedEventArgs e);
    }
}
