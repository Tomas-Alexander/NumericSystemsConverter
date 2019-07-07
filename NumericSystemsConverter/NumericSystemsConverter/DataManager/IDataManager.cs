using System;
using System.Collections.Generic;
using System.Text;

namespace NumericSystemsConverter.DataManager
{
    public interface IDataManager
    {
        IEnumerable<DataStruct> GetData();
        void ProcessData(DataStruct item);
    }
}
