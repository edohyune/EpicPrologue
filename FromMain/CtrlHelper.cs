using System.Windows.Forms;

namespace GAIA
{
    public static class CtrlHelper
    {
        public static T FindControlRecursive<T>(Control root, string name) where T : Control
        {
            if (root == null) return null;

            foreach (Control control in root.Controls)
            {
                if (control.Name == name && control is T)
                    return (T)control;

                var foundControl = FindControlRecursive<T>(control, name);
                if (foundControl != null)
                    return foundControl;
            }
            return null;
        }
    }
}
