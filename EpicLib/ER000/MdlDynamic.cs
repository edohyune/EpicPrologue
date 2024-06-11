using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ER000.Lib
{
    public class DynamicModel : DynamicObject, INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public ModelState ChangedFlag { get; set; } = ModelState.Inserted;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(backingField, value)) return false;

            backingField = value;
            if (this.ChangedFlag != ModelState.Inserted)
            {
                this.ChangedFlag = ModelState.Updated;
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
            if (this.ChangedFlag != ModelState.Inserted)
            {
                this.ChangedFlag = ModelState.Updated;
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
            if (this.ChangedFlag != ModelState.Inserted)
            {
                this.ChangedFlag = ModelState.Updated;
            }
            OnPropertyChanged(propertyName);
        }

        public object GetDynamicProperty(string propertyName)
        {
            return _properties.TryGetValue(propertyName, out var value) ? value : null;
        }
    }
}
