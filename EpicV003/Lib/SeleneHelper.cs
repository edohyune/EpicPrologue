using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace EpicV003.Lib
{
    public class SeleneHelper : IDisposable
    {
        private SqlConnection _conn;
        private SqlTransaction _tran;
        private bool _disposed = false;

        private readonly string _connectionString;

        public SeleneHelper()
        {
            _connectionString = $"Data Source=192.168.1.9;" + //$"Data Source={Common.gSVR};" +
                    $"Initial Catalog=SELENE;" + //$"Initial Catalog={Common.gSolution};" +
                    $"Persist Security Info=True;" +
                    $"User ID=sa;" +
                    $"Password=Password01";
            _conn = new SqlConnection(_connectionString);
        }
        ~SeleneHelper()
        {
            Dispose(disposing: false);
        }

        public void BeginTransaction()
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            _tran = _conn.BeginTransaction();
        }

        public void Commit()
        {
            _tran?.Commit();
            _conn?.Close();
            _tran = null;
        }

        public void RollBack()
        {
            _tran?.Rollback();
            _conn?.Close();
            _tran = null;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // 관리되는 리소스 해제
                    if (_tran != null)
                    {
                        _tran.Dispose();
                        _tran = null;
                    }
                    if (_conn != null)
                    {
                        _conn.Dispose();
                        _conn = null;
                    }
                }

                // 관리되지 않는 리소스 해제
                // 현재 예제에서는 관리되지 않는 리소스가 없습니다.

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
                return SqlMapper.Query(_conn, sql, param, _tran).Select(x => x as IDictionary<string, object>).ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        //2. 쿼리 실행 및 다중 결과 반환
        //동적 타입 결과 반환
        public IEnumerable<dynamic> Query(string sql, object param)
        {
            try
            {
                return SqlMapper.Query(_conn, sql, param, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        //제네릭 타입 결과 반환(파라미터 없음)
        public List<T> Query<T>(string sql)
        {
            try
            {
                return SqlMapper.Query<T>(_conn, sql, null, _tran).ToList();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }
        //제네릭 타입 결과 반환 (오브젝트 파라미터)
        public List<T> Query<T>(string sql, object param = null)
        {
            try
            {
                return SqlMapper.Query<T>(_conn, sql, param, _tran).ToList();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }
        //제네릭 타입 결과 반환 (DynamicParameters 파라미터)
        public List<T> Query<T>(string sql, DynamicParameters param)
        {
            try
            {
                return SqlMapper.Query<T>(_conn, sql, param, _tran).ToList();

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        //3. 쿼리 실행(업데이트/인서트/삭제)
        //실행 후 영향 받은 행의 수 반환(파라미터 없음)
        public int OpenExecute(string sql)
        {
            try
            {
                return SqlMapper.Execute(_conn, sql, null, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }

        }
        //public int OpenExecute(string sql, DynamicParameters param)
        //{
        //    try
        //    {
        //        return SqlMapper.Execute(_conn, sql, param, _tran);

        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw;
        //    }
        //}

        //실행 후 영향 받은 행의 수 반환 (오브젝트 파라미터)
        public int OpenExecute(string sql, object param)
        {
            try
            {
                return SqlMapper.Execute(_conn, sql, param, _tran);

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }
        //4. 스칼라 값 반환 쿼리 실행
        //단일 값 반환(파라미터 없음)
        public string OpenQuery(string sql, object param = null)
        {
            try
            {
                return _conn.ExecuteScalar<string>(sql, null, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        public T OpenQuery<T>(string sql, object param = null)
        {
            try
            {
                return _conn.ExecuteScalar<T>(sql, null, _tran);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }
        #endregion

        private void LogException(Exception ex)
        {
            Lib.Common.gMsg = ex.Message;
        }
    }
    public class MetaModel : MdlBase
    {
        public string FieldId { get; set; }
        public string FieldType { get; set; }
    }
}