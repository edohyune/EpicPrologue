using Dapper;
using ER000.Lib;
using System.Dynamic;

namespace ER000.WorkSet
{
    public class UCFieldSet : UserControl, Interface.IWorkSet
    {
        public string frwId { get; set; }
        public string frmId { get; set; }
        public string thisNm { get; set; }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ModelState GetState()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void New()
        {
            throw new NotImplementedException();
        }

        public void OnDataChanged()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

public class DataChangedEventArgs : EventArgs
{
    public string FieldName { get; }
    public dynamic NewValue { get; }

    public DataChangedEventArgs(string fieldName, dynamic newValue)
    {
        FieldName = fieldName;
        NewValue = newValue;
    }
}
