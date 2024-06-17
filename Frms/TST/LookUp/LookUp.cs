using DevExpress.DataProcessing.InMemoryDataProcessor;
using Lib.Repo;

namespace Frms.TST
{
    public partial class LookUp : UserControl
    {
        public LookUp()
        {
            InitializeComponent();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ucLookUp1.EditValue.ToString());
            MessageBox.Show(ucLookUp1.Text);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ucLookUp2.EditValue.ToString());
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ucLookUp3.Text);
        }


        private void btnCode_Click(object sender, EventArgs e)
        {
            Lib.Common.gMsg = "TEXT========================";
            Lib.Common.gMsg = cmbCd.Text;
            Lib.Common.gMsg = "EDIT========================";
            Lib.Common.gMsg = cmbCd.Code;
            if (cmbCd.CodeZip != null)
            {
                Lib.Common.gMsg = "CodeZip========================";
                Lib.Common.gMsg = $"{cmbCd.CodeZip.Cd}.{cmbCd.CodeZip.SubCd}.{cmbCd.CodeZip.Nm}";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Lib.Common.gMsg = "TEXT========================";
            Lib.Common.gMsg = cmbSubCd.Text;
            Lib.Common.gMsg = "EDIT========================";
            Lib.Common.gMsg = cmbSubCd.Code;
            if (cmbCd.CodeZip != null)
            {
                Lib.Common.gMsg = "CodeZip========================";
                Lib.Common.gMsg = $"{cmbSubCd.CodeZip.Cd}.{cmbSubCd.CodeZip.SubCd}.{cmbSubCd.CodeZip.Nm}";
            }
        }

        private void cmbCd_UCSelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = cmbCd.Code;
        }

        private void cmbSubCd_UCSelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = cmbSubCd.Code;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ucChkCodeBox1.Code;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ucChkCodeBox1.Code = textBox2.Text;
        }

        private void ucChkCodeBox2_UCEditValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = ucChkCodeBox2.Code;
        }


        //        private void simpleButton1_Click(object sender, EventArgs e)
        //        {
        //            MessageBox.Show(selectedDoc.SubCd);
        //        }

        //        private void simpleButton2_Click(object sender, EventArgs e)
        //        {
        //            // 데이터 소스 설정
        //            List<FrwCde> frwCdes = new List<FrwCde>
        //{
        //    new FrwCde { Cd = "001", Nm = "Item 1", SubCd = "S001", Ref01 = "Ref1" },
        //    new FrwCde { Cd = "002", Nm = "Item 2", SubCd = "S002", Ref01 = "Ref2" }
        //};

        //            // UCComboBox 초기화
        //            cmbTest.InitializeComboBox(frwCdes, "Cd", "001");
        //        }

        //        private void simpleButton4_Click(object sender, EventArgs e)
        //        {
        //            List<FrwCde> frwCdes = new List<FrwCde>
        //{
        //    new FrwCde { Cd = "001", Nm = "Item 1", SubCd = "S001", Ref01 = "Ref1" },
        //    new FrwCde { Cd = "002", Nm = "Item 2", SubCd = "S002", Ref01 = "Ref2" }
        //};

        //            // UCComboBox 초기화
        //            ucComboBox1.DataBindings.Clear();
        //            foreach (var item in frwCdes)
        //            {
        //                ucComboBox1.Properties.Items.Add(item);
        //            }
        //        }

        //        private void simpleButton3_Click(object sender, EventArgs e)
        //        {
        //            //var selectedItem = ucComboBox1.SelectedItem;

        //            //// 디버깅을 위해 선택된 항목의 타입과 값을 출력
        //            //if (selectedItem != null)
        //            //{
        //            //    Lib.Common.gMsg = $"Selected Item Type: {selectedItem.GetType().Name}";
        //            //    Lib.Common.gMsg = $"Selected Item Value: {selectedItem}";
        //            //}

        //            //if (selectedItem is FrwCde frwCde)
        //            //{
        //            //    Lib.Common.gMsg = frwCde.Cd;
        //            //    Lib.Common.gMsg = frwCde.Ref01;
        //            //}
        //            //else
        //            //{
        //            //    Lib.Common.gMsg = "SelectedItem is not of type FrwCde";
        //            //}
        //        }
    }
}
