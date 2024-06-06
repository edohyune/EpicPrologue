using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid
{
    public partial class Grid : UserControl
    {
        public Grid()
        {
            InitializeComponent();
        }

        private void gvCtrl_DragObjectOver(object sender, DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs e) 
        { 
           
        }

        private void gvCtrl_DragObjectDrop(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e) { }

        private void gvCtrl_MouseDown(object sender, MouseEventArgs e) { }

        private void gvCtrl_MouseMove(object sender, MouseEventArgs e) { }

        private void g10_DragDrop(object sender, DragEventArgs e) { }

        private void g10_DragOver(object sender, DragEventArgs e) { }

        private void g10_MouseDown(object sender, MouseEventArgs e) { }

        private void g10_MouseMove(object sender, MouseEventArgs e) { }
    }
}
