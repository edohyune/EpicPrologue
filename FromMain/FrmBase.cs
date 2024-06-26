using EpicV003.Lib;
using EpicV003.Lib.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Dapper;
using EpicV003.Ctrls;
using DevExpress.XtraTab;
using System.Windows.Forms;

namespace GAIA
{
    public class FrmBase : UserControl
    {
        #region Properties Browseable(false) ----------------------------------------------------------
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        [Browsable(false)] 
        public bool ActivateAllTabsOnLoad { get; set; }

        private List<UCFieldSet> fieldSets;
        private List<UCGridSet> gridSets;
        private List<UCDataSet> dataSets;
        private List<IWorkSet> workSets;
        private List<FrmWrk> frmWrks;

        #endregion

        public FrmBase()
        {
            Load += FrmBase_Load;
            fieldSets = new List<UCFieldSet>();
            gridSets = new List<UCGridSet>();
            dataSets = new List<UCDataSet>();
            GAIA.FormMain.BarButtonActive += new GAIA.FormMain.BarBtnEventHandler(BarButtonAction);
        }
        protected virtual void BarButtonAction(string frm, string action)
        {
            if (this.Name == frm)
            {
                switch (action)
                {
                    case "Save":
                        this.Save();
                        break;
                    case "Delete":
                        this.Delete();
                        break;
                    case "Open":
                        this.Open();
                        break;
                    case "New":
                        this.New();
                        break;
                }
            }
        }
        private void FrmBase_Load(object? sender, EventArgs e)
        {
            frwId = EpicV003.Lib.Common.GetValue("gFrameWorkId");

            Form? form = this.FindForm();
            frmId = form != null ? form.Name : "Unknown";

            if (!string.IsNullOrEmpty(frwId))
            {
                ResetWorkSet();
            }
        }

        private void ResetWorkSet()
        {
            frmWrks = new FrmWrkRepo().GetByWorkSets(frwId, frmId);
            //frmWrks = new FrmWrkRepo().GetByWorkSetsOrderby(frwId, frmId); 

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
                        UCGridSet gridSet = CtrlHelper.FindControlRecursive<UCGridSet>(this, frmWrk.WrkId);
                        if (gridSet != null)
                        {
                            gridSets.Add(gridSet);
                            gridSet.DataChanged += WorkSet_DataChanged;
                        }
                    }
                    else if (frmWrk.WrkCd == "DataSet")
                    {
                        UCDataSet dataSet = new UCDataSet(frwId, frmId, frmWrk.WrkId);
                        if (dataSet != null)
                        {
                            dataSets.Add(dataSet);
                        }
                    }
                }
            }
        }

        #region this.Open() ----------------------------------------------------------
        //전체오픈
        protected void Open()
        {
            var openFrmWrks = new FrmWrkRepo().GetByOpenWrks(frwId, frmId);
            foreach (var wrkSet in openFrmWrks)
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
        
    public void OpenWorkSet(string wrkId, DynamicParameters param = null)
    {
        var fieldSet = fieldSets.FirstOrDefault(fs => fs.wrkId == wrkId);
        if (fieldSet != null)
        {
            fieldSet.Open();
            return;
        }

        var gridSet = gridSets.FirstOrDefault(gs => gs.wrkId == wrkId);
        if (gridSet != null)
        {
            gridSet.Open();
            return;
        }

        var dataSet = dataSets.FirstOrDefault(ds => ds.wrkId == wrkId);
        if (dataSet != null)
        {
            dataSet.OpenDataSet(param ?? new DynamicParameters());
            return;
        }

        MessageBox.Show($"워크셋 {wrkId}을(를) 찾을 수 없습니다.");
    }

        #endregion
        #region this.Save() ----------------------------------------------------------
        protected void Save()
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
        #region this.New() -------------------------------------------------------------
        protected void New() 
        { 

        }
        #endregion
        #region this.Delete() ----------------------------------------------------------
        protected void Delete() 
        { 

        }
        #endregion

        private void WorkSet_DataChanged(object sender, DataChangedEventArgs e)
        {
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
                if (control is UCTab ucTab) //활성화 대상이 Tab이라 Tab만 확인 
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
