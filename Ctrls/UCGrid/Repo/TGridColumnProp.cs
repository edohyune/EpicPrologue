using Lib;

namespace Repo
{
    public class TGridColumnProp : MdlBase
    {
        string _ty;        // A: update, B: insert, C: delete
        string _Id300;     // Not Mapped
        string _Id310;     // Mapped
        string _Sys_cd;    // "System Code"
        string _Wkset_id;  // "WorkSet ID"
        string _Wkset_ty;  // "GridSet"
        string _Frm_id;    // "Form ID"
        string _Ctrl_id;   // Column ID
        string _Ctrl_ty;   // Text, Int, Date, Decimal, Code(Lookup)
        string _Field_ty;  // "Column"
        string _Title;     // Title
        DevExpress.Utils.HorzAlignment _TitleAlign; // Title Alignment
        string _TitleW;    // Title Width
        string _Popup;     // Lookup
        string _Txt;       // Default Text
        DevExpress.Utils.HorzAlignment _TxtAlign; // Text Alignment
        string _Fix_chk;   // Freeze Column
        string _Group_chk; // Grouping
        string _Show_chk;  // Hide
        string _Need_chk;  // Necessary Field
        string _Edit_chk;  // ReadOnly
        string _Band1;     // Title Band 2nd
        string _Band2;     // Title Band 1st
        string _Sum_ty;    // sum, avg, max, min
        string _Format_ty; // #.##, #,##0.00
        string _Color_bg;  // Column Background Color
        string _Color_fore;// Text Color
        string _Seq;       // Column Order 
        string _CtrlW;     // Column Width
        string _CtrlH;     // Column Height

        public string CtrlW { get=>_CtrlW; set=> Set(ref _CtrlW, value); }
        public string CtrlH { get => _CtrlH; set => Set(ref _CtrlH, value); }
        public string ty { get => _ty; set => Set(ref _ty, value); }
        public string Id300 { get => _Id300; set => Set(ref _Id300, value); }
        public string Id310 { get => _Id310; set => Set(ref _Id310, value); }
        public string Sys_cd { get => _Sys_cd; set => Set(ref _Sys_cd, value); }
        public string Wkset_id { get => _Wkset_id; set => Set(ref _Wkset_id, value); }
        public string Wkset_ty { get => _Wkset_ty; set => Set(ref _Wkset_ty, value); }
        public string Frm_id { get => _Frm_id; set => Set(ref _Frm_id, value); }
        public string Ctrl_id { get => _Ctrl_id; set => Set(ref _Ctrl_id, value); }
        public string Ctrl_ty { get => _Ctrl_ty; set => Set(ref _Ctrl_ty, value); }
        public string Field_ty { get => _Field_ty; set => Set(ref _Field_ty, value); }
        public string Title { get => _Title; set => Set(ref _Title, value); }
        public DevExpress.Utils.HorzAlignment TitleAlign { get => _TitleAlign; set => Set(ref _TitleAlign, value); }
        public string TitleW { get => _TitleW; set => Set(ref _TitleW, value); }
        public string Popup { get => _Popup; set => Set(ref _Popup, value); }
        public string Txt { get => _Txt; set => Set(ref _Txt, value); }
        public DevExpress.Utils.HorzAlignment TxtAlign { get => _TxtAlign; set => Set(ref _TxtAlign, value); }
        public string Fix_chk { get => _Fix_chk; set => Set(ref _Fix_chk, value); }
        public string Group_chk { get => _Group_chk; set => Set(ref _Group_chk, value); }
        public string Show_chk { get => _Show_chk; set => Set(ref _Show_chk, value); }
        public string Need_chk { get => _Need_chk; set => Set(ref _Need_chk, value); }
        public string Edit_chk { get => _Edit_chk; set => Set(ref _Edit_chk, value); }
        public string Band1 { get => _Band1; set => Set(ref _Band1, value); }
        public string Band2 { get => _Band2; set => Set(ref _Band2, value); }
        public string Sum_ty { get => _Sum_ty; set => Set(ref _Sum_ty, value); }
        public string Format_ty { get => _Format_ty; set => Set(ref _Format_ty, value); }
        public string Color_bg { get => _Color_bg; set => Set(ref _Color_bg, value); }
        public string Color_fore { get => _Color_fore; set => Set(ref _Color_fore, value); }
        public string Seq { get => _Seq; set => Set(ref _Seq, value); }
    }
    public interface ITGridColumnPropRepo 
    {
        TGridColumnProp GetTGridColumnPropertyById(int id);
        void Add(TGridColumnProp gridProp);
        void Update(TGridColumnProp gridProp);
        void Delete(int id);
        List<TGridColumnProp> GetTGridColumnProperties(string sysCd, string frmId, string wkSet);
    }
    public  class TGridColumnPropRepo : ITGridColumnPropRepo
    {
        public void Add(TGridColumnProp gridProp)
        {
            string sql = ""; // INSERT 쿼리 작성
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, gridProp);
            }
        }

        public void Update(TGridColumnProp gridProp)
        {
            string sql = ""; // UPDATE 쿼리 작성
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, gridProp);
            }
        }

        public void Delete(int id)
        {
            string sql = ""; // DELETE 쿼리 작성
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { Id = id });
            }
        }

        public TGridColumnProp GetTGridColumnPropertyById(int id)
        {
            string sql = ""; // 적절한 SQL 쿼리 작성
            using (var db = new GaiaHelper())
            {
                var result = db.Query<TGridColumnProp>(sql, new { Id = id }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the id {id} was not found.");
                }
                return result;
            }
        }

        public List<TGridColumnProp> GetTGridColumnProperties(string sysCd, string frmId, string wkSetId)
        {   
            Lib.Common.gMsg = $"Get Grid Column Properties {sysCd}, {frmId}, {wkSetId}";
            string sql = @"
--A update  --B insert  --C delete    
--둘다있는경우  
select ty='A', Id300=a.Id, Id310=b.Id,
       a.Sys_cd, a.Frm_id, a.Ctrl_id, a.Ctrl_ty, b.Field_ty,
       Title=isnull(b.Title,a.Title), TitleAlign=isnull(b.TitleAlign,a.TitleAlign),
       Show_chk=isnull(b.Show_chk,a.Show_chk), Edit_chk=isnull(b.Edit_chk,a.Edit_chk),
       Wkset_ty=isnull(b.Wkset_ty,a.Wkset_ty),
       b.Wkset_id, b.TitleW, b.Popup, b.Txt, b.TxtAlign, b.Fix_chk, b.Group_chk,
       b.Need_chk, b.Band1, b.Band2, b.Sum_ty, b.Format_ty, b.Color_bg, b.Color_fore, b.Seq
  from ATZ300 a
  join ATZ310 b on a.Sys_cd=b.Sys_cd and a.Frm_id=b.Frm_id and a.Ctrl_id=b.Ctrl_id and a.Ctrl_ty=b.Ctrl_ty and a.wkset_id=b.wkset_id
 where a.Sys_cd=@sys
   and a.Frm_id=@frm
   and b.Wkset_id=@wkset
   and a.Wkset_ty in ('Column','Field')  
--Ctrl에만 있는 경우
 union all
select ty='B', Id300=a.Id, Id310=null,
       a.Sys_cd, a.Frm_id, a.Ctrl_id, a.Ctrl_ty, Field_ty='Text',
       a.Title, a.TitleAlign, a.Show_chk, a.Edit_chk, a.Wkset_ty,
       Wkset_id=null, TitleW=null, Popup=null, Txt=null, TxtAlign=null, Fix_chk=null, Group_chk=null,
       Need_chk=null, Band1=null, Band2=null, Sum_ty=null, Format_ty=null, Color_bg=null, Color_fore=null, Seq=null
  from ATZ300 a
  join (select Sys_cd, Frm_id, Ctrl_id, Ctrl_ty
          from ATZ300
         where Sys_cd=@sys
           and Frm_id=@frm
           and Wkset_id=@wkset
           and Wkset_ty in ('Column','Field')
        except
        select Sys_cd, Frm_id, Ctrl_id, Ctrl_ty
          from ATZ310
         where Sys_cd=@sys
           and Frm_id=@frm
           and Wkset_id=@wkset) b on a.Sys_cd=b.Sys_cd and a.Frm_id=b.Frm_id and a.Ctrl_id=b.Ctrl_id and a.Ctrl_ty=b.Ctrl_ty
 where a.Sys_cd=@sys
   and a.Frm_id=@frm
   and a.Wkset_id=@wkset
   and a.Wkset_ty in ('Column','Field')  --Ctrl에만 있는 경우   
 union all
select ty='C', Id300=null, Id310=a.Id,
       a.Sys_cd, a.Frm_id, a.Ctrl_id, a.Ctrl_ty, a.Field_ty,
       a.Title, a.TitleAlign,
       a.Show_chk, a.Edit_chk,
       a.Wkset_ty,
       a.Wkset_id, a.TitleW, a.Popup, a.Txt, a.TxtAlign, a.Fix_chk, a.Group_chk,
       a.Need_chk, a.Band1, a.Band2, a.Sum_ty, a.Format_ty, a.Color_bg, a.Color_fore, a.Seq
  from ATZ310 a
  join (select Sys_cd, Frm_id, Ctrl_id, Ctrl_ty
          from ATZ310
         where Sys_cd=@sys
           and Frm_id=@frm
           and Wkset_id=@wkset
        except
        select Sys_cd, Frm_id, Ctrl_id, Ctrl_ty
          from ATZ300
         where Sys_cd=@sys
           and Frm_id=@frm
           and Wkset_id=@wkset) b on a.Sys_cd=b.Sys_cd and a.Frm_id=b.Frm_id and a.Ctrl_id=b.Ctrl_id and a.Ctrl_ty=b.Ctrl_ty
 where a.Sys_cd=@sys
   and a.Frm_id=@frm
   and a.Wkset_id=@wkset   
 order by Seq"; 

            Lib.Common.gMsg = sql;
            using (var db = new GaiaHelper())
            {
                return db.Query<TGridColumnProp>(sql, new {sys = sysCd, frm = frmId, wkset = wkSetId }).ToList();
            }
        }
    }


}

