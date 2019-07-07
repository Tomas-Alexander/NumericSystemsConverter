using NumericSystemsConverter.DataManager;
using System;

namespace NumericSystemsConverter
{
    public class NumericSystems
    {
        public static void Convert(IDataManager dataManager)
        {
            var data = dataManager.GetData();
            if (data == null)
                throw new ArgumentNullException();

            foreach (var item in data)
            {
                int temp = (item.From != NumericSystem.Decimal) ?
                                System.Convert.ToInt32(item.Value, (int)item.From) :
                            System.Convert.ToInt32(item.Value);

                item.Result = System.Convert.ToString(temp, (int)item.To);
                dataManager.ProcessData(item);
            }
        }
    }
}
