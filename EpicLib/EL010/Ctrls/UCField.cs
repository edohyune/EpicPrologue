using EL010.Lib;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.Control;

namespace EL010.Ctrls
{
    public class UCField : System.Windows.Forms.BindingSource, INotifyPropertyChanged
    {
        public UCField()
        {
            this.DataSource = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MdlState ChangedFlag { get; set; } = MdlState.Inserted;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Set<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            backingField = value;
            if (this.ChangedFlag != MdlState.Inserted)
            {
                this.ChangedFlag = MdlState.Updated;
            }
            OnPropertyChanged(propertyName);
        }

        public string GetParamValue(ControlCollection frm, string param_name, string wkset, string field)
        {
            string str = string.Empty;
            if (wkset != "Field")
            {
                dynamic tbx = frm.Find(wkset, true).FirstOrDefault();
                str = tbx.GetText(field);
            }
            else
            {
                dynamic tbx = frm.Find(field, true).FirstOrDefault();
                str = tbx.BindText;
            }
            return str;
        }


    }
}
