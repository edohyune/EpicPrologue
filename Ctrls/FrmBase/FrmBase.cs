using Lib;
using Lib.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ctrls.FrmBase.Models;
using Dapper;
using Ctrls;
using System.Dynamic;

namespace Frms
{
    public class FrmBase : UserControl
    {
        #region Properties Browseable(false) ----------------------------------------------------------
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }


        private object OSearchParam;
        private DynamicParameters DSearchParam;

        private List<UCFieldSet> fieldSets;
        private List<FrmWrk> wrkSetsOrderby;

        #endregion
        #region Properties Browseable(true) -----------------------------------------------------------

        #endregion
        public FrmBase()
        {
            Load += FrmBase_Load;
            fieldSets = new List<UCFieldSet>();
        }

        private void FrmBase_Load(object? sender, EventArgs e)
        {
            frwId = Lib.Common.gFrameWorkId;

            Form? form = this.FindForm();
            frmId = form != null ? form.Name : "Unknown";

            if (!string.IsNullOrEmpty(frwId))
            {
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            //frmWrks WorkSet을 목록을 가져온다. 
            List<FrmWrk> frmWrks = new List<FrmWrk>();
            //WrkId, FrwId, FrmId, CtrlNm, WrkNm, WrkCd, UseYn, Memo 모두 string 제외 useYn은 bool
            frmWrks = new FrmWrkRepo().GetByFrwFrm(frwId, frmId);
            if (frmWrks.Count > 0)
            {
                foreach (FrmWrk frmWrk in frmWrks)
                {
                    UCFieldSet fieldSet = new UCFieldSet(frwId, frmId, frmWrk.CtrlNm);
                    fieldSets.Add(fieldSet);
                    this.Controls.Add(fieldSet);
                    fieldSet.InitializeField();
                    fieldSet.DataChanged += FieldSet_DataChanged;
                }
            }
        }

        #region this.Open() ----------------------------------------------------------
        private void Open()
        {
            //ope
            //foreach (UCFieldSet fieldSet in fieldSets)
            //{
            //    fieldSet.Open();
            //}

            //wrkSetsOrderby으로 wrkSet 목록을 가져온다. 
            FrmWrkRepo frmWrkRepo = new FrmWrkRepo();
            wrkSetsOrderby = frmWrkRepo.GetByWorkSets(frwId, frmId);

            foreach (var wrkSet in wrkSetsOrderby)
            {

            }

            using (var db = new GaiaHelper())
            {

                var sql = GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = , CRUDM = "R" });
                var resultDict = db.QueryKeyValue(sql, DSearchParam);

                dynamic obj = new ExpandoObject();
                var objDict = (IDictionary<string, object>)obj;
                //WorkSet 목록을 가져온다. 
                if (resultDict != null)
                {
                    foreach (var fld in wrkSetsOrderby)
                    {
                        if (resultDict.ContainsKey(fld.FldNm))
                        {
                            objDict[fld.FldNm] = resultDict[fld.FldNm];
                            OnDataChanged(new DataChangedEventArgs(fld.FldNm, resultDict[fld.FldNm]));
                        }
                        Control ctrl = this.FindForm().Controls.Find(fld.FldNm, true).FirstOrDefault();
                        if (ctrl != null && resultDict.ContainsKey(fld.FldNm))
                        {
                            SetControlValue(ctrl, fld.CtrlNm, fld.ToolNm, resultDict[fld.FldNm]);
                        }
                    }
                }
            }

            //// WrkFldRepo 인스턴스를 생성하여 현재 필드셋에 대한 필드 속성 정보를 가져옵니다.
            //WrkFldRepo wrkFldRepo = new WrkFldRepo();
            //List<WrkFld> flds = wrkFldRepo.GetFldsProperties(frwId, frmId, thisNm);

            //// SQL 쿼리를 생성합니다. 이 쿼리는 주어진 프레임워크 ID, 폼 ID, 작업 ID, 및 CRUDM("R" - 조회) 값을 사용하여 생성됩니다.
            //var sql = GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = thisNm, CRUDM = "R" });

            //// GaiaHelper를 사용하여 데이터베이스에 연결하고 쿼리를 실행합니다.
            //using (var db = new GaiaHelper())
            //{
            //    // 쿼리 결과를 딕셔너리 형태로 가져옵니다.
            //    var resultDict = db.QueryKeyValue(sql, DSearchParam);

            //    // 동적 객체를 생성하여 결과 값을 저장할 딕셔너리를 생성합니다.
            //    dynamic obj = new ExpandoObject();
            //    var objDict = (IDictionary<string, object>)obj;

            //    // 결과 값이 null이 아닌 경우
            //    if (resultDict != null)
            //    {
            //        // 필드셋의 각 필드에 대해
            //        foreach (var fld in flds)
            //        {
            //            // 결과 딕셔너리에 해당 필드 이름이 있는 경우
            //            if (resultDict.ContainsKey(fld.FldNm))
            //            {
            //                // 동적 객체에 필드 값을 설정합니다.
            //                objDict[fld.FldNm] = resultDict[fld.FldNm];

            //                // 데이터가 변경되었음을 알리는 이벤트를 발생시킵니다.
            //                OnDataChanged(new DataChangedEventArgs(fld.FldNm, resultDict[fld.FldNm]));
            //            }

            //            // 폼에서 해당 필드 이름을 가진 컨트롤을 찾습니다.
            //            Control ctrl = this.FindForm().Controls.Find(fld.FldNm, true).FirstOrDefault();

            //            // 컨트롤이 null이 아니고 결과 딕셔너리에 필드 이름이 있는 경우
            //            if (ctrl != null && resultDict.ContainsKey(fld.FldNm))
            //            {
            //                // 컨트롤 값을 설정합니다.
            //                SetControlValue(ctrl, fld.CtrlNm, fld.ToolNm, resultDict[fld.FldNm]);
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        #region this.Save() ----------------------------------------------------------

        private void Save()
        {
            foreach (Control ctrl in this.Controls)
            {
                // WorkSet 모델 인스턴스 생성 및 데이터 설정
                MdlWrkSet model = new MdlWrkSet();
                model.Data = ctrl.Text; // 예시: 컨트롤의 Text 속성 사용
                model.CtrlId = ctrl.Name; // 컨트롤 이름을 ID로 사용

                // 데이터베이스에 저장
                SaveWorkSetData(model);
            }
        }

        private void SaveWorkSetData(MdlWrkSet model)
        {
            //frwId, frmId, wrkId를 알면 해당 워크셋에서 사용하는 insert update, delete 쿼리를 가지고 올 수 있다. 
            return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #region this.Delete() ----------------------------------------------------------

        #endregion


        private void FieldSet_DataChanged(object sender, DataChangedEventArgs e)
        {
            // 데이터가 변경되면 해당 필드셋과 이후의 모든 필드셋을 다시 엽니다.
            bool reopen = false;
            foreach (UCFieldSet fieldSet in fieldSets)
            {
                if (fieldSet == sender)
                {
                    reopen = true;
                }

                if (reopen)
                {
                    fieldSet.Open();
                }
            }
        }
    }
}
