using ER000.Interface;
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
            FrmMain.BarButtonActive += new FrmMain.MyEventHandler(BarButtonAction);
        }
        public void InitializeWorkSets()
        {
            // WorkSet 초기화 및 추가
            WorkSets.Add(new UCFieldSet());
            WorkSets.Add(new UCGridSet());
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
                            workSet.Save();
                            break;
                        case "Delete":
                            workSet.Delete();
                            break;
                        case "Open":
                            workSet.Open();
                            break;
                        case "New":
                            workSet.New();
                            break;
                    }
                }
            }
        }

        public virtual void Open()
        {
            this.InitializeWorkSets();

            foreach (var workSet in WorkSets)
            {
                workSet.Initialize();
            }
        }
    }
}
