using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace EpicV003.Lib
{
    public class DynamicModel : DynamicObject, INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public MdlState ChangedFlag { get; set; } = MdlState.Inserted;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(backingField, value)) return false;

            backingField = value;
            if (this.ChangedFlag != MdlState.Inserted)
            {
                this.ChangedFlag = MdlState.Updated;
            }
            OnPropertyChanged(propertyName);
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _properties.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_properties.TryGetValue(binder.Name, out var existingValue))
            {
                if (Equals(existingValue, value)) return true;
            }

            _properties[binder.Name] = value;
            if (this.ChangedFlag != MdlState.Inserted)
            {
                this.ChangedFlag = MdlState.Updated;
            }
            OnPropertyChanged(binder.Name);
            return true;
        }

        public void SetDynamicProperty(string propertyName, object value)
        {
            if (_properties.ContainsKey(propertyName))
            {
                _properties[propertyName] = value;
            }
            else
            {
                _properties.Add(propertyName, value);
            }
            if (this.ChangedFlag != MdlState.Inserted)
            {
                this.ChangedFlag = MdlState.Updated;
            }
            OnPropertyChanged(propertyName);
        }

        public object GetDynamicProperty(string propertyName)
        {
            return _properties.TryGetValue(propertyName, out var value) ? value : null;
        }
                // 새롭게 추가된 메서드: 모든 동적 속성을 가져오는 메서드
        public IDictionary<string, object> GetDynamicProperties()
        {
            return _properties;
        }
    }
}
