using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EL010.Lib
{
    public class MdlBase : INotifyPropertyChanged
    {
        public MdlState ChangedFlag { get; set; } = MdlState.Inserted;

        private int _CId;
        public int CId
        {
            get => _CId;
            set => Set(ref _CId, value);
        }

        private DateTime _CDt;
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
        public int MId
        {
            get => _MId;
            set => Set(ref _MId, value);
        }

        private DateTime _MDt;
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
            if (this.ChangedFlag != MdlState.Inserted)
            {
                this.ChangedFlag = MdlState.Updated;
            }
            OnPropertyChanged(propertyName);
        }
    }
}
