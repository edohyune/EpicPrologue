using Dapper;
using DevExpress.CodeParser;
using DevExpress.Data.Filtering.Helpers;
using Lib.Repo;
using Lib.Syntax;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Lib
{
    public class GaiaHelper : IDisposable
    {
        private static readonly Lazy<GaiaHelper> _instance = new Lazy<GaiaHelper>(() => new GaiaHelper(), true);
        public static GaiaHelper Instance => _instance.Value;

        private readonly string _connectionString;
        //MSSQL - If USE Other DB. Using(IDbConnection, IDbTransaction) 
        private SqlConnection? _conn;
        private SqlTransaction? _tran;

        private bool _disposed = false;

        static GaiaHelper()
        {
            // BoolCharTypeHandler 클래스가 ITypeHandler 인터페이스를 구현한다고 가정
            //SqlMapper.AddTypeHandler(typeof(bool), new BoolCharTypeHandler());
        }

        public GaiaHelper()
        {
            _connectionString = $"Data Source=192.168.1.2;" + //$"Data Source={Common.gSVR};" +
                                $"Initial Catalog=GAIA;" + //$"Initial Catalog={Common.gSolution};" +
                                $"Persist Security Info=True;" +
                                $"User ID=sa;" +
                                $"Password=Password01";
            _conn = new SqlConnection(_connectionString);
        }

        public void BeginTransaction()
        {
            //To Do : _conn null check
            //if (_tran == null) { }
            //if (_conn == null) { }
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            _tran = _conn.BeginTransaction();
        }

        public void Commit()
        {
            _tran.Commit();
            _conn.Close();
            _tran = null;
        }

        public void RollBack()
        {
            _tran.Rollback();
            _conn.Close();
            _tran = null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    _tran?.Dispose();
                    _conn?.Dispose();
                }

                // Set large fields to null.
                _tran = null;
                _conn = null;
                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #region Dapper QueryExecute
        //1. 쿼리 실행 및 단일 결과 반환
        //단일 행 쿼리 및 결과 반환(IDictionary 사용)
        public IDictionary<string, object> QueryKeyValue(string sql, object param)
        {
            try
            {
                sql = ProcessQuery(sql, param);
                return SqlMapper.Query(_conn, sql, param, _tran).Select(x => x as IDictionary<string, object>).ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }

        //2. 쿼리 실행 및 다중 결과 반환
        //동적 타입 결과 반환
        public IEnumerable<dynamic> Query(string sql, object param)
        {
            try
            {
                sql = ProcessQuery(sql, param);
                return SqlMapper.Query(_conn, sql, param, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }

        //제네릭 타입 결과 반환(파라미터 없음)
        public List<T> Query<T>(string sql)
        {
            try
            {
                sql = ProcessQuery(sql, null);
                return SqlMapper.Query<T>(_conn, sql, null, _tran).ToList();
            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }
        //제네릭 타입 결과 반환 (오브젝트 파라미터)
        public List<T> Query<T>(string sql, object param)
        {
            try
            {
                sql = ProcessQuery(sql, param);
                return SqlMapper.Query<T>(_conn, sql, param, _tran).ToList();
            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }
        //제네릭 타입 결과 반환 (DynamicParameters 파라미터)
        public List<T> Query<T>(string sql, DynamicParameters param)
        {
            try
            {
                sql = ProcessQuery(sql, param);
                return SqlMapper.Query<T>(_conn, sql, param, _tran).ToList();

            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }

        //3. 쿼리 실행(업데이트/인서트/삭제)
        //실행 후 영향 받은 행의 수 반환(파라미터 없음)
        public int OpenExecute(string sql)
        {
            try
            {
                sql = ProcessQuery(sql, null);
                return SqlMapper.Execute(_conn, sql, null, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }

        }
        //실행 후 영향 받은 행의 수 반환 (오브젝트 파라미터)
        public int OpenExecute(string sql, object param)
        {
            try
            {
                sql = ProcessQuery(sql, param);
                return SqlMapper.Execute(_conn, sql, param, _tran);

            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }

        //4. 스칼라 값 반환 쿼리 실행
        //단일 값 반환(파라미터 없음)
        public string OpenQuery(string sql, object param = null)
        {
            try
            {
                sql = ProcessQuery(sql, param);
                return _conn.ExecuteScalar<string>(sql, param, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }

        public T OpenQuery<T>(string sql, object param = null)
        {
            try
            {
                sql = ProcessQuery(sql, null);
                return _conn.ExecuteScalar<T>(sql, param, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex, sql);
                throw;
            }
        }

        public DataSet GetGridColumns(object param)
        {
            var pullFlds = new WrkGetRepo().GetPullFlds(param);
            //WrkGetRepo wrkGetRepo = new WrkGetRepo();
            //var paramlist = wrkGetRepo.GetPullFlds(prm);
            string[] fld = (from a in pullFlds
                            orderby a.Id
                            select a.Id).ToArray();
            string[] val = (from a in pullFlds
                            orderby a.Id
                            select a.Nm).ToArray();

            DataSet dataSet = GetSelectSql(param, fld, val);

            return dataSet;
        }

        private DataSet GetSelectSql(object prm, string[] param, string[] value)
        {
            DataSet dsSelect = new DataSet();

            string sqltxt = GenFunc.GetSql(prm);
            sqltxt = ReplaceAtVariables(sqltxt, param, value);
            sqltxt = RemoveConditionalClauses(sqltxt);

            SqlConnection SqlCon = new SqlConnection(_connectionString);
            SqlCommand SqlCmd = new SqlCommand(sqltxt, SqlCon);

            for (int i = 0; i <= param.Length - 1; i++)
            {
                if (param[i] != null && value[i] != null)
                {
                    SqlCmd.Parameters.AddWithValue(param[i], value[i]);
                }
                else
                {
                    Common.gMsg = $"Parameter {param[i]} or its value is null";
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);
            adapter.SelectCommand = SqlCmd;
            adapter.Fill(dsSelect);
            return dsSelect;
        }
        #endregion
        #region About Log
        private void LogException(Exception ex, string sql = null)
        {
            Lib.Common.gMsg = $"Exception : {ex}";
            Lib.Common.gMsg = $"Query : {sql}";
        }
        private void LogParameters(object param)
        {
            if (param is DynamicParameters dynamicParams)
            {
                foreach (var paramName in dynamicParams.ParameterNames)
                {
                    var paramValue = dynamicParams.Get<object>(paramName);
                }
            }
            else
            {
                foreach (PropertyInfo prop in param.GetType().GetProperties())
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(param);
                }
            }
        }
        #endregion
        #region SQL Query Replace
        private string ProcessQuery(string sql, object param)
        {
            if (param != null)
            {
                sql = ReplaceConditionalClauses(sql, param);
            }
            sql = ReplaceGVariables(sql);
            return sql;
        }

        public string ReplaceGVariables(string sql)
        {
            var gVariables = GetGVariables();
            foreach (var variable in gVariables)
            {
                sql = sql.Replace(variable.Key, variable.Value);
                //sql = Regex.Replace(sql, Regex.Escape(variable.Key), variable.Value, RegexOptions.IgnoreCase);
            }
            return sql;
        }
        private string ReplaceAtVariables(string sql, string[] param, string[] value)
        {
            SQLVariableExtractor extractor = new SQLVariableExtractor();
            SQLSyntaxMatch variables = extractor.ExtractVariables(sql);

            //OPatternMatch에 있는 변수에 value값을 넣는다.
            for (int i = 0; i <= param.Length - 1; i++)
            {
                if (variables.OPatternMatch.ContainsKey(param[i]))
                {
                    sql = sql.Replace(param[i], string.IsNullOrWhiteSpace(value[i]) ? "''" : $"'{value[i]}'");
                }
            }
            //OPatternMatch중에서 value가 null인 경우 sql에서 ''으로 대체
            foreach (var item in variables.OPatternMatch)
            {
                sql = sql.Replace(item.Key, string.IsNullOrWhiteSpace(item.Value) ? "''" : $"'{item.Value}'");
            }
            
            return sql;
        }
        private string RemoveConditionalClauses(string sql)
        {
            var conditionalPattern = new Regex(@"andif\s+(.+?)\s+endif");
            //var conditionalPattern = new Regex(@"andif\s+(.+?)\s+endif", RegexOptions.IgnoreCase);
            return conditionalPattern.Replace(sql, string.Empty);
        }

        private Dictionary<string, string> GetGVariables()
        {
            var globalVariables = new Dictionary<string, string>();
            var fields = typeof(Common).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var field in fields)
            {
                var value = field.GetValue(null)?.ToString();
                if (value != null)
                {
                    globalVariables.Add($"<${field.Name}>", value);
                }
            }
            return globalVariables;
        }
        private string ReplaceConditionalClauses(string sql, object param)
        {
            var conditionalPattern = new Regex(@"andif\s+(.+?)\s+endif");
            //var conditionalPattern = new Regex(@"andif\s+(.+?)\s+endif", RegexOptions.IgnoreCase);
            var dynamicParams = param as DynamicParameters;
            var paramNames = dynamicParams?.ParameterNames.ToHashSet(StringComparer.OrdinalIgnoreCase)
                             ?? param.GetType().GetProperties().Select(p => p.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);

            return conditionalPattern.Replace(sql, match =>
            {
                var condition = match.Groups[1].Value;
                var paramName = Regex.Match(condition, @"@\w+").Value;

                if (paramNames.Contains(paramName.Trim('@')))
                {
                    return $"AND {condition}";
                }

                return string.Empty;
            });
        }
        #endregion
    }
    public class BoolCharTypeHandler : SqlMapper.ITypeHandler
    {
        // 데이터베이스에서 값을 읽을 때 호출됩니다.
        // "1"이면 true를, 그렇지 않으면 false를 반환합니다.
        public object Parse(Type destinationType, object value)
        {
            return value?.ToString() == "1";
        }

        // 데이터베이스에 값을 설정할 때 호출됩니다.
        // bool 값이 true이면 "1"을, false이면 "0"을 저장합니다.
        public void SetValue(IDbDataParameter parameter, object value)
        {
            parameter.Value = (bool)value ? "1" : "0";
            parameter.DbType = DbType.StringFixedLength;
            parameter.Size = 1;
        }
    }
}