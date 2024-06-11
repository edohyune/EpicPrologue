using ER000.Lib;

namespace ER000.Interface
{
    public interface IGridSet : IWorkSet
    {
        /// <summary>
        /// 컬럼을 초기화합니다.
        /// </summary>
        public void InitializeColumns();

        /// <summary>
        /// 컬럼에 바인딩 합니다. 
        /// </summary>
        public void BindData();
    }
}
