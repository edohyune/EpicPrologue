namespace EL010.Lib.Repo
{
    public class TUserControlProp : MdlBase
    {
        #region Properties
        string _Id;
        public string Id { get => _Id; set => Set(ref _Id, value); }

        string _Sys_cd;
        public string Sys_cd { get => _Sys_cd; set => Set(ref _Sys_cd, value); }

        string _Wkset_id;
        public string Wkset_id { get => _Wkset_id; set => Set(ref _Wkset_id, value); }

        string _Wkset_ty;
        public string Wkset_ty { get => _Wkset_ty; set => Set(ref _Wkset_ty, value); }

        string _Frm_id;
        public string Frm_id { get => _Frm_id; set => Set(ref _Frm_id, value); }

        string _Ctrl_id;
        public string Ctrl_id { get => _Ctrl_id; set => Set(ref _Ctrl_id, value); }

        string _Ctrl_ty;
        public string Ctrl_ty { get => _Ctrl_ty; set => Set(ref _Ctrl_ty, value); }

        string _Field_ty;
        public string Field_ty { get => _Field_ty; set => Set(ref _Field_ty, value); }

        string _Title;
        public string Title { get => _Title; set => Set(ref _Title, value); }

        string _TitleAlign;
        public string TitleAlign { get => _TitleAlign; set => Set(ref _TitleAlign, value); }
        string _TitleW;
        public string TitleW { get => _TitleW; set => Set(ref _TitleW, value); }
        string _Popup;
        public string Popup { get => _Popup; set => Set(ref _Popup, value); }

        string _Txt;
        public string Txt { get => _Txt; set => Set(ref _Txt, value); }

        string _TxtAlign;
        public string TxtAlign { get => _TxtAlign; set => Set(ref _TxtAlign, value); }

        string _Fix_chk;
        public string Fix_chk { get => _Fix_chk; set => Set(ref _Fix_chk, value); }

        string _Group_chk;
        public string Group_chk { get => _Group_chk; set => Set(ref _Group_chk, value); }

        string _Show_chk;
        public string Show_chk { get => _Show_chk; set => Set(ref _Show_chk, value); }

        string _Need_chk;
        public string Need_chk { get => _Need_chk; set => Set(ref _Need_chk, value); }

        string _Edit_chk;
        public string Edit_chk { get => _Edit_chk; set => Set(ref _Edit_chk, value); }

        string _Band1;
        public string Band1 { get => _Band1; set => Set(ref _Band1, value); }

        string _Band2;
        public string Band2 { get => _Band2; set => Set(ref _Band2, value); }

        string _Sum_ty;
        public string Sum_ty { get => _Sum_ty; set => Set(ref _Sum_ty, value); }

        string _Format_ty;
        public string Format_ty { get => _Format_ty; set => Set(ref _Format_ty, value); }

        string _Color_bg;
        public string Color_bg { get => _Color_bg; set => Set(ref _Color_bg, value); }

        string _Color_fore;
        public string Color_fore { get => _Color_fore; set => Set(ref _Color_fore, value); }

        string _Seq;
        public string Seq { get => _Seq; set => Set(ref _Seq, value); }
        #endregion

    }
    public interface ITUserCtrlPropRepo
    {
        TUserControlProp GetUserCtrlPropertiesById(string sysCd, string frmId, string fldId);
        void Add(TUserControlProp ctrlProp);
        void Update(TUserControlProp ctrlProp);
        void Delete(int id);
    }
    public class TUserCtrlPropRepo : ITUserCtrlPropRepo
    {
        public void Add(TUserControlProp ctrlProp)
        {
            throw new NotImplementedException();
        }
        public void Update(TUserControlProp gridProp)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TUserControlProp GetUserCtrlPropertiesById(string sysCd, string frmId, string fldId)
        {
            Lib.Common.gMsg = $"Get UserController Properties {sysCd}, {frmId}, {fldId}";

            string sql = "SELECT * FROM TUserControlProp WHERE Sys_cd = @sys AND Frm_id = @frm AND Ctrl_id = @fld";
            Lib.Common.gLog = sql;
            using (var db = new GaiaHelper())
            {
                return db.Query<TUserControlProp>(sql, new { sys = sysCd, frm = frmId, fld = fldId }).FirstOrDefault();
            }
        }
    }
}
