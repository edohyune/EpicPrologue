using Dapper;
using Lib;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.Control;

namespace Ctrls
{
    public class UCField : UserControl, INotifyPropertyChanged
    {
        public BindingSource fieldCtrl = new BindingSource();
        public string FrmID { get; set; }
        public string FldID { get; set; }

        public UCField()
        {
            Load += fieldCtrl_Load;
        }

        private void fieldCtrl_Load(object? sender, EventArgs e)
        {
            try
            {
                FrmID = this.FindForm().Name;
                FldID = this.Name;

                using (var db = new GaiaHelper())
                {
                    //var ucInfo = db.GetUc(new { sys = SysCode, frm = FrmID, field = FldID }).SingleOrDefault();
                    //if (ucInfo != null)
                    //{
                    //    this.Visible = (ucInfo.Show_chk == "0" ? false : true);
                    //}
                }
            }
            catch (Exception) { }
        }

        public void Clear()
        {
            NewDocument();
        }

        private void NewDocument()
        {
            fieldCtrl.AddNew();
            dynamic doc = fieldCtrl.Current;
            doc.ChangedFlag = MdlState.Inserted;
            fieldCtrl.DataSource = doc;
        }
        //public void Save()
        //{
        //    SaveFieldSet();
        //}

        //public void Save<T>()
        //{
        //    SaveFieldSet();
        //}

        //private void SaveFieldSet()
        //{
        //    try
        //    {
        //        Common.gLog = $"1";
        //        fieldCtrl.EndEdit();
        //        Common.gLog = $"2";
        //        dynamic doc = fieldCtrl.Current;
        //        Common.gLog = $"3";
        //        using (var db = new ACE.Lib.DbHelper())
        //        {
        //            Common.gLog = $"{SysCode}, {FrmID}, {FldID}";
        //            List<MdlParam> rows = db.RefParam(new { sys = SysCode, frm = FrmID, wkset = FldID });
        //            Common.gLog = $"{doc.ChangedFlag}";
        //            string sql = string.Empty;
        //            int ii = 0;
        //            switch (doc.ChangedFlag)
        //            {
        //                case ChangedFlagEnum.Inserted:
        //                    Common.gLog = $"-- {FldID} Insert";
        //                    Common.gLog = $"-- Save As Parameters";
        //                    sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "C" });
        //                    foreach (var row in rows)
        //                    {
        //                        sql = sql.Replace($"@{row.Ctrl_id}", $"'{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'");
        //                        Common.gLog = $"@{row.Ctrl_id} : '{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'";
        //                    }
        //                    Common.gLog = sql;
        //                    ii = db.OpenExecute(sql, doc);
        //                    Common.gLog = $"--END Insert{Environment.NewLine}";
        //                    break;
        //                case ChangedFlagEnum.Updated:
        //                    Common.gLog = $"-- {FldID} Update";
        //                    Common.gLog = $"-- Save As Parameters";
        //                    sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "U" });
        //                    foreach (var row in rows)
        //                    {
        //                        sql = sql.Replace($"@{row.Ctrl_id}", $"'{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'");
        //                        Common.gLog = $"@{row.Ctrl_id} : '{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'";
        //                    }
        //                    Common.gLog = sql;
        //                    ii = db.OpenExecute(sql, doc);
        //                    Common.gLog = $"--END Update{Environment.NewLine}";
        //                    break;
        //                case ChangedFlagEnum.Deleted:
        //                    Common.gLog = $"-- {FldID} Delete";
        //                    sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "D" });
        //                    foreach (var row in rows)
        //                    {
        //                        sql = sql.Replace($"@{row.Ctrl_id}", $"'{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'");
        //                    }
        //                    Common.gLog = sql;
        //                    ii = db.OpenExecute(sql, doc);
        //                    Common.gLog = $"--END Delete{Environment.NewLine}";
        //                    break;
        //            }
        //            Common.gLog = $"6";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Common.gLog = e.ToString();
        //        Common.gLog = e.Message.ToString();
        //    }
        //}


        //public void Delete()
        //{
        //    DeleteFieldSet();
        //}

        //private void DeleteFieldSet()
        //{
        //    dynamic doc = fieldCtrl.Current;
        //    doc.ChangedFlag = ChangedFlagEnum.Deleted;
        //    fieldCtrl.DataSource = doc;
        //    string sql = string.Empty;
        //    int ii = 0;

        //    using (var db = new ACE.Lib.DbHelper())
        //    {
        //        Common.gLog = $"-- {FldID} Delete";
        //        sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "D" });
        //        Common.gLog = sql;
        //        ii = db.OpenExecute(sql, doc);
        //        Common.gLog = $"--END Delete{Environment.NewLine}";
        //    }
        //}

        //public void Open<T>()
        //{
        //    OpenFieldSet<T>();
        //}

        //private void OpenFieldSet<T>()
        //{
        //    DynamicParameters fieldSetSelectParam = null;

        //    using (var db = new ACE.Lib.DbHelper())
        //    {
        //        Common.gLog = $"{Environment.NewLine}-- {FldID} OpenFieldSet<T>()";
        //        var fieldSetSelectQuery = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "R" });
        //        List<MdlParam> fieldSetParamList = db.PullParam(new { sys = SysCode, frm = FrmID, wkset = FldID });
        //        fieldSetSelectParam = new DynamicParameters();
        //        foreach (var item in fieldSetParamList)
        //        {
        //            string tmp = GetParamValue(this.FindForm().Controls, item.Param_name, item.Wkset_id, item.Ctrl_id);
        //            fieldSetSelectParam.Add(item.Param_name, tmp);
        //            Common.gLog = $"Declare @{item.Param_name} varchar(100) ='{tmp}'";
        //        }
        //        Common.gLog = fieldSetSelectQuery;
        //        dynamic bindT = db.Query<T>(fieldSetSelectQuery, fieldSetSelectParam).FirstOrDefault();
        //        if (bindT != null)
        //        {
        //            bindT.ChangedFlag = ChangedFlagEnum.None;
        //            fieldCtrl.DataSource = bindT;
        //        }
        //    }
        //}

        //public void InitFieldSet<T>(T fieldSet)
        //{
        //    fieldCtrl.Add(fieldSet);//

        //    using (var db = new ACE.Lib.DbHelper())
        //    {
        //        var ctrls = db.PushParam(new { sys = SysCode, frm = FrmID, wkset = FldID });
        //        var fieldInfo = ctrls.ToDictionary(x => x.Ctrl_id, x => x.Ctrl_ty);
        //        var mapping = ctrls.ToDictionary(x => x.Ctrl_id, x => x.Param_name);
        //        foreach (var item in fieldInfo)
        //        {
        //            InitBinding(this.FindForm(), item.Key, item.Value, mapping[item.Key]);
        //        }
        //    }
        //    dynamic tmp = fieldCtrl.Current;
        //    tmp.ChangedFlag = ChangedFlagEnum.Inserted;
        //    Common.gLog = $"{Environment.NewLine}-- {FldID} Initialization FieldSet";
        //}

        //private void InitBinding(Form uc, string ctrlID, string ctrlTY, string map)
        //{
        //    switch (ctrlTY.ToLower())
        //    {
        //        case "uctext":
        //            UCTextBox uctext = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCText;
        //            uctext.DataBindings.Clear();
        //            uctext.DataBindings.Add("BindText", fieldCtrl, map, true, DataSourceUpdateMode.OnPropertyChanged);
        //            break;
        //        case "ucdate":
        //            UCDate ucdate = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCDate;
        //            ucdate.DataBindings.Clear();
        //            ucdate.DataBindings.Add("BindText", fieldCtrl, map, true, DataSourceUpdateMode.OnPropertyChanged);
        //            break;
        //        case "uccombo":
        //            UCCombo uccombo = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCCombo;
        //            uccombo.DataBindings.Clear();
        //            uccombo.DataBindings.Add("BindText", fieldCtrl, map, true, DataSourceUpdateMode.OnPropertyChanged);
        //            break;
        //        case "uccheckbox":
        //            UCCheckBox uccheckbox = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCCheckBox;
        //            uccheckbox.DataBindings.Clear();
        //            uccheckbox.DataBindings.Add("BindText", fieldCtrl, map, true, DataSourceUpdateMode.OnPropertyChanged);
        //            break;
        //        case "ucmemo":
        //            UCMemo ucmemo = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCMemo;
        //            ucmemo.DataBindings.Clear();
        //            ucmemo.DataBindings.Add("BindText", fieldCtrl, map, true, DataSourceUpdateMode.OnPropertyChanged);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //public void OpenFieldSet(dynamic ins)
        //{
        //    fieldCtrl.DataSource = ins;
        //    ins.ChangedFlag = MdlState.None;

        //    // 데이터 바인딩 설정 (필요에 따라 추가)
        //    using (var db = new GaiaHelper())
        //    {
        //        var ctrls = db.PushParam(new { sys = SysCode, frm = FrmID, wkset = FldID });
        //        var fieldInfo = ctrls.ToDictionary(x => x.Ctrl_id, x => x.Ctrl_ty);
        //        var mapping = ctrls.ToDictionary(x => x.Ctrl_id, x => x.Param_name);
        //        foreach (var item in fieldInfo)
        //        {
        //            InitBinding(this.FindForm(), item.Key, item.Value, mapping[item.Key]);
        //        }
        //    }
        //}


        public event PropertyChangedEventHandler? PropertyChanged;

        public MdlState ChangedFlag { get; set; } = MdlState.Inserted;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Set<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            backingField = value;
            if (this.ChangedFlag != MdlState.Inserted)
            {
                this.ChangedFlag = MdlState.Updated;
            }
            OnPropertyChanged(propertyName);
        }

        public string GetParamValue(ControlCollection frm, string param_name, string wkset, string field)
        {
            string str = string.Empty;
            if (wkset != "Field")
            {
                dynamic tbx = frm.Find(wkset, true).FirstOrDefault();
                str = tbx.GetText(field);
            }
            else
            {
                dynamic tbx = frm.Find(field, true).FirstOrDefault();
                str = tbx.BindText;
            }
            return str;
        }


    }
}
