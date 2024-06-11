using ER000.Interface;
using ER000.WorkSet;
using ER000;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER000
{
    public class FrmBase : UserControl
    {
        public List<IWorkSet> WorkSets = new List<IWorkSet>();
        public FrmBase()
        {
            FrmMain.BarButtonActive += new FrmMain.BarBtnEventHandler(BarButtonAction);
        }
        public void InitializeWorkSets()
        {
            // WorkSet 초기화 및 추가
            WorkSets.Add(new UCFieldSet());
            //WorkSets.Add(new UCGridSet());
        }

        protected virtual void BarButtonAction(string frm, string action)
        {
            if (this.Name == frm)
            {
                foreach (var workSet in WorkSets)
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
        }

        private void New()
        {
            foreach (var workSet in WorkSets)
            {
                workSet.New();
            }
        }

        private void Delete()
        {
            foreach (var workSet in WorkSets)
            {
                workSet.Delete();
            }
        }

        private void Save()
        {
            foreach (var workSet in WorkSets)
            {
                workSet.Save();
            }
        }

        public virtual void Open()
        {
            foreach (var workSet in WorkSets)
            {
                workSet.Open();
            }
        }
    }
}
