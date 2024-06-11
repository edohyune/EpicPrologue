using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ER000.Lib
{
    public class MdlBase : INotifyPropertyChanged
    {
        //[Display(AutoGenerateField = false)]
        public ModelState ChangedFlag { get; set; } = ModelState.Inserted;

        private int _CId;
        //[Display(AutoGenerateField = false)]
        public int CId
        {
            get => _CId;
            set => Set(ref _CId, value);
        }
        private DateTime _CDt;
        //[Display(AutoGenerateField = false)]
        public DateTime CDt
        {
            get => _CDt;
            set
            {
                if (value == default)
                    throw new ArgumentException("Creation date cannot be default.");
                Set(ref _CDt, value);
            }
        }


        private int _MId;
        //[Display(AutoGenerateField = false)]
        public int MId
        {
            get => _MId;
            set => Set(ref _MId, value);
        }

        private DateTime _MDt;
        //[Display(AutoGenerateField = false)]
        public DateTime MDt
        {
            get => _MDt;
            set
            {
                if (value == default)
                    throw new ArgumentException("Modification date cannot be default.");
                Set(ref _MDt, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Set<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            backingField = value;
            if (this.ChangedFlag != ModelState.Inserted)
            {
                this.ChangedFlag = ModelState.Updated;
            }
            OnPropertyChanged(propertyName);
        }
    }
}
