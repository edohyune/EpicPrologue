using Dapper;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraScheduler.Drawing;
using EpicV003.Lib;
using EpicV003.Lib.Repo;
using System.CodeDom;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.Control;

namespace EpicV003.Ctrls
{
    public class UCFieldSet : UserControl, IWorkSet
    {
        public string frwId { get; set; }
        public string frmId { get; set; }
        public string wrkId { get; set; }
        //private WrkFld wrkFld { get; set; }
        //private WrkFldRepo wrkFldRepo { get; set; }
        //private List<WrkFld> wrkFlds { get; set; }
        private DynamicParameters DSearchParam;
        private object OSearchParam;
        public DynamicModel Model { get; set; }

        public UCFieldSet()
        {
            return;
        }
        public UCFieldSet(string _frwId, string _frmId, string _thisNm)
        {
            frwId = _frwId;
            frmId = _frmId;
            wrkId = _thisNm;

            InitializeField();
        }
        public void InitializeField()
        {
            //  - 필드셋의 컨트롤 정보를 불러온다.(frwId, frmId, ctrlNm)
            //wrkFldRepo = new WrkFldRepo();
            //wrkFlds = wrkFldRepo.GetFldsProperties(frwId, frmId, wrkId);


            var wrkSets = new WrkSetRepo().SetPushFlds(frwId, frmId, wrkId);

            //동적 모델을 생성한다. 
            Model = new DynamicModel();

            //  - 필드셋의 컨트롤 정보를 이용해 바인딩을 한다. 그리고 각 컨트롤을 초기화한다. 이때 wrkFl.defaultText값이 있으면 기본값으로 셋팅한다.
            //foreach (WrkFld wrkFld in wrkFlds)
            //{
            //    Model.SetDynamicProperty(wrkFld.FldNm, wrkFld.DefaultText);
            //    Control ctrl = this.Controls.Find(wrkFld.FldNm, true).FirstOrDefault();
            //    if (ctrl != null)
            //    {
            //        BindControl(ctrl, wrkFld.ToolNm, wrkFld);
            //        SetControlValue(ctrl, wrkFld.FldNm, wrkFld.ToolNm, wrkFld.DefaultText);
            //    }
            //}
            foreach (WrkSet wrkSet in wrkSets)
            {
                Model.SetDynamicProperty(wrkSet.SetFldNm, wrkSet.SetDefaultValue);
                Control ctrl = this.Controls.Find(wrkSet.SetFldNm, true).FirstOrDefault();
                if (ctrl != null)
                {
                    BindControl(ctrl, wrkSet.ToolNm, wrkSet);
                    SetControlValue(ctrl, wrkSet.FldNm, wrkSet.ToolNm, wrkSet.SetDefaultValue);
                }
            }

        }

        public void Open()
        {
            Common.gMsg = $"{Environment.NewLine}-- {wrkId}.Open<T>() ------------------------>>";
            WrkGetRepo wrkGetRepo = new WrkGetRepo();
            List<WrkGet> wrkGets = wrkGetRepo.GetPullFlds(frwId, frmId, wrkId);
            DSearchParam = new DynamicParameters();

            foreach (var wrkGet in wrkGets)
            {
                string tmp = GetParamValue(this.FindForm().Controls, wrkGet);
                DSearchParam.Add(wrkGet.FldNm, tmp);
                Common.gMsg = $"Declare {wrkGet.FldNm} varchar ='{tmp}'";
            }
            OpenWrk();
        }

        private void OpenWrk()
        {
            try
            {
                // 1. 모델 정보 가져오기
                WrkFldRepo wrkFldRepo = new WrkFldRepo();
                List<WrkFld> flds = wrkFldRepo.GetFldsProperties(frwId, frmId, wrkId);

                // 2. SQL 쿼리 실행 및 결과 가져오기
                var sql = GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = wrkId, CRUDM = "R" });
                
                using (var db = new GaiaHelper())
                {
                    var resultDict = db.QueryKeyValue(sql, DSearchParam); // 결과를 딕셔너리로 가져오기
                    // 모델 객체 생성 (ExpandoObject)
                    dynamic obj = new ExpandoObject();
                    var objDict = (IDictionary<string, object>)obj;

                    // 속성 설정
                    if (resultDict != null)
                    {
                        foreach (var fld in flds)
                        {
                            if (resultDict.ContainsKey(fld.FldNm))
                            {
                                //objDict[fld.FldNm] = resultDict[fld.FldNm];
                                Model.SetDynamicProperty(fld.FldNm, resultDict[fld.FldNm]);
                                Control ctrl = this.FindForm().Controls.Find(fld.FldNm, true).FirstOrDefault(); // 컨트롤 찾기
                                if (ctrl != null && resultDict.ContainsKey(fld.FldNm))
                                {
                                    SetControlValue(ctrl, fld.CtrlNm, fld.ToolNm, resultDict[fld.FldNm]); // 컨트롤 값 설정
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Common.gMsg = $"-- {wrkId}. Exception ----------------------------->>";
                Common.gMsg = $"UCFieldSet_OpenWrk() : {Environment.NewLine}--frwId : {frwId}{Environment.NewLine}-- frmId : {frmId}{Environment.NewLine}-- WorkSet : {wrkId}{Environment.NewLine}Exception :";
                Common.gMsg = $"{e.Message}";
                Common.gMsg = $"-- {wrkId}.End Exception -------------------------->>";
            }
        }

        private void BindControl(Control ctrl, string toolNm, WrkSet wrkSet)
        {
            var controlType = toolNm.ToLower();
            var bindPropertyMapping = new CtrlMstRepo().GetBindPropertyMapping();
            var bindEventMapping = new CtrlMstRepo().GetBindEventMapping();

            if (bindPropertyMapping.ContainsKey(controlType) && bindEventMapping.ContainsKey(controlType))
            {
                var propertyName = bindPropertyMapping[controlType];
                var eventName = bindEventMapping[controlType];
                var property = ctrl.GetType().GetProperty(propertyName);

                if (property != null)
                {
                    EventInfo eventInfo = ctrl.GetType().GetEvent(eventName);
                    if (eventInfo != null)
                    {
                        eventInfo.AddEventHandler(ctrl, new EventHandler((s, e) => OnControlValueChanged(wrkSet.FldNm, property.GetValue(ctrl))));
                    }
                }
            }
        }

        //private void BindControl(Control ctrl, string toolNm, WrkFld wrkFld)
        //{
        //    var controlType = toolNm.ToLower();
        //    var bindPropertyMapping = new CtrlMstRepo().GetBindPropertyMapping();
        //    var bindEventMapping = new CtrlMstRepo().GetBindEventMapping();

        //    if (bindPropertyMapping.ContainsKey(controlType) && bindEventMapping.ContainsKey(controlType))
        //    {
        //        var propertyName = bindPropertyMapping[controlType];
        //        var eventName = bindEventMapping[controlType];
        //        var property = ctrl.GetType().GetProperty(propertyName);

        //        if (property != null)
        //        {
        //            EventInfo eventInfo = ctrl.GetType().GetEvent(eventName);
        //            if (eventInfo != null)
        //            {
        //                eventInfo.AddEventHandler(ctrl, new EventHandler((s, e) => OnControlValueChanged(wrkFld.FldNm, property.GetValue(ctrl))));
        //            }
        //        }
        //    }
        //}

        public void SetControlValue(Control uc, string ctrlNm, string toolNm, dynamic value)
        {
            var ctrl = uc.Controls.Find(ctrlNm, true).FirstOrDefault();
            if (ctrl != null)
            {
                var controlType = toolNm.ToLower();
                var bindValue = value.ToString(); // 각 컨트롤 유형별로 바인드할 속성 정보를 정의합니다.
                var bindPropertyMapping = new CtrlMstRepo().GetBindPropertyMapping();

                if (bindPropertyMapping.ContainsKey(controlType))
                {
                    var propertyName = bindPropertyMapping[controlType];
                    var property = ctrl.GetType().GetProperty(propertyName);

                    if (property != null)
                    {
                        var convertedValue = Convert.ChangeType(bindValue, property.PropertyType);
                        property.SetValue(ctrl, convertedValue);
                    }
                }
                else
                {
                    // 기본 Text 속성에 바인딩
                    var property = ctrl.GetType().GetProperty("Text");
                    if (property != null)
                    {
                        var convertedValue = Convert.ChangeType(bindValue, property.PropertyType);
                        property.SetValue(ctrl, convertedValue);
                    }
                }
            }
        }

        public void Save()
        {
            SaveWrk();
        }
        private void SaveWrk()
        { 
            return;
        }
        public void Save<T>()
        {
            //FieldSet을 저장한다. 
            //  - DefaultValue를 가져온다. 
            //  - FieldSet의 ChangedFlag의 MdlStat를 이용해 구분한다. 
            //  - insert update 쿼리를 불러와서 실행한다.
            return;
        }

        private string GetParamValue(ControlCollection frm, WrkGet wrkGet)
        {
            string str = string.Empty;

            if (string.IsNullOrEmpty(wrkGet.GetWrkId))
            {
                if (string.IsNullOrEmpty(wrkGet.GetFldNm))
                {
                    str = wrkGet.GetDefalueValue;
                }
                else
                {
                    dynamic tbx = frm.Find(wrkGet.GetFldNm, true).FirstOrDefault();
                    str = tbx.Text;
                }
            }
            else
            {
                dynamic tbx = frm.Find(wrkGet.GetWrkId, true).FirstOrDefault();
                str = tbx.GetText(wrkGet.GetFldNm);
            }
            return str;
        }

        public void Clear()
        {
            //FieldSet을 초기화한다.
            return;
        }
        public void New()
        {
            NewDocument();
        }

        private void NewDocument()
        {
            //FieldSet을 초기화하고 신규데이터를 받을 준비를 한다. 
            return;
        }

        public void Delete()
        {
            return;
            //FieldSet을 삭제한다. 
            //  - FieldSet의 ChangedFlag의 MdlStat를 이용해 구분한다.
            //  - delete 쿼리를 불러와서 실행한다.
        }

        private void OnControlValueChanged(string fieldName, dynamic newValue)
        {
            // 동적 모델에 새로운 값을 설정
            Model.SetDynamicProperty(fieldName, newValue);
            // 데이터 변경 이벤트를 트리거
            OnDataChanged(new DataChangedEventArgs(fieldName, newValue));
        }

        public event EventHandler<DataChangedEventArgs> DataChanged;

        public virtual void OnDataChanged(DataChangedEventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }
    }
}
