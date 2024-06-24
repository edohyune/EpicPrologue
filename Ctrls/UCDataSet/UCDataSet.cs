using Dapper;
using Lib;
using System.Data;

namespace Ctrls
{
    public class UCDataSet : Lib.Repo.IWorkSet
    {
        public string frwId { get; set; }
        public string frmId { get; set; }
        public string wrkId { get; set; }
        private DynamicParameters DSearchParam;
        private object OSearchParam;

        public event EventHandler<DataChangedEventArgs> DataChanged;

        public UCDataSet(string _frwId, string _frmId, string _wrkId)
        {
            frwId = _frwId;
            frmId = _frmId;
            wrkId = _wrkId;
        }

        public DataSet OpenDataSet(DynamicParameters param)
        {
            DSearchParam = param;
            return ExecuteQuery();
        }

        public List<T> OpenList<T>(DynamicParameters param)
        {
            DSearchParam = param;
            return ExecuteQuery<T>();
        }

        private DataSet ExecuteQuery()
        {
            DataSet dataSet = new DataSet();
            string sql = Lib.GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = wrkId, CRUDM = "R" });
            using (var db = new Lib.GaiaHelper())
            {
                var dataTable = db.QueryToDataTable(sql, DSearchParam);
                dataSet.Tables.Add(dataTable);
            }
            return dataSet;
        }

        private List<T> ExecuteQuery<T>()
        {
            string sql = Lib.GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = wrkId, CRUDM = "R" });
            using (var db = new Lib.GaiaHelper())
            {
                return db.Query<T>(sql, DSearchParam).ToList();
            }
        }

        public void Open()
        {
            return;
        }

        public void Save()
        {
            return;
        }

        public void Delete()
        {
            return;
        }

        public void New()
        {
            return;
        }

        public void OnDataChanged(DataChangedEventArgs e)
        {
            return;
        }
    }
}
