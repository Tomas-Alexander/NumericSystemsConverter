using System;
using System.Collections.Generic;

namespace NumericSystemsConverter.DataManager
{
    public class FileDataManager: IDataManager
    {
        public string EntryFile { get; set; }
        public string OutputFile { get; set; }
        public string Separator { get; set; } = "|";

        public IEnumerable<DataStruct> GetData()
        {
            int index= 0;
            foreach(var line in System.IO.File.ReadAllLines(EntryFile))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var columns = line.Split(Separator);
                    var item = new DataStruct
                    {
                        Value = columns[0],
                        From = Enum.Parse<NumericSystem>(columns[1]),
                        To = Enum.Parse<NumericSystem>(columns[2])
                    };

                    if (!Enum.IsDefined(typeof(NumericSystem), item.From))
                        throw new ArgumentException($"From: {columns[1]}. at line: {index}");

                    if (!Enum.IsDefined(typeof(NumericSystem), item.To))
                        throw new ArgumentException($"To: {columns[2]}. at line: {index}");

                    index++;
                    yield return item;
                }
            }
        }

        public void ProcessData(DataStruct data)
        {
            System.IO.File.AppendAllText(OutputFile, $"{data.Value}{Separator}{(int)data.From}{Separator}{(int)data.To}{Separator}{data.Result}\n");
        }

    }
}
