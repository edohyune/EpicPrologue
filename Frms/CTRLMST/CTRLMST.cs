using DevExpress.XtraEditors;
using EpicV003.Lib;
using EpicV003.Lib.Repo;
using System.ComponentModel;

namespace Frms
{
    public partial class CTRLMST : UserControl
    {
        public CTRLMST()
        {
            InitializeComponent();
        }

        private void gridCtrls_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            var view = gvCtrls;
            var data = gridCtrls.DataSource as List<CtrlMst>;

            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.Remove:
                    var idToRemove = view.GetFocusedRowCellValue("CtrlId");
                    if (idToRemove != null)
                    {
                        ctrlclsrepo.Delete((int)idToRemove);
                        //data.Remove(data.Find(x => x.CtrlId == (int)idToRemove));
                        view.RefreshData();
                    }
                    break;
                case NavigatorButtonType.EndEdit:
                    if (view.IsEditing)
                    {
                        view.CloseEditor();
                        view.UpdateCurrentRow();
                    }

                    var updatedRow = view.GetFocusedRow() as CtrlMst;

                    if (updatedRow != null)
                    {
                        if (updatedRow.ChangedFlag == MdlState.Updated)
                        {
                            // 기존 행을 업데이트합니다.
                            ctrlclsrepo.Update(updatedRow);
                        }
                        view.RefreshData();
                    }
                    break;
            }
        }

        private void ucPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Open")
            {
                gridCtrls_open();
            }
        }

        BindingList<CtrlMst> ctrlclss;
        CtrlMstRepo ctrlclsrepo;
        private void gridCtrls_open()
        {
            ctrlclss = null;
            ctrlclsrepo = new CtrlMstRepo();
            ctrlclss = new BindingList<CtrlMst>(ctrlclsrepo.GetAll());
            gridCtrls.DataSource = ctrlclss;
        }
    }
}
