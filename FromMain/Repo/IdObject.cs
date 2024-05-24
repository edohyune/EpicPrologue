using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class IdValue
    {
        public string Txt { get; set; }
        public string Val { get; set; }

        public override string ToString()
        {
            return Txt;
        }
    }
    public class IdValueRepo
    {
        public string Txt { get; set; }
        public string Val { get; set; }

        public List<IdValue> GetLookUp(string query, object param)
        {
            string sql = query
            using (var db = new Lib.GaiaHelper())
            {

                //var result = db.Query<FrwFrm>(sql, new { FrwId = frwId, UsrRegId = ownId }).ToList();
                //foreach (var item in result)
                //{
                //    item.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정
                //}
                //return result;
            }
        }
    }

    public class IdObject
    {
        public string Txt { get; set; }
        public object Obj { get; set; }

        public override string ToString()
        {
            return Txt;
        }
    }
    public interface IIdObjectRepo
    {
        string Txt { get; set; }
        object Obj { get; set; }
    }
    public class IdobjectRepo : IIdObjectRepo
    {
        public string Txt { get; set; }
        public object Obj { get; set; }
    }


    public class IdObject<T> : IdObject
    {
        public new T Obj { get; set; }
    }
    public class IdObject<T, V01> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
    }
    public class IdObject<T, V01, V02> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
    }
    public class IdObject<T, V01, V02, V03> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
    }
    public class IdObject<T, V01, V02, V03, V04> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
        public V04 Val04 { get; set; }
    }
        public class IdObject<T, V01, V02, V03, V04, V05> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
        public V04 Val04 { get; set; }
        public V05 Val05 { get; set; }
    }
    public class IdObject<T, V01, V02, V03, V04, V05, V06> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
        public V04 Val04 { get; set; }
        public V05 Val05 { get; set; }
        public V06 Val06 { get; set; }
    }
    public class IdObject<T, V01, V02, V03, V04, V05, V06, V07> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
        public V04 Val04 { get; set; }
        public V05 Val05 { get; set; }
        public V06 Val06 { get; set; }
        public V07 Val07 { get; set; }
    }
    public class IdObject<T, V01, V02, V03, V04, V05, V06, V07, V08> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
        public V04 Val04 { get; set; }
        public V05 Val05 { get; set; }
        public V06 Val06 { get; set; }
        public V07 Val07 { get; set; }
        public V08 Val08 { get; set; }
    }
    public class IdObject<T, V01, V02, V03, V04, V05, V06, V07, V08, V09> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
        public V04 Val04 { get; set; }
        public V05 Val05 { get; set; }
        public V06 Val06 { get; set; }
        public V07 Val07 { get; set; }
        public V08 Val08 { get; set; }
        public V09 Val09 { get; set; }
    }
    public class IdObject<T, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10> : IdObject
    {
        public new T Obj { get; set; }
        public V01 Val01 { get; set; }
        public V02 Val02 { get; set; }
        public V03 Val03 { get; set; }
        public V04 Val04 { get; set; }
        public V05 Val05 { get; set; }
        public V06 Val06 { get; set; }
        public V07 Val07 { get; set; }
        public V08 Val08 { get; set; }
        public V09 Val09 { get; set; }
        public V10 Val10 { get; set; }
    }

}
