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
using DevExpress.XtraTab;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraEditors;

namespace Frms
{
    public class FrmBase : UserControl
    {
        #region Properties Browseable(false) ----------------------------------------------------------
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        public bool ActivateAllTabsOnLoad { get; set; }

        private object OSearchParam;
        private DynamicParameters DSearchParam;

        private List<UCFieldSet> fieldSets;
        private List<UCGridNav> gridSets;


        private List<IWorkSet> workSets;
        private List<FrmWrk> frmWrks;

        #endregion

        public FrmBase()
        {
            Load += FrmBase_Load;
            fieldSets = new List<UCFieldSet>();
            gridSets = new List<UCGridNav>(); 
        }

        private void FrmBase_Load(object? sender, EventArgs e)
        {
            frwId = Lib.Common.GetValue("gFrameWorkId");

            Form? form = this.FindForm();
            frmId = form != null ? form.Name : "Unknown";

            if (!string.IsNullOrEmpty(frwId))
            {
                //Initialize FieldSet registered in Form
                ResetWorkSet();
            }
        }

        private void ResetWorkSet()
        {
            frmWrks = new FrmWrkRepo().GetByWorkSetsOrderby(frwId, frmId); 

            if (frmWrks.Count > 0)
            {
                foreach (FrmWrk frmWrk in frmWrks)
                {
                    if (frmWrk.WrkCd=="FieldSet")
                    {
                        UCFieldSet fieldSet = new UCFieldSet(frwId, frmId, frmWrk.WrkId);
                        if (fieldSet != null)
                        {
                            workSets.Add(fieldSet);
                            this.Controls.Add(fieldSet);
                            fieldSet.InitializeField();

                            fieldSet.DataChanged += WorkSet_DataChanged;
                        }
                    }
                    else if (frmWrk.WrkCd == "GridSet")
                    {
                        UCGridNav gridSet = CtrlHelper.FindControlRecursive<UCGridNav>(this, frmWrk.WrkId);
                        if (gridSet != null)
                        {
                            gridSets.Add(gridSet);

                            gridSet.DataChanged += WorkSet_DataChanged;
                        }
                    }
                }


                #region 하위 워크셋과의 관계설정

                // 하위 워크셋 관계 설정 워크셋이 부모 워크셋의 값을 가지고 있는 경우

                // 자신의 워크셋을 WrkSet Get하는 것으로 하위 워크셋과의 관계를 설정한다.-------------------------------------------------------

                //foreach (var wrkSet in frmWrks)
                //{
                //    var parentFieldSet = fieldSets.Find(fs => fs.wrkId == wrkSet.WrkId);
                //    if (parentFieldSet != null)
                //    {
                //        foreach (var child in frmWrks.Where(ws => ws.ParentId == wrkSet.WrkId))
                //        {
                //            var childFieldSet = fieldSets.Find(fs => fs.wrkId == child.WrkId);
                //            if (childFieldSet != null)
                //            {
                //                parentFieldSet.ChildWorkSets.Add(childFieldSet);
                //            }

                //            var childGridSet = gridSets.Find(gs => gs.Name == child.WrkId);
                //            if (childGridSet != null)
                //            {
                //                parentFieldSet.ChildWorkSets.Add(childGridSet);
                //            }
                //        }
                //    }

                //    var parentGridSet = gridSets.Find(gs => gs.Name == wrkSet.WrkId);
                //    if (parentGridSet != null)
                //    {
                //        foreach (var child in wrkSetsOrderby.Where(ws => ws.ParentId == wrkSet.WrkId))
                //        {
                //            var childFieldSet = fieldSets.Find(fs => fs.wrkId == child.WrkId);
                //            if (childFieldSet != null)
                //            {
                //                parentGridSet.ChildWorkSets.Add(childFieldSet);
                //            }

                //            var childGridSet = gridSets.Find(gs => gs.Name == child.WrkId);
                //            if (childGridSet != null)
                //            {
                //                parentGridSet.ChildWorkSets.Add(childGridSet);
                //            }
                //        }
                //    }
                //}
                #endregion



            }
        }

        #region this.Open() ----------------------------------------------------------
        //전체오픈
        protected void Open()
        {
            //워트셋의 오픈트리거가 구현되면 최초의 워크셋을 오픈하면 하위 워크셋들이 자동으로 오픈된다.

            foreach (var wrkSet in frmWrks)
            {
                var fieldSet = fieldSets.Find(fs => fs.wrkId == wrkSet.WrkId);
                if (fieldSet != null)
                {
                    fieldSet.Open();
                    Common.gMsg= $"FieldSet Open : {wrkSet.WrkId} ==================================";
                }

                var gridSet = gridSets.Find(gs => gs.Name == wrkSet.WrkId);
                if (gridSet != null)
                {
                    gridSet.Open();
                    Common.gMsg = $"GridSet Open : {wrkSet.WrkId} ==================================";
                }
            }
        }
        #endregion

        #region this.Save() ----------------------------------------------------------
        private void Save()
        {
            var saveOrderby = frmWrks.OrderBy(wrk => wrk.SaveSq).ToList();

            foreach (var wrkSet in saveOrderby)
            {
                var fieldSet = fieldSets.Find(fs => fs.wrkId == wrkSet.WrkId);
                if (fieldSet != null)
                {
                    fieldSet.Save();
                    Common.gMsg = $"FieldSet Save : {wrkSet.WrkId} ==================================";
                }

                var gridSet = gridSets.Find(gs => gs.Name == wrkSet.WrkId);
                if (gridSet != null)
                {
                    gridSet.Save();
                    Common.gMsg = $"GridSet Save : {wrkSet.WrkId} ==================================";
                }
            }
        }
        #endregion

        //private void WorkSet_DataChanged(object sender, DataChangedEventArgs e)
        //{
        //    // 데이터가 변경되면 해당 필드셋과 이후의 모든 필드셋을 다시 엽니다.
        //    bool reopen = false;
        //    foreach (var wrkSet in frmWrks)
        //    {
        //        if (wrkSet.WrkId == (sender as IWorkSet)?.wrkId)
        //        {
        //            reopen = true;
        //        }

        //        if (reopen)
        //        {
        //            var fieldSet = fieldSets.Find(fs => fs.wrkId == wrkSet.WrkId);
        //            fieldSet?.Open();

        //            var gridSet = gridSets.Find(gs => gs.wrkId == wrkSet.WrkId);
        //            gridSet?.Open();
        //        }
        //    }
        //}
        private void WorkSet_DataChanged(object sender, DataChangedEventArgs e)
        {
            //// 변경된 데이터와 관련된 워크셋만 다시 엽니다.
            //var senderWorkSet = sender as IWorkSet;
            //if (senderWorkSet == null) return;

            //// 자신의 그리드를 Get하는 워크셋 목록을 가져옵니다.
            //WrkGetRepo wrkGetRepo = new WrkGetRepo();
            //var pullWrks = wrkGetRepo.GetPullFlds(senderWorkSet.frwId, senderWorkSet.frmId, senderWorkSet.wrkId);

            //foreach (var pullWrk in pullWrks)
            //{
            //    // 해당 워크셋을 찾습니다.
            //    var workSet = workSets.FirstOrDefault(ws => ws.wrkId == pullWrk.WrkId);
            //    if (workSet != null)
            //    {
            //        workSet.Open();
            //    }
            //}
            // 데이터가 변경되면 해당 필드셋과 이후의 모든 필드셋을 다시 엽니다.
            var changedWorkSet = sender as IWorkSet;

            if (changedWorkSet == null)
                return;

            // 자신의 그리드를 Get하는 워크셋 목록을 가져옵니다.
            WrkGetRepo wrkGetRepo = new WrkGetRepo();
            var pullWrks = wrkGetRepo.GetPullWrks(changedWorkSet.frwId, changedWorkSet.frmId, changedWorkSet.wrkId);

            foreach (var wrkSet in pullWrks)
            {
                if (wrkSet.WrkId == changedWorkSet.wrkId)
                {
                    var fieldSet = fieldSets.Find(fs => fs.wrkId == wrkSet.WrkId);
                    fieldSet?.Open();

                    var gridSet = gridSets.Find(gs => gs.wrkId == wrkSet.WrkId);
                    gridSet?.Open();
                }
            }
        }

        #region 탭페이지 활성화 ---------------------------------------------------
        public void ActivateAllTabs()
        {
            ActivateTabPages(this); // this는 현재 폼(FrmBase)을 나타냅니다.
            ResetSelectedTabPages(this); // 활성화 후 원래 선택된 탭 페이지로 복구
        }
        protected void ActivateTabPages(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is UCTab ucTab)
                {
                    foreach (XtraTabPage tabPage in ucTab.TabPages)
                    {
                        ucTab.SelectedTabPage = tabPage;
                        ActivateTabPages(tabPage); // 탭 페이지 내의 컨트롤도 확인
                    }
                }
                else
                {
                    ActivateTabPages(control); // 다른 컨트롤 내부도 재귀적으로 확인
                }
            }
        }

        protected void ResetSelectedTabPages(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is UCTab ucTab)
                {
                    var originalSelectedPage = ucTab.SelectedTabPage;
                    ucTab.SelectedTabPage = originalSelectedPage; // 원래 선택된 탭 페이지로 복구
                    ResetSelectedTabPages(ucTab);
                }
                else
                {
                    ResetSelectedTabPages(control); // 다른 컨트롤 내부도 재귀적으로 확인
                }
            }
        }
        #endregion
    }
}
