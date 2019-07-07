using System;
using System.Collections.Generic;
using System.Text;

namespace NSConverter.DataManager
{
    public interface IDataManager
    {
        IEnumerable<DataStruct> GetData();
        void ProcessData(DataStruct item);
    }
}
